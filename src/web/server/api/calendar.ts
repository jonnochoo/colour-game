import { google } from 'googleapis'

export default defineEventHandler(async (event) => {
    assertMethod(event, 'GET')

    // https://joshuaakanetuk.com/blog/how-to-use-google-calendar/
    // https://www.geeksforgeeks.org/how-to-integrate-google-calendar-in-node-js/
    const SCOPES = ['https://www.googleapis.com/auth/calendar.readonly']

    const { googleCalendarServiceAccountEmail, googleCalendarPrivateKey } =
        useRuntimeConfig(event)
    const key = {
        client_email: googleCalendarServiceAccountEmail,
        private_key: googleCalendarPrivateKey,
    }
    // Create a new JWT client using the key file
    const auth = new google.auth.JWT({
        email: key.client_email,
        key: key.private_key.replace(/\\n/g, '\n'), // https://stackoverflow.com/a/36439803
        scopes: SCOPES,
    })

    var events1 = await listEvents(auth, 'joannejjma@gmail.com')
    var events2 = await listEvents(auth, 'jonno.choo@gmail.com')
    var events = [events1?.items, events2?.items]
        .flat()
        .map((evt) => {
            return {
                summary: evt?.summary,
                calendarId: evt?.creator.email,
                start: evt?.start,
                startDate: evt?.start.date || evt?.start?.dateTime,
            }
        })
        .sort((a, b) =>
            a.startDate > b.startDate ? 1 : a.startDate < b.startDate ? -1 : 0
        )
    return {
        events,
    }
})

// Example: List the user's calendar events
async function listEvents(auth, calendarId: string) {
    const calendar = google.calendar({ version: 'v3', auth })
    try {
        const response = await calendar.events.list({
            calendarId: calendarId, // or the specific calendar ID
            timeMin: new Date().toISOString(),
            maxResults: 12,
            singleEvents: true,
            orderBy: 'startTime',
        })
        const events = response.data.items
        return response.data
    } catch (err) {
        console.error('Error fetching calendar events:', err)
    }
}
