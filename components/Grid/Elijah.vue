<template>
    <DashGrid @refreshed-click="refresh">
        <ClientOnly>
            <div v-if="error">Error</div>
            <div v-else-if="pending"><GridPending /></div>
            <div v-else>
                <p class="mb-6 font-bold text-orange-400 lg:text-4xl">Elijah</p>
                <p>
                    {{ data.text }}
                </p>
            </div>
        </ClientOnly>
    </DashGrid>
</template>

<script lang="ts" setup>
const { data, pending, error, refresh } = await useFetch(`/api/elijah`)
</script>
