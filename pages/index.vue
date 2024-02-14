<template>
    <header class="flex">
        <h1 class="flex-grow text-4xl font-bold mb-2">Colour Sorter</h1>
        <div class="p-2 text-3xl font-bold mb-2 text-center">
            Score: {{ count }}
        </div>
    </header>
    <div class="grid grid-cols-5">
        <Stack v-for="stack in stacks" :stack="stack" @change="onStackChange" />
    </div>
</template>
<script setup lang="ts">
import { createBalls } from '~/utils/createBalls'

const stacks = reactive([] as Stack[])
const count = ref(0)
onMounted(() => {
    const balls = createBalls()
    stacks.push(new Stack('1', balls.slice(0, 5)))
    stacks.push(new Stack('2', balls.slice(5, 10)))
    stacks.push(new Stack('3', balls.slice(10, 15)))
    stacks.push(new Stack('4', balls.slice(15, 20)))
    stacks.push(new Stack('5', []))
})

const onStackChange = (e) => {
    const sourceStack = stacks.find((s) => s.id == e.source)
    const destinationStack = stacks.find((s) => s.id == e.destination)
    console.log(e, sourceStack, destinationStack)
    if (sourceStack && destinationStack && destinationStack.balls.length < 5) {
        const itemball = sourceStack.pop()
        destinationStack.push(itemball)
        count.value = count.value + 1
    }
}
</script>
