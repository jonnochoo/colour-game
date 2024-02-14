<template>
    <div class="grid grid-cols-5">
        <Stack v-for="stack in stacks" :stack="stack" @change="onStackChange" />
    </div>
</template>
<script setup lang="ts">
import { createBalls } from '~/utils/createBalls'

const stacks = reactive([] as Stack[])
onMounted(() => {
    const balls = createBalls()
    stacks.push(new Stack('1', balls.slice(0, 5)))
    stacks.push(new Stack('2', balls.slice(5, 10)))
    stacks.push(new Stack('3', balls.slice(10, 15)))
    stacks.push(new Stack('4', balls.slice(15, 20)))
})

const onStackChange = (e) => {
    const sourceStack = stacks.find((s) => s.id == e.from)
    sourceStack.pop()
    console.log(e, sourceStack)
}
</script>
