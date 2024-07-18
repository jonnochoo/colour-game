<template>
    <DashGrid @refreshed-click="refresh">
        <div v-if="error">Error</div>
        <div v-if="pending">
            <span class="h-10 bg-gray-300"></span>
        </div>
        <div v-else>
            <p class="text-9xl">
                {{ Math.round(data.now.values.temperature) }}°
            </p>
            <div class="flex gap-3 text-2xl">
                <div class="text-[#f87359]">
                    Humidity: {{ data.now.values.humidity }}
                </div>
                <div class="text-[#4dceb0]">
                    Rain Intensity: {{ data.now.values.rainIntensity }}
                </div>
                <div class="text-[#fceb3c]">
                    UV: {{ data.now.values.uvIndex }}
                </div>
            </div>
        </div>
    </DashGrid>
</template>

<script lang="ts" setup>
const { data, pending, error, refresh } = await useFetch(`/api/weather`)

onMounted(() => {
    // setInterval(() => {
    //     refresh()
    // }, 10 * 1000)
})
</script>
