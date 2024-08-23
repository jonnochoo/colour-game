import { defineStore } from 'pinia'
import { ref, computed } from 'vue'

const config = useRuntimeConfig()

export type User = { username: string; password: string }
export type LoginResponse = {
    tokenType: string
    accessToken: string
    expiresIn: number
    refreshToken: string
}
export const EmptyUser: User = {
    username: '',
    password: '',
}
export const useAuthStore = defineStore('auth', () => {
    // State
    const user = ref<null | User>(null)
    const token = ref<null | string>(null)

    // Actions
    async function login(userData: User) {
        console.log(userData)

        try {
            const response = await $fetch<LoginResponse>('login', {
                method: 'POST',
                baseURL: config.public.baseUrl,
                body: {
                    email: 'user',
                    password: userData.password,
                },
            })
            token.value = response.accessToken
            user.value = userData
            console.log('success', token.value)
            // Save in local storage
            // Update
        } catch (e) {
            console.log('error: ', e)
        }
    }

    function logout() {
        user.value = null
        token.value = null
    }

    // Getters
    const isAuthenticated = computed(() => !!user.value)

    return { user, token, login, logout, isAuthenticated }
})
