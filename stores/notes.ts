import { defineStore } from 'pinia'
export const useNotesStore = defineStore('todos', () => {
    const note = ref<Note>({ text: 'hello' })
    const error = ref<any>(null)
    const pending = ref(false)
    const refresh = async () => {
        try {
            pending.value = true
            const data = await $fetch<Note>('api/note')
            pending.value = false
            if (data !== null) {
                note.value.text = data.text
            }
        } catch (e) {
            error.value = e
        }
    }
    return { note, refresh, pending, error }
})

type Note = {
    text: string
    // timestamp: ??
}
