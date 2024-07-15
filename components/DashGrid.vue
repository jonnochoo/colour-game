<template>
    <div
        class="rounded-2xl bg-gradient-to-b from-[#312549] to-[#3e2f5b] p-8 font-[lexend] text-white"
        :class="props.class"
    >
        <slot />
    </div>
</template>

<script setup lang="ts">
const props = defineProps<{ class?: string }>()
</script>
