<template>
    <div class="grid grid-cols-5">
        <Stack :stack="data.stack1" />
        <Stack :stack="data.stack2" />
        <Stack :stack="data.stack3" />
        <Stack :stack="data.stack4" />
        <Stack :stack="data.stack5" />
    </div>
</template>
<script setup lang="ts">
import { createBalls } from '~/utils/createBalls'

const data = reactive({
    stack1: new Stack([]),
    stack2: new Stack([]),
    stack3: new Stack([]),
    stack4: new Stack([]),
    stack5: new Stack([]),
})
onMounted(() => {
    const balls = createBalls()
    data.stack1 = new Stack(balls.slice(0, 5))
    data.stack2 = new Stack(balls.slice(5, 10))
    data.stack3 = new Stack(balls.slice(10, 15))
    data.stack4 = new Stack(balls.slice(15, 20))
    data.stack5 = new Stack([])
})
</script>
