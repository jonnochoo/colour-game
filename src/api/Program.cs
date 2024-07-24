using System.Web;
using System.Xml;
using Flurl.Http;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextFactory<ApplicationDbContext>(options => options.UseSqlite("Data Source=app.db"));
builder.Services.AddIdentityApiEndpoints<User>().AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddAuthorization();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
        options.SlidingExpiration = true;
        options.AccessDeniedPath = "/Forbidden/";
    });

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
// app.UseCookiePolicy(cookiePolicyOptions);
app.MapIdentityApi<User>();
app.MapGet("/start", async (ApplicationDbContext dbContext, UserManager<User> userManager) =>
{
    await dbContext.Database.EnsureCreatedAsync();

    User user = new User
    {
        UserName = "user"
    };
    var result = await userManager.CreateAsync(user, "Password123!");
    return Results.Ok(result.Errors);
}).WithOpenApi();


app.MapGet("/bible", async (ApplicationDbContext dbContext) =>
{
    await dbContext.Database.EnsureCreatedAsync();
    string url = "https://www.biblegateway.com/usage/votd/rss/votd.rdf";
    var xmlContent = await url.GetStringAsync();
    XmlDocument doc = new XmlDocument();
    doc.LoadXml(xmlContent);

    XmlNode contentNode = doc.SelectSingleNode("/rss/channel/item");
    if (contentNode != null)
    {
        string verse = contentNode.ChildNodes[0].InnerText;
        string text = HttpUtility.HtmlDecode(contentNode.ChildNodes[3].InnerText)
            .Replace("<br/><br/> Brought to you by <a href=\"https://www.biblegateway.com\">BibleGateway.com</a>. Copyright (C) . All Rights Reserved.", String.Empty);
        return new Passage
        {
            Verse = verse,
            Text = text
        };
    }

    return null;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();