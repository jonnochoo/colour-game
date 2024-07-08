import axios from 'axios'
import {
    parsePassageIntoVerses,
    removeUnnecessaryNewLine,
    splitPassageAndFootNote,
} from '../../utils/text/bible'
import { z } from 'zod'

const schema = z.object({
    query: z.string(),
    canonical: z.string(),
    parsed: z.array(z.array(z.number())),
    passage_meta: z.array(
        z.object({
            canonical: z.string(),
            chapter_start: z.array(z.number()),
            chapter_end: z.array(z.number()),
            prev_verse: z.number(),
            next_verse: z.number(),
            prev_chapter: z.array(z.number()),
            next_chapter: z.array(z.number()),
        })
    ),
    passages: z.array(z.string()),
})

export default defineEventHandler(async (event) => {
    assertMethod(event, 'GET')

    const query = getQuery(event)
    const passageSearch = encodeURIComponent(query.passage)
    const { apiSecret } = useRuntimeConfig(event)
    const result = await axios.get(
        `https://api.esv.org/v3/passage/text/?q=${passageSearch}`,
        { headers: { Authorization: `Token ${apiSecret}` } }
    )

    const passageResult = schema.parse(result.data)
    return {
        ...passageResult,
        passageChunks: parsePassageIntoVerses(
            result.data.passages
                ? removeUnnecessaryNewLine(passageResult.passages[0])
                : ''
        ),
        passageChunksv2: splitPassageAndFootNote(
            removeUnnecessaryNewLine(passageResult.passages[0])
        ),
    }
})
