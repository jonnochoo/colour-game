import axios from 'axios'
import { removeUnnecessaryNewLine } from '../../utils/text/bible'

export default defineEventHandler(async (event) => {
    assertMethod(event, 'GET')

    const query = getQuery(event)
    const passageSearch = encodeURIComponent(query.passage)
    const { apiSecret } = useRuntimeConfig(event)
    const result = await axios.get(
        `https://api.esv.org/v3/passage/text/?q=${passageSearch}`,
        { headers: { Authorization: `Token ${apiSecret}` } }
    )
    return {
        ...result.data,
        query,
        passageChunks: parseText(
            result.data.passages
                ? removeUnnecessaryNewLine(result.data.passages[0])
                : ''
        ),
    }
})

export function parseText(inputText: string) {
    const regex = /(\[\d+\])/
    const result = inputText.split(regex)
    const filteredResult = result.filter((item: string) => item !== '')
    return filteredResult
}
