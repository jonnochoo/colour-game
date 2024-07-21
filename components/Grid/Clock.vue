<template>
    <DashGrid>
        <ClientOnly>
            <p class="mb-4 text-center font-[lexend] lg:text-8xl">
                {{ currentTime }}
            </p>
            <p class="text-center lg:text-5xl">{{ currentDate }}</p>
        </ClientOnly>
    </DashGrid>
</template>

<script lang="ts" setup>
import { format } from 'date-fns'
const currentDate = ref('')
const currentTime = ref('')

const setCurrentDateAndTime = () => {
    currentTime.value = format(new Date(), 'h:mm:ss aa')
    currentDate.value = format(new Date(), 'EEEE do MMMM')
}
onMounted(() => {
    setCurrentDateAndTime()
    const intervalId = setInterval(
        setCurrentDateAndTime,
        Milliseconds.AsSeconds(1)
    )
})
</script>
