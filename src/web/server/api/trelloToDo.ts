import axios from 'axios'

type Card = {
    name: string
    dayOfWeek: string
    dayOfWeekNumber: number
    sortIndex: number
}
export default defineEventHandler(async (event) => {
    assertMethod(event, 'GET')

    const { trelloApiKey, trelloToken } = useRuntimeConfig(event)
    const boardId = '6456ee558a95af852f5240fc' // This is the groceries Trello id, for later reference
    const listId = '669a4de4d39ad7dcdd79e15b'
    const result = await axios.get(
        `https://api.trello.com/1/lists/${listId}/cards?key=${trelloApiKey}&token=${trelloToken}`
    )

    return {
        cards: result.data,
    }
})
