<template>
    <div class="margin-auto container">
        <form>
            <div class="mb-4">
                <label
                    for="email"
                    class="mb-2 block text-sm font-bold text-gray-700"
                    >Email</label
                >
                <input
                    type="email"
                    id="email"
                    placeholder="Enter your email"
                    class="w-full rounded-md border border-gray-300 p-3 focus:outline-none focus:ring-2 focus:ring-blue-500"
                />
            </div>
            <div class="mb-6">
                <label
                    for="password"
                    class="mb-2 block text-sm font-bold text-gray-700"
                    >Password</label
                >
                <input
                    type="password"
                    id="password"
                    placeholder="Enter your password"
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
</template>

<script setup lang="ts">
definePageMeta({
    layout: 'dashboard',
})

const login = () => {
    $fetch('/login')
}
</script>

<style>
body {
    background-color: #1b1428; /*TODO: this needs to be  fixed to be handle in the layout*/
}
</style>
