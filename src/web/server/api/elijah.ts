import axios from 'axios'
import { daysToWeeks, isValid, parse } from 'date-fns'
import { number } from 'zod'

type Card = {
    name: string
    dayOfWeek: string
    dayOfWeekNumber: number
    sortIndex: number
}
export default defineEventHandler(async (event) => {
    assertMethod(event, 'GET')

    const { trelloApiKey, trelloToken } = useRuntimeConfig(event)
    const boardId = '6456ee558a95af852f5240fc' // This is the Thoughts Trello id, for later reference. curl 'https://api.trello.com/1/members/me/boards?key={yourKey}&token={yourToken}'
    const listId = '6698ef77181ff8e1d7a5b4a7'
    const cardId = '6698f157ecbacd29624830dc' // This is elijah
    const result = await axios.get(
        `https://api.trello.com/1/cards/${cardId}?key=${trelloApiKey}&token=${trelloToken}`
    )
    return {
        text: result.data.name,
    }
})
