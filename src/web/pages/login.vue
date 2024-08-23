<template>
    <div class="m-auto">
        <div class="container" @submit.prevent="login">
            <form>
                <div class="mb-6">
                    <label
                        for="password"
                        class="mb-2 block text-sm font-bold text-white"
                        >Password</label
                    >
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
                </div>
            </form>
        </div>
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
}
</script>

<style>
body {
    background-color: #1b1428; /*TODO: this needs to be  fixed to be handle in the layout*/
}
</style>
