<template>
    <h1 class="font-[lexend] text-6xl text-white">
        🏏 The Choo Family Dashboard
    </h1>
    <div class="mt-8 grid gap-6 lg:grid-cols-3">
        <BibleDashGrid />
        <ClockDashGrid />
        <WeatherDashGrid />
        <NextMealDashGrid />
        <MealsDashGrid />
        <EventsDashGrid />
        <GoalsDashGrid />
        <GridElijah />
        <GridAbigail />
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
