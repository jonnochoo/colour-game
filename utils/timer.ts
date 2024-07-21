export const Milliseconds = {
    AsMinutes: (minutes: number) => {
        return minutes * 1000 * 60
    },
    AsSeconds: (seconds: number) => {
        return seconds * 1000
    },
}
