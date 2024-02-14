<template>
    <div class="grid">
        <ul>
            <li :class="stack.colour" v-for="stack in stack1.balls">
                {{ stack.id }}
            </li>
        </ul>
    </div>
</template>
<script setup lang="ts">
import { createBalls } from '~/utils/createBalls'

const balls = createBalls()
const stack1 = new Stack(balls.slice(0, 4))
const stack2 = new Stack(balls.slice(4, 4))
const stack3 = new Stack(balls.slice(8, 4))
const stack4 = new Stack(balls.slice(12, 4))
</script>
