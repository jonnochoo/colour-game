<template>
    <div
        class="rounded-3xl bg-gradient-to-b from-[#3e2f5b] to-[#3e2f5b] p-8 font-[lexend] text-white"
        :class="props.class"
    >
        <slot />
    </div>
</template>

<script setup lang="ts">
const props = defineProps<{ class?: string }>()
</script>
