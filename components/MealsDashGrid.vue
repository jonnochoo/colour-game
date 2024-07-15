<template>
    <DashGrid>
        <p class="mb-6 text-3xl font-bold text-[#f87359]">Meals</p>
        <ul class="text-2xl">
            <li
                class="mb-4 border-l-4 border-green-500 pl-4"
                v-for="meal in meals"
                :class="{ 'line-through': meal.isCompleted }"
            >
                <span clas="font-bold"
                    >{{ meal.dayOfWeek.substring(0, 3) }}:
                </span>
                {{ meal.name }}
            </li>
        </ul>
    </DashGrid>
</template>

<script lang="ts" setup>
type meal = {
    name: string
    dayOfWeek: string
}
const meals = ref<meal[]>([
    { name: 'Steamed Basa', dayOfWeek: 'Tuesday' },
    { name: 'Sushi', dayOfWeek: 'Wednesday' },
    { name: 'Japanese Curry', dayOfWeek: 'Thursday' },
    { name: 'Corn Soup', dayOfWeek: 'Friday' },
    { name: 'Karage Chicken', dayOfWeek: 'Saturday' },
    { name: 'Chicken Schnitzel', dayOfWeek: 'Sunday' },
    { name: 'Soup Noodles', dayOfWeek: 'Monday' },
])
</script>
