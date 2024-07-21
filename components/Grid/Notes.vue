<template>
    <DashGrid @refreshed-click="refresh">
        <div v-if="error">Error</div>
        <div v-else-if="pending"><GridPending /></div>
        <div v-else>
            <ClientOnly>
                <h2 class="text-my-aqua mb-6 text-4xl font-bold">🗒️Notes</h2>
                <p>{{ data.text }}</p>
            </ClientOnly>
        </div>
    </DashGrid>
</template>

<script lang="ts" setup>
const { data, error, pending, refresh } = await useFetch(`/api/note`)
onMounted(() => {
    setInterval(refresh, Milliseconds.AsMinutes(15))
})
</script>
