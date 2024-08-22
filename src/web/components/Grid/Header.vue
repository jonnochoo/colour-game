<template>
    <h2 class="mb-4 text-center font-[lexend] lg:text-8xl">
        {{ props.header }}
    </h2>
</template>

<script setup lang="ts">
const props = defineProps<{ header: string }>()
</script>
