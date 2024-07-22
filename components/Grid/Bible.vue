<template>
    <DashGrid @refreshed-click="refresh" class="desktop:col-span-3">
        <div v-if="error">Error</div>
        <div v-else-if="pending"><GridPending /></div>
        <div v-else>
            <ClientOnly>
                <p
                    v-if="error"
                    class="border-l-4 border-[#ffd38f] pl-4 text-2xl lg:text-4xl"
                >
                    For in Christ all the fullness of the Deity lives in bodily
                    form, and in Christ you have been brought to fullness. He is
                    the head over every power and authority.
                    <span class="mt-4 block font-bold">Colossians 2:9-10</span>
                </p>
                <p
                    v-else
                    class="border-l-4 border-[#ffd38f] pl-4 text-2xl lg:text-4xl"
                >
                    {{ data.text }}
                    <span class="mt-4 block font-bold">{{ data.verse }}</span>
                </p>
            </ClientOnly>
        </div>
    </DashGrid>
</template>

<script lang="ts" setup>
const { data, pending, error, refresh } = await useFetch(`/api/bible`)

onMounted(() => {
    setInterval(refresh, Milliseconds.FromMinutes(30))
})
</script>
