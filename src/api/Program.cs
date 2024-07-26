using api.Handlers;
using api.Handlers.BootstrapDatabase;
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
app.MapGet("/trello", async (IMessageBus bus) => await bus.InvokeAsync<object>(new GetTrelloCardRequest { CardId = "6698f15b08496fa1b211f617" }));
app.MapGet("/db", async (IMessageBus bus) => await bus.InvokeAsync(new BootstrapDatabaseRequest()));
app.MapGet("/msg", async (IMessageBus bus) => await bus.InvokeAsync(new SendNtfyCommand { Message = "hello", Topic = "jctest1" }));
app.MapGet("/bible", async (IMessageBus bus) => await bus.InvokeAsync<Passage>(new GetBibleVerseOfTheDayRequest()));
app.MapGet("/weather", async (IMessageBus bus) => await bus.InvokeAsync<object>(GetWeatherRequest.BaulkhamHills()));
app.MapGet("/auth", () => "OK")
    .RequireAuthorization();

return await app.RunOaktonCommands(args);