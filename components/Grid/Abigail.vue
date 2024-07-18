<template>
    <DashGrid @refreshed-click="refresh">
        <ClientOnly>
            <div v-if="error">Error</div>
            <div v-else-if="pending"><GridPending /></div>
            <div v-else>
                <p class="mb-6 font-bold text-[#BD93F9] lg:text-4xl">Abigail</p>
                <p>
                    {{ data.text }}
                </p>
            </div>
        </ClientOnly>
    </DashGrid>
</template>

<script lang="ts" setup>
const { data, pending, error, refresh } = await useFetch(`/api/abigail`)
</script>
