import axios from 'axios'

export default defineEventHandler(async (event) => {
    assertMethod(event, 'GET')

    const { trelloApiKey, trelloToken } = useRuntimeConfig(event)
    const boardId = '6456ee558a95af852f5240fc' // This is the Thoughts Trello id, for later reference. curl 'https://api.trello.com/1/members/me/boards?key={yourKey}&token={yourToken}'
    const listId = '6698ef77181ff8e1d7a5b4a7'
    const cardId = '6699104c02a515737b8e53ba' // This is Abigail
    const result = await axios.get(
        `https://api.trello.com/1/cards/${cardId}?key=${trelloApiKey}&token=${trelloToken}`
    )
    return {
        text: result.data.name,
    }
})
