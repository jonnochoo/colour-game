import axios, { AxiosResponse } from 'axios'
import { getRandomCountry } from '~/utils/countries/countries'

export default defineEventHandler(async (event) => {
    assertMethod(event, 'GET')

    const randomCountry = getRandomCountry()
    const response: AxiosResponse = await axios.get(
        `https://restcountries.com/v3.1/name/${randomCountry}`
    )

    return {
        info: response.data,
    }
})
