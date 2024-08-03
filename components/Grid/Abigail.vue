<template>
    <DashGrid @refreshed-click="refresh">
        <ClientOnly>
            <div v-if="error">{{ error }}</div>
            <div v-else-if="pending"><GridPending /></div>
            <div v-else>
                <p class="mb-6 font-bold text-violet-500 lg:text-4xl">
                    Abigail
                </p>
                <p>
                    {{ data.name }}
                </p>
            </div>
        </ClientOnly>
    </DashGrid>
</template>

<script lang="ts" setup>
const config = useRuntimeConfig()
const { data, pending, error, refresh } = await useFetch(`/trello/abigail`, {
    baseURL: config.public.baseUrl,
})
onMounted(() => {
    setInterval(refresh, Milliseconds.FromMinutes(15))
})
</script>
