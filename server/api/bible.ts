import axios from 'axios'
import xml2js from 'xml2js'

export default defineEventHandler(async (event) => {
    assertMethod(event, 'GET')

    const response = await axios.get(
        `https://www.biblegateway.com/usage/votd/rss/votd.rdf`
    )
    const xmlContent = response.data

    const parser = new xml2js.Parser()
    const result = await parser.parseStringPromise(xmlContent)

    const contentNode = result.rss.channel[0].item[0]
    if (!contentNode) {
        return 'error'
    }
    const verse = contentNode.title[0]
    const text = contentNode['content:encoded'][0]
        .replace(
            '.&rdquo;<br/><br/> Brought to you by <a href="https://www.biblegateway.com">BibleGateway.com</a>. Copyright (C) . All Rights Reserved.\n\t\t\t\t\t\t',
            ''
        )
        .replace('\n\t\t\t\t\t\t\t&ldquo;', '')

    return {
        verse,
        text,
    }
})
