<template>
    <NuxtLink
        class="bg-gray-200 hover:bg-[#E0CA3C] hover:text-white hover:border-l-0 p-2 pl-4 text-slate-800 border-l-8 border-[#136F63]"
        :to="props.path"
    >
        {{ props.name }}
    </NuxtLink>
</template>

<script setup lang="ts">
const props = defineProps<{
    name: string
    path: string
}>()
</script>
