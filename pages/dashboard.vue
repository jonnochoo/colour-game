<template>
    <h1 class="font-[lexend] text-5xl text-white">🏏 Choo Family Dashboard</h1>
    <div class="mt-8 grid grid-cols-3 gap-6">
        <BibleDashGrid />
        <ClockDashGrid />
        <WeatherDashGrid />
        <NextMealDashGrid />
        <MealsDashGrid />
        <EventsDashGrid />
        <GoalsDashGrid />
    </div>
</template>

<script setup lang="ts">
definePageMeta({
    layout: 'dashboard',
})
</script>
<style>
body {
    background-color: #1b1428;
}
</style>
