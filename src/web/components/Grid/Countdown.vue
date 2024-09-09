<template>
    <DashGrid @refreshed-click="refresh">
        <ClientOnly>
            <h2 class="mb-6 text-4xl font-bold" :class="props.color">
                {{ props.title }} ({{ day }})
            </h2>
            <p>
                <span class="text-7xl">{{ daysUntil }} days</span>
            </p>
        </ClientOnly>
    </DashGrid>
</template>

<script lang="ts" setup>
import { differenceInCalendarDays, format } from 'date-fns'

const props = defineProps<{
    countdownDate: any
    title: string
    color: string
}>()
const now = ref(new Date())
const daysUntil = computed(() => {
    return differenceInCalendarDays(props.countdownDate, now.value)
})
const day = computed(() => {
    return format(props.countdownDate, 'E, do MMM')
})

const refresh = () => {
    now.value = new Date()
}
onMounted(() => {
    setInterval(refresh, Milliseconds.FromHours(1))
})
</script>
