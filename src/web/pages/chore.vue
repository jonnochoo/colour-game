<template>
    <header class="flex p-4 lg:mt-12 lg:px-32">
        <h1 class="flex-grow text-4xl font-extrabold text-white">
            <RouterLink to="dashboard">🏏</RouterLink>Family Chores
        </h1>
        <div>
            <select class="rounded-md p-2" v-model="category">
                <option value="morning">☀️Morning</option>
                <option value="afternoon">😎Afternoon</option>
                <option value="evening">🌚Evening</option>
            </select>
        </div>
    </header>
    <div class="grid grid-cols-1 gap-4 p-6 pl-4 lg:grid-cols-2 lg:px-32">
        <ChoreList :data="data[0]" :category="category" />
        <ChoreList :data="data[1]" :category="category" />
    </div>
</template>

<script setup lang="ts">
import type { ChoreList } from '~/types'
import { getHours } from 'date-fns'
const { data, refresh } = await useLazyFetch<ChoreList[]>('/api/chores')
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
