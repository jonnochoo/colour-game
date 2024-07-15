<template>
    <DashGrid>
        <p class="mb-6 text-3xl font-bold text-[#34a853]">Events</p>
        <ul class="text-2xl">
            <li
                class="mb-4 border-l-4 border-green-500 pl-4"
                v-for="$event in events"
            >
                {{ $event.name }}
            </li>
        </ul>
    </DashGrid>
</template>

<script lang="ts" setup>
type $event = {
    name: string
    date: string
}
const events = ref<$event[]>([{ name: 'Physio', date: 'Tuesday' }])
</script>
