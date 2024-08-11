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

        XmlNode? contentNode = doc.SelectSingleNode("/rss/channel/item");
        if (contentNode != null)
        {
            var verseNode = contentNode.ChildNodes[0];
            if (verseNode == null)
            {
                throw new InvalidOperationException("Unable to find the verse node");
            }
            var textNode = contentNode.ChildNodes[3];
            if (textNode == null)
            {
                throw new InvalidOperationException("Unable to find the text node");
            }

            string verse = verseNode.InnerText;
            string text = HttpUtility.HtmlDecode(textNode.InnerText)
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
