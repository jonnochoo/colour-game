<template>
    <DashGrid>
        <p class="mb-6 text-4xl font-bold text-[#f87359]">Dinners</p>
        <ul class="lg:text-4xl">
            <li class="mb-4 flex" v-for="meal in data.meals">
                <span
                    class="w-20 border-r-4 border-green-400 pr-2 font-bold"
                    :class="{
                        'border-red-500':
                            meal.dayOfWeek === 'Sun' ||
                            meal.dayOfWeek === 'Sat',
                    }"
                    >{{ meal.dayOfWeek }}</span
                >
                <span class="pl-4"> {{ meal.name }}</span>
            </li>
        </ul>
    </DashGrid>
</template>

<script lang="ts" setup>
const { data, error } = await useFetch(`/api/trello`)
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
