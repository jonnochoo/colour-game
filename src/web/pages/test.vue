<template>
    <div class="text-white">
        <button @click="refresh">Refresh</button>
        {{ responseData?.accessToken }}

        <!-- Form -->
        <div class="mt-10 sm:mx-auto sm:w-full sm:max-w-sm">
            <form class="space-y-6" action="#" method="POST">
                <div>
                    <label
                        for="email"
                        class="block text-sm font-medium leading-6 text-gray-900 text-white"
                        >Email address</label
                    >
                    <div class="mt-2">
                        <input
                            id="email"
                            name="email"
                            type="email"
                            autocomplete="email"
                            required
                            class="block w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
                        />
                    </div>
                </div>

                <div>
                    <div class="flex items-center justify-between">
                        <label
                            for="password"
                            class="block text-sm font-medium leading-6 text-gray-900 text-white"
                            >Password</label
                        >
                        <div class="text-sm">
                            <a
                                href="#"
                                class="font-semibold text-indigo-600 hover:text-indigo-500"
                                >Forgot password?</a
                            >
                        </div>
                    </div>
                    <div class="mt-2">
                        <input
                            id="password"
                            name="password"
                            type="password"
                            autocomplete="current-password"
                            required
                            class="block w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
                        />
                    </div>
                </div>

                <div>
                    <button
                        type="submit"
                        @click="login"
                        class="flex w-full justify-center rounded-md bg-indigo-600 px-3 py-1.5 text-sm font-semibold leading-6 text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600"
                    >
                        Sign in
                    </button>
                </div>
            </form>
        </div>
    </div>
</template>
<script setup lang="ts">
const headers = useRequestHeaders(['.AspNetCore.Identity.Application'])
const { data: responseData, refresh: login } = await useLazyFetch(
    'http://localhost:5230/login?useCookies=false',
    {
        headers,
        method: 'post',
        body: {
            email: 'user',
            password: 'Password123!',
        },
        onResponse({ request, response, options }) {
            // Process the response data
            console.log(response._data.accessToken)
            localStorage.setItem('token', response._data.accessToken)
        },
    }
)
const { data, pending, error, refresh } = await useLazyFetch(
    `http://localhost:5230/test`,
    {
        headers: {
            'Access-Control-Allow-Origin': '*',
            'Access-Control-Allow-Headers': '*',
            Authorization: `Bearer ${localStorage.getItem('token')}`,
            afg: 'asfd',
        },
    }
)
definePageMeta({
    layout: 'default',
})
</script>

<style scoped>
.menu {
    font-family: 'Fira Code', monospace;
    font-weight: bold;
}
</style>
