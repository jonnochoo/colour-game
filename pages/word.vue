<template>
    <nav class="bg-[#FA7070] border-[#A1C398] p-6">
        <h2 class="text-5xl font-thin text-white">🧩Unscramble The Word</h2>
    </nav>
    <div class="pt-12">
        <div
            class="container mx-auto rounded-3xl bg-[#C6EBC5] p-4 drop-shadow-sm sh"
        >
            <span class="font-bold mr-4">Category:</span>
            <select
                class="p-2 w-fu rounded-md"
                v-model="selectedCategory"
                @change="startGame"
            >
                <option v-for="w in wordList">{{ w.category }}</option>
            </select>
            <span
                ><button
                    @click="startGame"
                    class="ml-2 hover:pointer underline"
                >
                    Refresh
                </button></span
            >
            <div
                class="flex items-center justify-center mt-10 mb-10 text-9xl text-gray-700"
            >
                {{ wordShown }}
            </div>
            <div v-if="!isCorrect">
                <div class="flex items-center justify-center mt-10 mb-10">
                    <input
                        ref="guessInput"
                        class="p-2 block mb-2 rounded rounded-md text-5xl text-center font-thin"
                        v-model="guess"
                        v-on:keyup.enter="onGuessButtonClicked"
                    />
                </div>
                <button
                    class="p-2 block rounded-md text-white bg-[#DD5746] text-2xl border-b-4 border-[#FFC470] mx-auto"
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

            <div v-if="isCorrect" class="text-2xl">
                <div class="flex items-center justify-center">
                    <p>
                        You guessed correctly in
                        {{ history.length + 1 }} attempts
                    </p>
                </div>
                <div class="flex items-center justify-center mt-2 mb-4">
                    <button
                        ref="newGameInput"
                        class="p-2 block rounded-md text-white bg-[#DD5746] text-2xl border-b-4 border-[#FFC470] mx-auto"
                        @click="startGame()"
                    >
                        New Game
                    </button>
                </div>
            </div>
        </div>
    </div>
</template>

<script lang="ts" setup>
const wordList = ref([
    {
        category: 'Pokemon',
        words: [
            'bulbasaur',
            'ivysaur',
            'venusaur',
            'charmander',
            'charmeleon',
            'charizard',
            'squirtle',
            'wartortle',
            'blastoise',
            'caterpie',
            'metapod',
            'butterfree',
            'weedle',
            'kakuna',
            'beedrill',
            'pidgey',
            'pidgeotto',
            'pidgeot',
            'rattata',
            'raticate',
            'spearow',
            'fearow',
            'ekans',
            'arbok',
            'pikachu',
            'raichu',
            'sandshrew',
            'sandslash',
            'nidoking',
            'clefairy',
            'clefable',
            'vulpix',
            'ninetales',
            'jigglypuff',
            'wigglytuff',
            'zubat',
            'golbat',
            'oddish',
            'gloom',
            'vileplume',
            'paras',
            'parasect',
            'venonat',
            'venomoth',
            'diglett',
            'dugtrio',
            'meowth',
            'persian',
            'psyduck',
            'golduck',
            'mankey',
            'primeape',
            'growlithe',
            'arcanine',
            'poliwag',
            'poliwhirl',
            'poliwrath',
            'abra',
            'kadabra',
            'alakazam',
            'machop',
            'machoke',
            'machamp',
            'bellsprout',
            'weepinbell',
            'victreebel',
            'tentacool',
            'tentacruel',
            'geodude',
            'graveler',
            'golem',
            'ponyta',
            'rapidash',
            'slowpoke',
            'slowbro',
            'magnemite',
            'magneton',
            "farfetch'd",
            'doduo',
            'dodrio',
            'seel',
            'dewgong',
            'grimer',
            'muk',
            'shellder',
            'cloyster',
            'gastly',
            'haunter',
            'gengar',
            'onix',
            'drowzee',
            'hypno',
            'krabby',
            'kingler',
            'voltorb',
            'electrode',
            'exeggcute',
            'exeggutor',
            'cubone',
            'marowak',
            'hitmonlee',
            'hitmonchan',
            'lickitung',
            'koffing',
            'weezing',
            'rhyhorn',
            'rhydon',
            'chansey',
            'tangela',
            'kangaskhan',
            'horsea',
            'seadra',
            'goldeen',
            'seaking',
            'staryu',
            'starmie',
            'mr. mime',
            'scyther',
            'jynx',
            'electabuzz',
            'magmar',
            'pinsir',
            'tauros',
            'magikarp',
            'gyarados',
            'lapras',
            'ditto',
            'eevee',
            'vaporeon',
            'jolteon',
            'flareon',
            'porygon',
            'omanyte',
            'omastar',
            'kabuto',
            'kabutops',
            'aerodactyl',
            'snorlax',
            'articuno',
            'zapdos',
            'moltres',
            'dratini',
            'dragonair',
            'dragonite',
            'mewtwo',
            'mew',
        ],
    },
    {
        category: 'Countries',
        words: [
            'united states',
            'china',
            'india',
            'japan',
            'germany',
            'united kingdom',
            'france',
            'brazil',
            'italy',
            'canada',
            'south korea',
            'russia',
            'australia',
            'spain',
            'mexico',
            'indonesia',
            'turkey',
            'netherlands',
            'saudi arabia',
            'switzerland',
            'taiwan',
            'poland',
            'sweden',
            'belgium',
            'thailand',
            'iran',
            'argentina',
            'austria',
            'norway',
            'united arab emirates',
            'nigeria',
            'denmark',
            'south africa',
            'israel',
            'egypt',
            'ireland',
            'greece',
            'singapore',
            'malaysia',
            'colombia',
            'philippines',
        ],
    },
])
const selectedCategory = ref(wordList.value[0].category)
const wordActual = ref('')
const guess = ref('')
const wordShown = ref('')
const isCorrect = ref(false)
const history = ref([])
const guessInput = ref(null)

onMounted(() => {
    startGame()
})

function startGame() {
    const list = wordList.value.find(
        (x) => x.category === selectedCategory.value
    )
    const words = list.words
    wordActual.value = words[generateRandomNumber(0, words.length)]
    wordShown.value = randomizeWord(wordActual.value)
    history.value = []
    isCorrect.value = false
    guessInput?.value?.focus()
}

function onGuessButtonClicked() {
    isCorrect.value = wordActual.value === guess.value
    if (!isCorrect.value) {
        history.value.push(guess.value)
    }
    guess.value = ''
}

function randomizeWord(word) {
    // Convert the word into an array of characters
    var wordArray = word.split('')

    // Randomize the order of characters
    for (var i = wordArray.length - 1; i > 0; i--) {
        var j = Math.floor(Math.random() * (i + 1))
        var temp = wordArray[i]
        wordArray[i] = wordArray[j]
        wordArray[j] = temp
    }

    // Convert the array back to a string
    var randomizedWord = wordArray.join('')

    return randomizedWord
}
</script>

<style>
@import url('https://fonts.googleapis.com/css?family=Freeman');
body {
    background-color: #fefded;
}
h2 {
    font-family: 'Freeman', 'sans-serif';
    color: #fde49e;
}
</style>
