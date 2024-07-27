using api.Handlers;
using api.Handlers.BootstrapDatabase;
using api.Handlers.GoogleCalendar;
using api.Handlers.Trello;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.EntityFrameworkCore;
using Oakton;
using Serilog;
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

builder.Host.UseWolverine();

// Configure Options
// TODO: Validate options
builder.Services.Configure<GoogleCalendarOptions>(
    builder.Configuration.GetSection(GoogleCalendarOptions.ConfigName));
builder.Services.Configure<TomorrowWeatherOptions>(
    builder.Configuration.GetSection(TomorrowWeatherOptions.ConfigName));
builder.Services.Configure<TrelloOptions>(
    builder.Configuration.GetSection(TrelloOptions.ConfigName));

// Configure services
builder.Services.AddMemoryCache();

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
app.MapGet("/bible", async (IMessageBus bus) => await bus.InvokeAsync<Passage>(new GetBibleVerseOfTheDayRequest()));
app.MapGet("/db", async (IMessageBus bus) => await bus.InvokeAsync(new BootstrapDatabaseRequest()));
app.MapGet("/google-calendar", async (IMessageBus bus) => await bus.InvokeAsync<EventDto[]>(new GetGoogleCalendarRequest()));
app.MapGet("/trello/abigail", async (IMessageBus bus) => await bus.InvokeAsync<object>(GetTrelloCardRequest.ForAbigail()));
app.MapGet("/trello/elijah", async (IMessageBus bus) => await bus.InvokeAsync<object>(GetTrelloCardRequest.ForElijah()));
app.MapGet("/msg", async (IMessageBus bus) => await bus.InvokeAsync(new SendNtfyCommand { Message = "hello", Topic = "jctest1" }));
app.MapGet("/weather", async (IMessageBus bus) => await bus.InvokeAsync<object>(GetWeatherRequest.BaulkhamHills()));

return await app.RunOaktonCommands(args);

// Add SignalR (push to update)
// Add validation for Options
// Alba style testing
// Add Google Calendar: finish
// Update prod for Wolverine
// Deploy
// Add Spotify integration
// Think about how we can do better integration with caching layer
