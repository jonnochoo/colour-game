<template>
    <ul class="mr-4 bg-white shadow-sm p-4">
        <li
            v-for="s in stack.balls"
            :class="s.colour"
            class="rounded-full p-2 mb-2"
            :key="s.id"
        >
            {{ s.id }} {{ s.colour }}
        </li>
    </ul>
</template>

<script lang="ts" setup>
const props = defineProps<{
    stack: Stack
}>()
</script>
