<template>
    <DashGrid>
        <p class="text-9xl">{{ Math.round(data.now.values.temperature) }}°</p>
        <div class="flex gap-3 text-2xl">
            <div class="text-[#f87359]">
                Humidity: {{ data.now.values.humidity }}
            </div>
            <div class="text-[#4dceb0]">
                Rain Intensity: {{ data.now.values.rainIntensity }}
            </div>
            <div class="text-[#fceb3c]">UV: {{ data.now.values.uvIndex }}</div>
        </div>
    </DashGrid>
</template>

<script lang="ts" setup>
const { data, pending, error, refresh } = await useFetch(`/api/weather`)
</script>
