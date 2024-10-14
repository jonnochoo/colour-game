<template>
    <form>
        <input class="text rounded p-2" />
    </form>
    <div class="text-white" v-for="chore in data">
        {{ chore.summary }}
    </div>
</template>

<script setup lang="ts">
import type { ChoreList } from '~/types'
import { getHours } from 'date-fns'
const config = useRuntimeConfig()
const { data, refresh } = await useFetch<ChoreList[]>('/chore/elijah', {
    baseURL: config.public.baseUrl,
})
const category = ref('morning')
definePageMeta({
    layout: 'dashboard',
})
onMounted(() => {
    // setCategoryBasedOnTimeOfDay()
    // setInterval(setCategoryBasedOnTimeOfDay, 1000)
})

function setCategoryBasedOnTimeOfDay() {
    var hour = getHours(new Date())
    if (hour > 0 && hour < 12) {
        category.value = 'morning'
    } else if (hour >= 12 && hour < 5) {
        category.value = 'afternoon'
    } else {
        category.value = 'evening'
    }
}
</script>

<style>
body {
    background-color: #1b1428;
}
</style>
