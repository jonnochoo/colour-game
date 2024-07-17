<template>
    <DashGrid class="lg:col-span-3">
        <p
            v-if="error"
            class="border-l-4 border-[#ffd38f] pl-4 text-2xl lg:text-4xl"
        >
            For in Christ all the fullness of the Deity lives in bodily form,
            and in Christ you have been brought to fullness. He is the head over
            every power and authority.
            <span class="mt-4 block font-bold">Colossians 2:9-10</span>
        </p>
        <p v-else class="border-l-4 border-[#ffd38f] pl-4 text-2xl lg:text-4xl">
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
