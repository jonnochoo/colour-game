<template>
    <DashGrid @refreshed-click="refresh">
        <ClientOnly>
            <h2 class="mb-6 text-4xl font-bold" :class="props.color">
                {{ evt?.event_name }} ({{ formatted.date }})
            </h2>
            <p>
                <span class="text-7xl">{{ formatted.daysUntil }} days</span>
            </p>
        </ClientOnly>
    </DashGrid>
</template>

<script lang="ts" setup>
const props = defineProps<{
    color: string
    number: number
}>()
const now = ref(new Date())
const { data, pending, error } = await useLazyFetch(
    `https://jonno-pi.tail88a240.ts.net:8443/api/collections/countdown_events/records?sort=date&filter=(date%3E%27${format(now.value, 'yyyy-MM-dd')}%27)&perPage=1&page=${props.number}`
)
import { differenceInCalendarDays, format, parseISO } from 'date-fns'

const evt = computed(() => {
    return data.value?.items[0] || null
})
const formatted = computed(() => {
    const parsedDate = evt.value ? parseISO(evt.value.date) : new Date()
    return {
        date: format(parsedDate, 'E, do MMM'),
        daysUntil: differenceInCalendarDays(parsedDate, now.value),
    }
})
const refresh = () => {
    now.value = new Date()
}
onMounted(() => {
    setInterval(refresh, Milliseconds.FromHours(1))
})
</script>
