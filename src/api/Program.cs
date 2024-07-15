using System.Web;
using System.Xml;
using Flurl.Http;

var builder = WebApplication.CreateBuilder(args);

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

app.MapGet("/bible", async () =>
{
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