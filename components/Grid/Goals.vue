<template>
    <DashGrid>
        <p class="mb-4 text-4xl font-bold text-[#fceb3c]">Goals</p>
        <ul class="lg:text-3xl">
            <li
                class="mb-2 ml-6 list-disc"
                v-for="goal in goals"
                :class="{ 'line-through': goal.isCompleted }"
            >
                {{ goal.name }}
            </li>
        </ul>
    </DashGrid>
</template>

<script lang="ts" setup>
type goal = {
    name: string
    isCompleted: boolean
}
const goals = ref<goal[]>([
    { name: 'Organise Arborist', isCompleted: false },
    { name: 'Start next steps for Cambodia', isCompleted: false },
    { name: 'Visit Sydney Zoo', isCompleted: true },
    { name: "Celebrate Abi' party", isCompleted: true },
])
</script>
