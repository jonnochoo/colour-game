<template>
    <DashGrid class="lg:col-span-3">
        <p v-if="error" class="border-l-4 border-[#ffd38f] pl-4 text-2xl">
            Therefore, get rid of all moral filth and the evil that is so
            prevalent and humbly accept the word planted in you, which can save
            you.
            <span class="mt-4 block font-bold">James 1:21</span>
        </p>
        <p v-else class="border-l-4 border-[#ffd38f] pl-4 text-2xl">
            {{ data.text }}
            <span class="mt-4 block font-bold">{{ data.verse }}</span>
        </p>
    </DashGrid>
</template>

<script lang="ts" setup>
const { data, pending, error, refresh } = await useFetch(
    `http://localhost:5230/bible`
)
</script>
