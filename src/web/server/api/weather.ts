import axios, { AxiosResponse } from 'axios'

export default defineEventHandler(async (event) => {
    assertMethod(event, 'GET')

    const { weatherApiKey } = useRuntimeConfig(event)
    const response: AxiosResponse = await axios.get(
        `https://api.tomorrow.io/v4/weather/forecast?location=-33.760672,150.993018&apikey=${weatherApiKey}`
    )

    if (response.status === 429) {
        return {
            now: {},
        }
    }
    return {
        now: response.data.timelines.minutely[0],
    }
})
