<template>
    <DashGrid class="col-span-3">
        <p class="border-l-4 border-[#ffd38f] bg-[#3e2f5b] pl-4 text-2xl">
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
