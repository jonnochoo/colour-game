<template>
    <DashGrid @refreshed-click="refresh">
        <div v-if="error">Error</div>
        <div v-else-if="pending">
            <GridPending />
        </div>
        <div v-else>
            <ClientOnly>
                <p class="flex items-center text-9xl">
                    <span v-if="data.now.values.weatherCode === 1000"
                        ><img
                            alt="Clear"
                            src="https://files.readme.io/48b265b-weather_icon_small_ic_clear3x.png"
                    /></span>
                    <span class="ml-4">
                        {{ Math.round(data.now.values.temperature) }}°
                    </span>
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
            </ClientOnly>
        </div>
    </DashGrid>
</template>

<script lang="ts" setup>
const { data, pending, error, refresh } = await useFetch(`/api/weather`)

onMounted(() => {
    setInterval(
        () => {
            refresh()
        },
        15 * 1000 * 60
    )
})
</script>
