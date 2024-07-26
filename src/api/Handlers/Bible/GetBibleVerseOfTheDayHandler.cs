using System.Web;
using System.Xml;
using Flurl.Http;
using Wolverine;

namespace api.Handlers;

public class GetBibleVerseOfTheDayHandler : IWolverineHandler
{
    public async Task<Passage> Handle(GetBibleVerseOfTheDayRequest command)
    {
        string url = "https://www.biblegateway.com/usage/votd/rss/votd.rdf";
        var xmlContent = await url.GetStringAsync();
        var doc = new XmlDocument();
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

        return new()
        {
            Text = "s",
            Verse = "s"
        };
    }
}
