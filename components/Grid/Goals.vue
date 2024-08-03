<template>
    <DashGrid @refreshed-click="refresh">
        <ClientOnly>
            <div v-if="error">{{ error }}}</div>
            <div v-else-if="pending"><GridPending /></div>
            <div v-else>
                <p class="mb-4 text-4xl font-bold text-[#fceb3c]">To Do List</p>
                <ul class="lg:text-3xl">
                    <li class="mb-3" v-for="card in data">
                        {{ card.name }}
                    </li>
                </ul>
            </div>
        </ClientOnly>
    </DashGrid>
</template>

<script lang="ts" setup>
const config = useRuntimeConfig()
const { data, pending, error, refresh } = await useFetch(`/trello/meals`, {
    baseURL: config.public.baseUrl,
})

onMounted(() => {
    setInterval(refresh, Milliseconds.FromMinutes(15))
})
</script>
