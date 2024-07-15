<template>
    <h1 class="font-[lexend] text-5xl text-white">🏏 Choo Family Dashboard</h1>
    <div class="mt-8 grid grid-cols-3 gap-6">
        <BibleDashGrid />
        <ClockDashGrid />
        <DashGrid
            class="s drop-shadow-orange-100 text sky-200 rounded-2xl bg-[#3e2f5b] p-6 font-[lexend] text-white"
        >
            The current temp
            <p class="text-8xl">14°</p>
        </DashGrid>
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
