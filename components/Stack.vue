<template>
    <ul
        :id="stack.id"
        draggable="true"
        class="mr-4 bg-white shadow-sm p-4 hover:cursor-move"
        @dragstart="dragstart"
        @dragover="dragover"
        @drop="drop"
    >
        <li
            v-for="s in stack.balls.toReversed()"
            :class="s.colour"
            class="rounded-full p-2 mb-2 text-center"
            :key="s.id"
        >
            {{ s.id }}
        </li>
    </ul>
</template>

<script lang="ts" setup>
import draggable from 'vuedraggable'
const emits = defineEmits('change')
const props = defineProps<{
    stack: Stack
}>()

const dragstart = (e) => {
    e.dataTransfer.setData('text', e.target.id)
}
const dragover = (e) => {
    e.preventDefault()
}
const drop = (e) => {
    emits('change', {
        source: e.dataTransfer.getData('text'),
        destination: e.target.id,
    })
}
</script>
