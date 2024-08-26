import { useLocalStorage } from '@vueuse/core'
import { addSeconds } from 'date-fns'
import { defineStore } from 'pinia'
import { ref, computed } from 'vue'

const config = useRuntimeConfig()

export type User = { username: string; password: string }
export type UserToken = {
    token: string
    expiryDate: Date | null
}
const UnauthenticatedToken: UserToken = { token: '', expiryDate: null }

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
    const user = ref<null | User>()
    const token = useLocalStorage('token', UnauthenticatedToken)

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
            token.value = {
                token: response.accessToken,
                expiryDate: addSeconds(new Date(), response.expiresIn),
            }
            user.value = userData
            console.log('success', response)

            // Update
        } catch (e) {
            console.log('error: ', e)
        }
    }

    function logout() {
        user.value = null
        token.value = UnauthenticatedToken
        useLocalStorage<string>('token', null)
    }

    // Getters
    const isAuthenticated = computed(() => true)

    return { user, token, login, logout, isAuthenticated }
})
