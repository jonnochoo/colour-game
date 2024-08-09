<template>
    <DashGrid @refreshed-click="refresh">
        <ClientOnly>
            <h2 class="mb-6 text-4xl font-bold text-blue-400">
                Countdown until Year 4 camp
            </h2>
            <p>
                <span class="text-7xl">{{ daysUntil }} days</span>
            </p>
        </ClientOnly>
    </DashGrid>
</template>

<script lang="ts" setup>
import { differenceInCalendarDays } from 'date-fns'
const countdownDate = Date.parse('2024-08-21')
const now = ref(new Date())
const daysUntil = computed(() => {
    return differenceInCalendarDays(countdownDate, now.value)
})

const refresh = () => {
    now.value = new Date()
}
onMounted(() => {
    setInterval(refresh, Milliseconds.FromHours(1))
})
</script>
