<template>
    <DashGrid @refreshed-click="refresh">
        <div v-if="error">{{ error }}</div>
        <div v-else-if="pending"><GridPending /></div>
        <div v-else>
            <ClientOnly>
                <p class="text-my-green mb-6 text-4xl font-bold">Calendar</p>
                <ul class="lg:text-3xl">
                    <li
                        class="mb-4 flex gap-6"
                        v-for="$event in data.events
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
                                'border-pink-500':
                                    formatDate($event.start).includes('Sat') ||
                                    formatDate($event.start).includes('Sun'),
                                'border-purple-500':
                                    !formatDate($event.start).includes('Sat') &&
                                    !formatDate($event.start).includes('Sun') &&
                                    !formatDate($event.start).includes(
                                        format(new Date(), 'EEE')
                                    ),
                                'border-green-500': formatDate(
                                    $event.start
                                ).includes(format(new Date(), 'EEE')),
                            }"
                            >{{ formatDate($event.start) }}</span
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
import { format, parseISO, parse } from 'date-fns'
const { data, pending, error, refresh } = await useFetch(`/api/calendar`)

const formatDate = (d) => {
    if (d.date) {
        return format(parse(d.date, 'yyyy-MM-dd', new Date()), 'EEE, dd MMM')
    }
    return format(parseISO(d.dateTime), 'EEE, dd MMM H:mm')
}

onMounted(() => {
    setInterval(refresh, Milliseconds.FromMinutes(5))
})
</script>
