<template>
    <RouterLink
        :to="to"
        class="rounded-2xl bg-gradient-to-b from-[#3e2f5b] to-[#3e2f5b] p-10 text-center font-[lexend] text-4xl text-white opacity-85"
    >
        {{ props.text }}
    </RouterLink>
</template>

<script setup lang="ts">
const props = defineProps<{ text: string; to: string }>()
</script>
