<template>
    <DashGrid @refreshed-click="refresh">
        <div v-if="pending"><GridPending /></div>
        <div v-else-if="error">{{ error }}</div>
        <div v-else>
            <ClientOnly>
                <h2 class="mb-6 text-4xl font-bold text-my-aqua">
                    Think About...
                </h2>
                <p>{{ data.name }}</p>
            </ClientOnly>
        </div>
    </DashGrid>
</template>

<script lang="ts" setup>
import { format, parseISO } from 'date-fns'
const config = useRuntimeConfig()
const { data, pending, error, refresh } = await useLazyFetch(`trello/think`, {
    baseURL: config.public.baseUrl,
})

onMounted(() => {
    setInterval(refresh, Milliseconds.FromMinutes(15))
})
</script>
