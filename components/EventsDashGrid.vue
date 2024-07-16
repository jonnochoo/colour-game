<template>
    <DashGrid>
        <p class="mb-6 text-4xl font-bold text-[#34a853]">Events</p>
        <ul class="text-3xl">
            <li
                class="mb-4 border-l-4 border-green-500 pl-4"
                v-for="$event in events"
            >
                {{ $event.date }} - {{ $event.name }}
            </li>
        </ul>
    </DashGrid>
</template>

<script lang="ts" setup>
type $event = {
    name: string
    date: string
}
const events = ref<$event[]>([
    { name: 'Physio', date: '8:30am Wed 16th' },
    { name: 'Dr Chapman - Telehealth', date: '11:30am Wed 16th' },
])
</script>
