<template>
    <header class="flex items-center">
        <div>
            <h1 class="font-[lexend] text-2xl text-white lg:text-6xl">
                🏏 The Choo Family Dashboard
            </h1>
        </div>
    </header>
    <div class="mt-8 grid gap-6 lg:grid-cols-3">
        <GridBible />
        <GridClock />
        <!-- <GridWeather /> -->
        <GridNextMeal />
        <GridMeals />
        <GridEvents />
        <GridGoals />
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
