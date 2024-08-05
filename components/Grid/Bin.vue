<template>
    <ClientOnly>
        <div class="mr-4 mt-5 text-center text-xl text-white">
            <div>
                <span v-if="data?.type == 'Yellow Bin'">🟡</span>
                <span v-else="">🟢</span>
                This week is {{ data.type }}
            </div>
        </div>
    </ClientOnly>
</template>

<script setup lang="ts">
import { format, parseISO } from 'date-fns'

const { data, refresh, error } = await useFetch(
    'https://apps.thehills.nsw.gov.au/seamlessproxy/api/services/263787',
    {
        transform: (data) => {
            const organics = data.find((x) => x.Name === 'Garden Organics')
            const recycling = data.find((x) => x.Name === 'Recycling')
            const organicsNextCollectionDay = parseISO(
                organics.CollectionDays[0]
            )
            const recyclingNextCollectionDay = parseISO(
                recycling.CollectionDays[0]
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

onMounted(() => {
    setInterval(refresh, Milliseconds.FromHours(3))
})
</script>
