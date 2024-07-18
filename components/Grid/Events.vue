<template>
    <DashGrid>
        <p class="mb-6 text-4xl font-bold text-[#50FA7B]">Calendar</p>
        <ul class="lg:text-3xl">
            <li class="mb-4 flex gap-4" v-for="$event in events">
                <span class="w-40 border-r-4 border-[#50FA7B] pr-2">{{
                    $event.date
                }}</span>
                <span>{{ $event.name }}</span>
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
    { name: 'Mission Team Meeting', date: 'Sat 20th ' },
    { name: 'Cambodia Info Session', date: 'Sun 21st' },
    { name: 'Roy Kim Party (Abi)', date: 'Sun 28th' },
])
</script>
