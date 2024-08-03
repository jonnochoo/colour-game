<template>
    <DashGrid @refreshedClick="refresh">
        <div v-if="error">{{ error }}</div>
        <div v-else-if="pending"><GridPending /></div>
        <div v-else>
            <ClientOnly>
                <p class="mb-6 text-4xl font-bold text-[#f87359]">🍜 Dinners</p>
                <ul class="lg:text-4xl">
                    <li class="mb-4 flex gap-4" v-for="meal in data">
                        <span
                            class="w-24 border-r-4 pr-2"
                            :class="{
                                'border-pink-500':
                                    meal.dayOfWeek === 0 ||
                                    meal.dayOfWeek === 6,
                                'border-purple-500':
                                    meal.dayOfWeek !== 0 &&
                                    meal.dayOfWeek !== 6,
                            }"
                            >{{ meal.dayOfWeek }}</span
                        >
                        <span> {{ meal.name }}</span>
                    </li>
                </ul>
            </ClientOnly>
        </div>
    </DashGrid>
</template>

<script lang="ts" setup>
const config = useRuntimeConfig()
const { data, error, refresh, pending } = await useFetch(`/trello/meals`, {
    baseURL: config.public.baseUrl,
})

onMounted(() => {
    setInterval(refresh, Milliseconds.FromMinutes(15))
})
</script>
