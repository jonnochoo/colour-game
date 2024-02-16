<template>
    <ul
        :id="stack.id"
        class="mr-4 bg-white shadow-sm p-4 hover:cursor-move pt-12"
        draggable="true"
        @dragstart="dragstart"
        @dragover="dragover"
        @drop="drop"
    >
        <li
            :id="s.id"
            v-for="s in balls"
            :class="s.colour"
            class="rounded-full p-2 mb-2 text-center"
            :key="s.id"
        >
            &nbsp;
        </li>
    </ul>
</template>

<script lang="ts" setup>
import draggable from 'vuedraggable'
const emits = defineEmits('change')
const props = defineProps<{
    stack: Stack
}>()
const balls = computed(() => {
    const newBalls = [
        new EmptyBall(),
        new EmptyBall(),
        new EmptyBall(),
        new EmptyBall(),
        new EmptyBall(),
    ]
    for (let i = 0; i < props.stack.balls.length; i++) {
        newBalls[i] = props.stack.balls[i]
    }
    return newBalls.toReversed()
})

const dragstart = (e) => {
    e.dataTransfer.setData('text', e.target.id)
}
const dragover = (e) => {
    e.preventDefault()
}
const drop = (e) => {
    const target =
        e.srcElement.nodeName === 'UL' ? e.target : e.srcElement?.closest('ul')
    emits('change', {
        source: e.dataTransfer.getData('text'),
        destination: target.id,
    })
}
</script>
