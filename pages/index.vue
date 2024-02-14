<template>
    <div class="grid grid-cols-5">
        <Stack :stack="stack1" />
        <Stack :stack="stack2" />
        <Stack :stack="stack3" />
        <Stack :stack="stack4" />
        <Stack :stack="stack5" />
    </div>
</template>
<script setup lang="ts">
import { createBalls } from '~/utils/createBalls'

const balls = createBalls()
const stack1 = new Stack(balls.slice(0, 5))
const stack2 = new Stack(balls.slice(5, 10))
const stack3 = new Stack(balls.slice(10, 15))
const stack4 = new Stack(balls.slice(15, 20))
const stack5 = new Stack([])
</script>
