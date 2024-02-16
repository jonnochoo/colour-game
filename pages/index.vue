<template>
    <header class="flex">
        <h1 class="flex-grow text-4xl font-bold mb-2">Colour Sorter</h1>
        <div
            v-if="data.game !== null"
            class="p-2 text-3xl font-bold mb-2 text-center"
        >
            Score: {{ data.game.score }}
        </div>
    </header>
    <div v-if="data.game === null" @click="createGame">
        <button class="rounded text-white p-2 bg-pink-400">Start Game</button>
    </div>
    <div v-else>
        <div class="grid lg:grid-cols-5">
            <Stack
                v-for="stack in data.game.stacks"
                :stack="stack"
                @change="onStackChange"
            />
        </div>

        <div class="p-2 text-4xl text-center mt-10" v-if="isGameOver">
            Well Done!!!
        </div>
    </div>
</template>
<script setup lang="ts">
import { createBalls } from '~/utils/createBalls'
import { useGame } from '~/utils/useGame'

const data = reactive({
    game: null,
})
const count = ref(0)
const isGameOver = ref(false)
onMounted(() => {})

function createGame() {
    data.game = useGame()
}

const onStackChange = (e) => {
    data.game.swap(e.source, e.destination)
}
</script>
