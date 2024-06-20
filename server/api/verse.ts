import axios from 'axios'

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
    }
})
