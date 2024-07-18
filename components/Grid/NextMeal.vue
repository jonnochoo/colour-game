<template>
    <DashGrid @refreshed-click="refresh">
        <div v-if="error">Error</div>
        <div v-else-if="pending"><GridPending /></div>
        <div v-else>
            <h2 class="mb-6 text-4xl font-bold text-[#f87359]">Next Meal</h2>
            <p class="lg:text-6xl">{{ data.meals[0]?.name }}</p>
        </div>
    </DashGrid>
</template>

<script lang="ts" setup>
const { data, error, pending, refresh } = await useFetch(`/api/trello`)
</script>
