<template>
    <header class="flex">
        <h1 class="flex-grow text-4xl font-extrabold mb-2">
            🪣<span
                class="bg-gradient-to-r from-blue-600 via-blue-500 to-indigo-400 inline-block text-transparent bg-clip-text"
                >Colour Sorter</span
            >
        </h1>
        <div v-if="data.game !== null" class="p-2 mb-2 text-center">
            <button
                class="rounded-lg text-white p-2 bg-blue-500 hover:bg-blue-500"
                @click="createGame"
            >
                Start A New Game
            </button>
        </div>
    </header>
    <div
        v-if="data.game === null"
        @click="createGame"
        class="h-screen flex items-center justify-center"
    >
        <button
            class="rounded-2xl text-white p-10 bg-blue-500 text-5xl mb-10 font-thin"
        >
            Start Game
        </button>
    </div>
    <div v-else>
        <div class="p-2 mb-2 text-center text-gray-800 flex">
            <div class="text-3xl font-thin mr-4">
                Moves: {{ data.game.score }}
            </div>
            <div class="flex-auto text-3xl font-thin text-right">
                {{ data.game.timer }}
            </div>
        </div>
        <div class="grid grid-cols-5 mt-10">
            <Stack
                v-for="stack in data.game.stacks"
                :stack="stack"
                @change="onStackChange"
            />
        </div>
        <div
            class="p-2 text-4xl text-center mt-10 font-light"
            v-if="data.game.isGameOver"
        >
            Well done, you win!
        </div>
    </div>
</template>
<script setup lang="ts">
import { useGame } from '~/utils/useGame'

const data = reactive({
    game: null,
})

function createGame() {
    data.game = useGame()
}

const onStackChange = (e) => {
    data.game.swap(e.sourceId, e.destinationId)
}
</script>
