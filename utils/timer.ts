export const Milliseconds = {
    FromMinutes: (minutes: number) => {
        return minutes * 1000 * 60
    },
    FromAsSeconds: (seconds: number) => {
        return seconds * 1000
    },
}
