<template>
    <DashGrid @refreshed-click="refresh">
        <div v-if="error">Error</div>
        <div v-else-if="pending">
            <GridPending />
        </div>
        <div v-else>
            <ClientOnly>
                <p class="text-9xl">
                    <div class="flex">
                    <!-- Weather Code -->
                    <div class="w-18">
                        <span v-if="data.weatherCode === 1000"
                            ><img
                                alt="Clear"
                                src="https://files.readme.io/48b265b-weather_icon_small_ic_clear3x.png"
                        /></span>
                        <span v-else-if="data.weatherCode === 1001"
                            ><img
                                alt="Clear"
                                src="https://files.readme.io/a31c783-weather_icon_small_ic_clear_night3x.png"
                        /></span>
                        <span v-else-if="data.weatherCode === 1100"
                            ><img
                                alt="Clear"
                                src="https://files.readme.io/c3d2596-weather_icon_small_ic_mostly_clear3x.png"
                        /></span>
                        <span v-else-if="data.weatherCode === 11001"
                            ><img
                                alt="Clear"
                                src="https://files.readme.io/28c3d6e-weather_icon_small_ic_mostly_clear_night3x.png"
                        /></span>
                        <span v-else-if="data.weatherCode === 1101"
                            ><img
                                alt="Clear"
                                src="https://files.readme.io/6af2ec5-weather_icon_small_ic_partly_cloudy_night3x.png"
                        /></span>
                    </div>
                    <!-- Temp -->
                    <span class="ml-4">
                        {{ Math.round(data.temperatureCurrent) }}°
                    </span>
                    <div class="text-2xl flex-grow text-right">                        
                        <p>Min: {{ Math.round(data.temperatureMin) }}°
                        Max: {{ Math.round(data.temperatureMax) }}°</p>
                        <div>
                        Sunrise:  {{ format(parseISO(data.sunriseTime), 'h:mm a') }}
                        </div>
                        <div>
                        Sunset:   {{ format(parseISO(data.sunsetTime), 'h:mm a') }}
                    </div>
                    </div></div>
                </p>
                <div class="flex gap-3 text-2xl">
                    <div class="text-[#f87359]">
                        Humidity: {{ data.humidityCurrent }}%
                    </div>
                    <div class="text-[#4dceb0]">
                        Rain: {{ data.rainIntensity }}mm/hr
                    </div>
                    <div class="text-[#fceb3c]">
                        UV: {{ data.uvIndexConcern }}
                    </div>
                    <div class="text-blue-500">
                        Wind:
                        {{ data.windspeedCurrent }}
                    </div>
                </div>
            </ClientOnly>
        </div>
    </DashGrid>
</template>

<script lang="ts" setup>
import { format, parseISO } from 'date-fns'
const { data, pending, error, refresh } = await useFetch(
    `https://jonno-pi.tail88a240.ts.net/weather`
)

onMounted(() => {
    setInterval(refresh, Milliseconds.FromMinutes(15))
})
</script>
