<template>
    <DashGrid @refreshed-click="refresh">
        <div v-if="error">Error</div>
        <div v-else-if="pending">
            <GridPending />
        </div>
        <div v-else>
            <ClientOnly>
                <p class="flex items-center text-9xl">
                    <!-- Weather Code -->
                    <span v-if="data.now.values.weatherCode === 1000"
                        ><img
                            alt="Clear"
                            src="https://files.readme.io/48b265b-weather_icon_small_ic_clear3x.png"
                    /></span>
                    <span v-else-if="data.now.values.weatherCode === 1001"
                        ><img
                            alt="Clear"
                            src="https://files.readme.io/a31c783-weather_icon_small_ic_clear_night3x.png"
                    /></span>
                    <span v-else-if="data.now.values.weatherCode === 1100"
                        ><img
                            alt="Clear"
                            src="https://files.readme.io/c3d2596-weather_icon_small_ic_mostly_clear3x.png"
                    /></span>
                    <span v-else-if="data.now.values.weatherCode === 11001"
                        ><img
                            alt="Clear"
                            src="https://files.readme.io/28c3d6e-weather_icon_small_ic_mostly_clear_night3x.png"
                    /></span>
                    <span v-else-if="data.now.values.weatherCode === 1101"
                        ><img
                            alt="Clear"
                            src="https://files.readme.io/6af2ec5-weather_icon_small_ic_partly_cloudy_night3x.png"
                    /></span>
                    <!-- Temp -->
                    <span class="ml-4">
                        {{ Math.round(data.now.values.temperature) }}°
                    </span>
                </p>
                <div class="flex gap-3 text-2xl">
                    <div class="text-[#f87359]">
                        Humidity: {{ data.now.values.humidity }}%
                    </div>
                    <div class="text-[#4dceb0]">
                        Rain Intensity: {{ data.now.values.rainIntensity }}mm/hr
                    </div>
                    <div class="text-[#fceb3c]">
                        UV: {{ data.now.values.uvIndex }}
                    </div>
                    <div class="text-blue-500">
                        Wind Speed:
                        {{ Math.round(data.now.values.windSpeed * 3.6) }}km/s
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
