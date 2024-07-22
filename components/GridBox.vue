<template>
    <RouterLink
        :to="to"
        class="rounded-2xl bg-gradient-to-b from-[#3e2f5b] to-[#3e2f5b] p-4 font-[lexend] text-2xl text-white opacity-85"
    >
        <span class="border-l-2 border-green-400 pl-4"> {{ props.text }}</span>
    </RouterLink>
</template>

<script setup lang="ts">
const props = defineProps<{ text: string; to: string }>()
</script>
