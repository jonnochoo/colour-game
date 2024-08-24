<template>
    <div class="mx-auto w-80" @submit.prevent="login">
        <form>
            <div class="mb-6">
                <input
                    type="password"
                    id="password"
                    placeholder="Enter your password"
                    v-model="user.password"
                    class="w-full rounded-md border border-gray-300 p-3 focus:outline-none focus:ring-2 focus:ring-blue-500"
                />
            </div>
            <div class="flex items-center justify-between">
                <button
                    type="submit"
                    class="w-full rounded-md bg-blue-500 p-3 text-white hover:bg-blue-600 focus:outline-none focus:ring-2 focus:ring-blue-500"
                >
                    Login
                </button>
                <div class="text-white">{{ authStore.token }}</div>
            </div>
        </form>
    </div>
</template>

<script setup lang="ts">
import { EmptyUser, type User } from '~/stores/authStore'

const authStore = useAuthStore()
definePageMeta({
    layout: 'dashboard',
})
const user = reactive<User>(EmptyUser)

const login = async () => {
    authStore.login(user)
    if (authStore.isAuthenticated) {
        navigateTo('/dashboard')
    }
}
</script>

<style>
body {
    background-color: #1b1428; /*TODO: this needs to be  fixed to be handle in the layout*/
}
</style>
