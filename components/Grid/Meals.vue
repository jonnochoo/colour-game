<template>
    <DashGrid @refreshedClick="refresh">
        <div v-if="error">{{ error }}</div>
        <div v-else-if="pending"><GridPending /></div>
        <div v-else>
            <ClientOnly>
                <p class="mb-6 text-4xl font-bold text-[#f87359]">🍜 Dinners</p>
                <ul class="lg:text-4xl">
                    <li class="mb-4 flex gap-4" v-for="meal in data.meals">
                        <span
                            class="w-24 border-r-4 pr-2"
                            :class="{
                                'border-my-green':
                                    meal.dayOfWeek === 'Sun' ||
                                    meal.dayOfWeek === 'Sat',
                                'border-purple-500':
                                    meal.dayOfWeek !== 'Sun' &&
                                    meal.dayOfWeek !== 'Sat',
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
const { data, error, refresh, pending } = await useFetch(`/api/trello`)
type meal = {
    name: string
    dayOfWeek: string
}
const meals = ref<meal[]>([
    { name: 'Sushi', dayOfWeek: 'Wednesday' },
    { name: 'Japanese Curry', dayOfWeek: 'Thursday' },
    { name: 'Corn Soup', dayOfWeek: 'Friday' },
    { name: 'Karage Chicken', dayOfWeek: 'Saturday' },
    { name: 'Chicken Schnitzel', dayOfWeek: 'Sunday' },
    { name: 'Soup Noodles', dayOfWeek: 'Monday' },
    // { name: '', dayOfWeek: 'Tuesday' },
])
</script>
