<template>
    <DashGrid @refreshed-click="refresh">
        <div v-if="error">Error</div>
        <div v-else-if="pending"><GridPending /></div>
        <div v-else>
            <ClientOnly>
                <p class="mb-6 text-4xl font-bold text-[#50FA7B]">Calendar</p>
                <ul class="lg:text-3xl">
                    <li
                        class="mb-4 flex gap-4"
                        v-for="$event in data.events.items?.filter(
                            (x) =>
                                x.summary !== 'Dupilumab' &&
                                x.summary !== 'Baz Birthday'
                        )"
                    >
                        <span class="w-80 border-r-4 border-[#50FA7B] pr-2">{{
                            formatDate($event.start)
                        }}</span>
                        <span>{{ $event.summary }}</span>
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
    return format(parseISO(d.dateTime), 'EEE, dd MMM h:mm a')
}
</script>
