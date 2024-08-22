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
    const boardId = '544edd0782c0c6922e73b778' // This is the groceries Trello id, for later reference
    const listId = '5bb567c2bcadfe0f62c15015'
    const result = await axios.get(
        `https://api.trello.com/1/lists/${listId}/cards?key=${trelloApiKey}&token=${trelloToken}`
    )
    const meals: Card[] = result.data
        .map((x: any) => {
            const splitText = x.name.split(':')
            if (splitText.length !== 2) {
                return {
                    name: null,
                    dayOfWeek: null,
                    dayOfWeekNumber: -1,
                }
            }
            const dayOfWeek = splitText[0].trim()
            const name = toTitleCase(splitText[1].trim())
            const dayOfWeekNumber = parseDayToEnum(dayOfWeek)
            return {
                name: name,
                dayOfWeek: dayOfWeek,
                dayOfWeekNumber: dayOfWeekNumber,
                sortIndex: getSortOfWeekNumber(dayOfWeekNumber),
            }
        })
        .filter((x: Card) => x.dayOfWeekNumber >= 0 && x.name !== '')
    // .toSorted((a: Card, b: Card) => a.sortIndex - b.sortIndex)
    return {
        meals,
    }
})

function getSortOfWeekNumber(dayOfWeekNumber: number) {
    const currentDateNumber = new Date().getDay()
    if (dayOfWeekNumber >= currentDateNumber) {
        return dayOfWeekNumber - currentDateNumber
    }

    return dayOfWeekNumber + currentDateNumber
}

function toTitleCase(str: string) {
    return str
        .split(' ')
        .map(
            (word) => word.charAt(0).toUpperCase() + word.slice(1).toLowerCase()
        )
        .join(' ')
}

const DayOfWeek = {
    SUNDAY: 0,
    MONDAY: 1,
    TUESDAY: 2,
    WEDNESDAY: 3,
    THURSDAY: 4,
    FRIDAY: 5,
    SATURDAY: 6,
}
function parseDayToEnum(dayName) {
    const date = parse(dayName, 'EEE', new Date())
    if (!isValid(date)) {
        return -1
    }
    return date.getDay()
}
