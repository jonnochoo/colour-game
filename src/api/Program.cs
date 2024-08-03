using api.Handlers;
using api.Handlers.BootstrapDatabase;
using api.Handlers.GoogleCalendar;
using api.Handlers.Trello;
using Api.Bootstrap.Cache;
using Api.Bootstrap.Options;
using Api.Handlers.Weather.Tomorrow;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.EntityFrameworkCore;
using Oakton;
using Serilog;
using SignalRChat.Hubs;
using Wolverine;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContextFactory<ApplicationDbContext>(options => options.UseSqlite("Data Source=app.db"));

// Configure security
builder.Services.AddIdentityApiEndpoints<User>().AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddAuthorization();
builder.Services.AddAuthentication();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
            policy =>
            {
                policy.AllowAnyOrigin();
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
            });
});

// Add infrastructure
builder.Services.AddSerilog();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();

builder.Host.UseWolverine();

// Configure Options
builder.Services.AddOptionsWithValidation<GoogleCalendarOptions, GoogleCalendarOptionsValidator>()
    .PostConfigure(x => { x.PrivateKey = x.PrivateKey.Replace("\\n", "\n"); });
builder.Services.AddOptionsWithValidation<TomorrowWeatherOptions, TomorrowWeatherOptionsValidator>();
builder.Services.AddOptionsWithValidation<TrelloOptions, TrelloOptionsValidator>();

// Configure services
builder.Services.AddMemoryCache();
builder.Services.AddOutputCache(options =>
{
    options.AddBasePolicy(builder => builder.Expire(TimeSpan.FromSeconds(5)));
    options.AddPolicy(CachePolicyName.ThirtySeconds, builder => builder.Expire(TimeSpan.FromSeconds(30)));
    options.AddPolicy(CachePolicyName.FiveMinutes, builder => builder.Expire(TimeSpan.FromMinutes(5)));
});

// Create the web app.
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSerilogRequestLogging();

// Security Related
app.UseHttpsRedirection();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();
var cookiePolicyOptions = new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.Lax,
    HttpOnly = HttpOnlyPolicy.Always,
};
app.UseCookiePolicy(cookiePolicyOptions);

// Routing
app.MapIdentityApi<User>();
app.MapGet("/", () => "OK");
app.MapGet("/auth", () => "OK").RequireAuthorization();
app.MapGet("/bible", [OutputCache] async (IMessageBus bus) => await bus.InvokeAsync<Passage>(new GetBibleVerseOfTheDayRequest()));
app.MapGet("/db", async (IMessageBus bus) => await bus.InvokeAsync(new BootstrapDatabaseRequest()));
app.MapGet("/google-calendar", [OutputCache] async (IMessageBus bus) => await bus.InvokeAsync<EventDto[]>(new GetGoogleCalendarRequest()));
app.MapGet("/trello/abigail", [OutputCache] async (IMessageBus bus) => await bus.InvokeAsync<object>(GetTrelloCardRequest.ForAbigail()));
app.MapGet("/trello/elijah", [OutputCache] async (IMessageBus bus) => await bus.InvokeAsync<object>(GetTrelloCardRequest.ForElijah()));
app.MapGet("/trello/think", [OutputCache] async (IMessageBus bus) => await bus.InvokeAsync<object>(GetTrelloCardRequest.ForThink()));
app.MapGet("/trello/todos", [OutputCache] async (IMessageBus bus) => await bus.InvokeAsync<GetTodoListResponseItem[]>(new GetTodoListRequest()));
app.MapGet("/trello/meals", [OutputCache] async (IMessageBus bus) => await bus.InvokeAsync<GetMealsResponseItem[]>(new GetMealsRequest()));
app.MapGet("/msg", async (IMessageBus bus) => await bus.InvokeAsync(new SendNtfyCommand { Message = "hello", Topic = "jctest1" }));
app.MapGet("/weather", [OutputCache(PolicyName = CachePolicyName.FiveMinutes)] async (IMessageBus bus) => await bus.InvokeAsync<object>(GetWeatherRequest.BaulkhamHills()));

app.MapHub<DashboardHub>("/hubs/dashboard");

app.UseOutputCache();

return await app.RunOaktonCommands(args);

// Add SignalR (push to update)
// Alba style testing
// Update prod for Wolverine
// Deploy
// Add Spotify integration
// Think about how we can do better integration with caching layer
// Add auth
// Integrate with Nuxt to C# Api
// NWAG
// Bookmarks of links
// Joshua project https://joshuaproject.net/resources/datasets