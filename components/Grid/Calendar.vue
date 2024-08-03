<template>
    <DashGrid @refreshed-click="refresh">
        <div v-if="error">{{ error }}</div>
        <div v-else-if="pending"><GridPending /></div>
        <div v-else>
            <ClientOnly>
                <p class="mb-6 text-4xl font-bold text-my-green">Calendar</p>
                <ul class="lg:text-3xl">
                    <li
                        class="mb-4 flex gap-6"
                        v-for="$event in data
                            ?.filter(
                                (x) =>
                                    x.summary !== 'SCHOOL HOLIDAYS' &&
                                    x.summary !== 'No M&D' &&
                                    x.summary !== 'take off this day!' &&
                                    x.summary !== 'Grocery shopping' &&
                                    x.summary !== 'Baz Birthday'
                            )
                            .slice(0, 8)"
                    >
                        <span
                            class="w-[270px] border-r-4"
                            :class="{
                                'border-pink-500': $event.isWeekend,
                                'border-purple-500': !$event.isWeekend,
                            }"
                            >{{ formatDate($event) }}</span
                        >
                        <span class="w-[440px] truncate">{{
                            $event.summary
                        }}</span>
                    </li>
                </ul></ClientOnly
            >
        </div>
    </DashGrid>
</template>

<script lang="ts" setup>
import { format, parseISO } from 'date-fns'
const config = useRuntimeConfig()
const { data, pending, error, refresh } = await useFetch(`google-calendar`, {
    baseURL: config.public.baseUrl,
})

const formatDate = ($event) => {
    return $event.isAllDay
        ? format(parseISO($event.startDateOffset), 'EEE, dd MMM')
        : format(parseISO($event.startDateOffset), 'EEE, dd MMM H:mm')
}

onMounted(() => {
    setInterval(refresh, Milliseconds.FromMinutes(5))
})
</script>
