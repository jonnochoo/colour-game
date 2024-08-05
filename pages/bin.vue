<template>
    <ClientOnly>
        <div class="text-center text-white">
            <h2 class="mb-4 text-5xl">Which Bin Should We Put Out?</h2>
            <div>{{ data.type }}</div>
            <div>{{ data?.collectionDate }}</div>
        </div>
    </ClientOnly>
</template>

<script setup lang="ts">
import { format, parse, differenceInDays } from 'date-fns'

const { data, error } = await useFetch(
    'https://apps.thehills.nsw.gov.au/seamlessproxy/api/services/263787',
    {
        transform: (data) => {
            const organics = data.find((x) => x.Name === 'Garden Organics')
            const recycling = data.find((x) => x.Name === 'Recycling')
            const organicsNextCollectionDay = parse(
                organics.CollectionDays[0].substring(0, 10),
                'yyyy-MM-dd',
                new Date()
            )
            const recyclingNextCollectionDay = parse(
                recycling.CollectionDays[0].substring(0, 10),
                'yyyy-MM-dd',
                new Date()
            )
            if (organicsNextCollectionDay < recyclingNextCollectionDay) {
                return {
                    image: '/organics.png',
                    type: 'Green Bin',
                    collectionDate: format(
                        organicsNextCollectionDay,
                        'eeee do MMMM yyyy'
                    ),
                }
            } else {
                return {
                    image: '/recycling.png',
                    type: 'Yellow Bin',
                    collectionDate: format(
                        recyclingNextCollectionDay,
                        'eeee do MMMM yyyy'
                    ),
                }
            }
        },
    }
)
</script>
