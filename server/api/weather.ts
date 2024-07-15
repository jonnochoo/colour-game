import axios from 'axios'

export default defineEventHandler(async (event) => {
    assertMethod(event, 'GET')

    const { weatherApiKey } = useRuntimeConfig(event)
    const result = await axios.get(
        `https://api.tomorrow.io/v4/weather/forecast?location=-33.760672,150.993018&apikey=${weatherApiKey}`
    )

    return {
        now: result.data.timelines.minutely[0],
    }
})
