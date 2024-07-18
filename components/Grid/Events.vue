<template>
    <DashGrid>
        <p class="mb-6 text-4xl font-bold text-[#50FA7B]">Events</p>
        <ul class="lg:text-3xl">
            <li class="mb-4 flex gap-4" v-for="$event in events">
                <span class="w-64 border-r-4 border-[#50FA7B] pr-2 font-bold">{{
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
    { name: 'Mission Team Meeting', date: '10am Sat 20th' },
    { name: 'Cambodia Info Session', date: '11am Sun 21st' },
    { name: 'Roy Kim Party (Abi)', date: '1:45pm Sun 28th' },
])
</script>
