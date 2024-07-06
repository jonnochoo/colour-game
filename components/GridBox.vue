<template>
    <RouterLink
    :to="to"
        class="font-grid bottom-0 rounded-md border-0 border-t-8 bg-white border-[#ffb7c4] p-4 text-center text-2xl"
    >
        {{ props.text }}
    </RouterLink>
</template>

<script setup lang="ts">
const props = defineProps<{ text: string, to: string }>()
</script>
