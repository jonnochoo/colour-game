export const Milliseconds = {
    FromHours: (hours: number) => {
        return hours * 1000 * 60 * 60
    },
    FromMinutes: (minutes: number) => {
        return minutes * 1000 * 60
    },
    FromAsSeconds: (seconds: number) => {
        return seconds * 1000
    },
}
