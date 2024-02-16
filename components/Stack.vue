<template>
    <ul
        :id="stack.id"
        class="mr-4 bg-white shadow-md p-4 hover:cursor-move pt-12 rounded-b-3xl"
        :class="{ 'animate__animated animate__headShake': stack.shouldShake }"
        draggable="true"
        @dragstart="dragstart"
        @dragover="dragover"
        @drop="drop"
    >
        <li
            :id="s.id"
            v-for="s in balls"
            :class="s.colour"
            class="rounded-full p-2 mb-2 text-center animate__animated animate__bounceInDown"
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
    const sourceId = e.dataTransfer.getData('text')
    const target =
        e.srcElement.nodeName === 'UL' ? e.target : e.srcElement?.closest('ul')
    // Reset
    var ulElements = document.getElementsByTagName('ul')
    ulElements.forEach((element) => {
        element.classList.remove('bg-gray-200')
    })

    // Update target CSS on hover
    if (target) {
        target.classList.add('bg-gray-200')
    }
}
const drop = (e) => {
    const sourceId = e.dataTransfer.getData('text')
    const target =
        e.srcElement.nodeName === 'UL' ? e.target : e.srcElement?.closest('ul')
    const sourceEl = document.getElementById(sourceId)
    target.classList.remove('bg-gray-200')
    emits('change', {
        sourceId: sourceId,
        destinationId: target.id,
    })
}
</script>
