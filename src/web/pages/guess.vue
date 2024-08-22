<template>
    <div>
        <h2 class="text-center text-5xl font-thin mt-10">
            Can you guess the number from 1 - 10?
        </h2>
        <div v-if="!isCorrect">
            <div class="flex items-center justify-center mt-10 mb-10">
                <input
                    class="p-2 block mb-2 rounded rounded-md text-5xl text-center font-thin"
                    type="number"
                    v-model="numberGuessed"
                    min="1"
                    max="100"
                    v-on:keyup.enter="onGuessButtonClicked"
                />
            </div>
            <button
                class="p-2 block rounded rounded-sm text-green-200 bg-green-600 w-full text-2xl"
                @click="onGuessButtonClicked"
            >
                Guess
            </button>
        </div>

        <div class="flex items-center justify-center">
            <ul class="mt-10">
                <li v-for="number in history" class="line-through text-5xl">
                    {{ number }}
                </li>
            </ul>
        </div>

        <div v-if="isCorrect" class="mt-2 text-2xl">
            <div class="flex items-center justify-center">
                <p>
                    Yes it was {{ randomNumber }}. You guessed correctly in
                    {{ history.length + 1 }} attempts
                </p>
            </div>
            <div class="flex items-center justify-center mt-2">
                <button
                    class="p-2 rounded rounded-sm text-green-200 bg-green-600 text-2xl"
                    @click="startGame()"
                >
                    New Game
                </button>
            </div>
        </div>
    </div>
</template>

<script lang="ts" setup>
const randomNumber = ref(1)
const numberGuessed = ref(1)
const isCorrect = ref(false)
const history = ref([])

onMounted(() => {
    startGame()
})

function startGame() {
    randomNumber.value = generateRandomNumber(1, 10)
    history.value = []
    isCorrect.value = false
}

function onGuessButtonClicked() {
    isCorrect.value = numberGuessed.value == randomNumber.value
    if (!isCorrect.value) {
        history.value.push(numberGuessed.value)
    }
}
</script>
