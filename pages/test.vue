<template>
    <div class="text-white">
        <ClientOnly> {{ data }} {{ error }} </ClientOnly>
        <button @click="refreshLogin">Log</button>
        <button @click="refresh">refrse</button>
    </div>
</template>
<script setup lang="ts">
const headers = useRequestHeaders(['cookie'])
const { data, pending, error, refresh } = await useFetch(
    `http://localhost:5230/test1`,
    { headers }
)
const { data: responseData, refresh: refreshLogin } = await useFetch(
    'http://localhost:5230/login?useCookies=true',
    {
        method: 'post',
        body: {
            email: 'user',
            password: 'Password123!',
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
