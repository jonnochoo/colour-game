<template>
    <DashGrid @refreshedClick="refresh">
        <ClientOnly>
            <div v-if="error">Error</div>
            <div v-else-if="pending"><GridPending /></div>
            <div v-else>
                <p class="mb-6 font-bold text-[#f87359] lg:text-4xl">
                    {{ data?.info[0].name?.common }}
                </p>
                <div class="gap-3 text-2xl">
                    <span class="text-[#fceb3c]"> Capital: </span>
                    <span> {{ data?.info[0].capital[0] }}</span>
                </div>
                <div>
                    <span class="text-[#4dceb0]"> Population: </span>
                    <span>
                        {{ data?.info[0].population.toLocaleString() }}</span
                    >
                </div>

                <div>
                    <span class="text-[#f87359]"> Languages: </span>
                    <span>
                        {{
                            Object.values(data?.info[0].languages).join(', ')
                        }}</span
                    >
                </div>
            </div></ClientOnly
        >
    </DashGrid>
</template>

<script lang="ts" setup>
const { data, pending, error, refresh } = await useLazyFetch(`/api/country`)
</script>
