<template>
    <div class="z-10">
        <header class="flex justify-between">
            <div>
                <h1
                    class="cursor-pointer font-[lexend] text-2xl text-white lg:text-6xl"
                    @click="toggle"
                >
                    <span v-if="!isFullscreen">🏏</span>
                    <span class="text-gray-700" v-else>🏏</span> The Choo Family
                    Dashboard
                </h1>
                <button class="mt-4 text-gray-400"></button>
            </div>
            <div>
                <GridBin />
            </div>
        </header>
        <div class="mt-8 grid gap-6 lg:grid-cols-3">
            <GridBible />
            <GridClock />
            <GridWeather />
            <GridNotes />
            <GridMeals />
            <GridCalendar />
            <GridGoals />
            <GridCountdown
                title="Nai Nai and Ye Ye Return"
                color="text-blue-400"
                :countdownDate="new Date('2024-08-27')"
            />
            <GridCountdown
                title="Countdown until Dance Recital"
                color="text-violet-400"
                :countdownDate="new Date('2024-08-29')"
            />
            <GridCountry />
        </div>
    </div>

    <div class="background">
        <span></span>
        <span></span>
        <span></span>
        <span></span>
        <span></span>
        <span></span>
        <span></span>
        <span></span>
        <span></span>
        <span></span>
        <span></span>
        <span></span>
        <span></span>
        <span></span>
        <span></span>
        <span></span>
        <span></span>
        <span></span>
        <span></span>
        <span></span>
        <span></span>
        <span></span>
        <span></span>
        <span></span>
        <span></span>
        <span></span>
        <span></span>
        <span></span>
        <span></span>
        <span></span>
        <span></span>
        <span></span>
        <span></span>
        <span></span>
        <span></span>
    </div>
</template>

<script setup lang="ts">
import { useFullscreen } from '@vueuse/core'

const { isFullscreen, enter, exit, toggle } = useFullscreen()
definePageMeta({
    layout: 'dashboard',
    middleware: 'auth',
})
const store = useNotesStore()
</script>
<style scoped>
body {
    background-color: #1b1428;
}
@keyframes move {
    100% {
        transform: translate3d(0, 0, 1px) rotate(360deg);
    }
}

.background {
    position: fixed;
    z-index: -1;
    width: 100vw;
    height: 100vh;
    top: 0;
    left: 0;
    background: #1b1428;
    overflow: hidden;
}

.background span {
    width: 2vmin;
    height: 2vmin;
    border-radius: 3vmin;
    backface-visibility: hidden;
    position: absolute;
    animation: move;
    animation-duration: 45;
    animation-timing-function: linear;
    animation-iteration-count: infinite;
}

.background span:nth-child(0) {
    color: #8be9fd;
    top: 21%;
    left: 16%;
    animation-duration: 25s;
    animation-delay: -1s;
    transform-origin: -8vw -20vh;
    box-shadow: -6vmin 0 0.9883467543177185vmin currentColor;
}
.background span:nth-child(1) {
    color: #ff79c6;
    top: 13%;
    left: 60%;
    animation-duration: 14s;
    animation-delay: -17s;
    transform-origin: 6vw 6vh;
    box-shadow: 6vmin 0 1.1370919215763131vmin currentColor;
}
.background span:nth-child(2) {
    color: #8be9fd;
    top: 42%;
    left: 72%;
    animation-duration: 30s;
    animation-delay: -37s;
    transform-origin: 12vw -15vh;
    box-shadow: -6vmin 0 1.078349336112426vmin currentColor;
}
.background span:nth-child(3) {
    color: #583c87;
    top: 30%;
    left: 11%;
    animation-duration: 47s;
    animation-delay: -8s;
    transform-origin: -11vw -11vh;
    box-shadow: -6vmin 0 0.9855370791653286vmin currentColor;
}
.background span:nth-child(4) {
    color: #583c87;
    top: 22%;
    left: 27%;
    animation-duration: 16s;
    animation-delay: -34s;
    transform-origin: -10vw -5vh;
    box-shadow: 6vmin 0 0.9800208889817625vmin currentColor;
}
.background span:nth-child(5) {
    color: #8be9fd;
    top: 56%;
    left: 95%;
    animation-duration: 47s;
    animation-delay: -50s;
    transform-origin: 20vw 5vh;
    box-shadow: 6vmin 0 0.9163836686900788vmin currentColor;
}
.background span:nth-child(6) {
    color: #ff79c6;
    top: 11%;
    left: 44%;
    animation-duration: 6s;
    animation-delay: -30s;
    transform-origin: 16vw 11vh;
    box-shadow: -6vmin 0 1.0242907102019625vmin currentColor;
}
.background span:nth-child(7) {
    color: #583c87;
    top: 2%;
    left: 27%;
    animation-duration: 51s;
    animation-delay: -22s;
    transform-origin: -2vw 16vh;
    box-shadow: 6vmin 0 1.263471260720832vmin currentColor;
}
.background span:nth-child(8) {
    color: #8be9fd;
    top: 39%;
    left: 33%;
    animation-duration: 45s;
    animation-delay: -44s;
    transform-origin: 11vw -5vh;
    box-shadow: 6vmin 0 1.232368668418647vmin currentColor;
}
.background span:nth-child(9) {
    color: #8be9fd;
    top: 4%;
    left: 55%;
    animation-duration: 46s;
    animation-delay: -36s;
    transform-origin: 10vw 12vh;
    box-shadow: 6vmin 0 0.8470190842356327vmin currentColor;
}
.background span:nth-child(10) {
    color: #583c87;
    top: 87%;
    left: 79%;
    animation-duration: 45s;
    animation-delay: -21s;
    transform-origin: -8vw 25vh;
    box-shadow: -6vmin 0 1.2934367831962508vmin currentColor;
}
.background span:nth-child(11) {
    color: #583c87;
    top: 48%;
    left: 31%;
    animation-duration: 17s;
    animation-delay: -19s;
    transform-origin: 0vw -22vh;
    box-shadow: -6vmin 0 1.4274160677705887vmin currentColor;
}
.background span:nth-child(12) {
    color: #583c87;
    top: 16%;
    left: 73%;
    animation-duration: 11s;
    animation-delay: -16s;
    transform-origin: 6vw -11vh;
    box-shadow: -6vmin 0 1.0454669688976586vmin currentColor;
}
.background span:nth-child(13) {
    color: #ff79c6;
    top: 34%;
    left: 25%;
    animation-duration: 43s;
    animation-delay: -16s;
    transform-origin: -21vw 3vh;
    box-shadow: 6vmin 0 1.022868975887647vmin currentColor;
}
.background span:nth-child(14) {
    color: #ff79c6;
    top: 65%;
    left: 85%;
    animation-duration: 17s;
    animation-delay: -17s;
    transform-origin: 24vw 10vh;
    box-shadow: 6vmin 0 1.0819327973032262vmin currentColor;
}
.background span:nth-child(15) {
    color: #583c87;
    top: 41%;
    left: 69%;
    animation-duration: 36s;
    animation-delay: -27s;
    transform-origin: -6vw -14vh;
    box-shadow: 6vmin 0 1.2742354792439992vmin currentColor;
}
.background span:nth-child(16) {
    color: #583c87;
    top: 57%;
    left: 2%;
    animation-duration: 25s;
    animation-delay: -42s;
    transform-origin: -3vw -16vh;
    box-shadow: 6vmin 0 1.1482134035458273vmin currentColor;
}
.background span:nth-child(17) {
    color: #8be9fd;
    top: 71%;
    left: 61%;
    animation-duration: 23s;
    animation-delay: -25s;
    transform-origin: -20vw 19vh;
    box-shadow: 6vmin 0 1.262361560998778vmin currentColor;
}
.background span:nth-child(18) {
    color: #8be9fd;
    top: 5%;
    left: 25%;
    animation-duration: 40s;
    animation-delay: -27s;
    transform-origin: -22vw 0vh;
    box-shadow: -6vmin 0 1.1831327813243342vmin currentColor;
}
.background span:nth-child(19) {
    color: #8be9fd;
    top: 63%;
    left: 91%;
    animation-duration: 18s;
    animation-delay: -1s;
    transform-origin: -4vw 23vh;
    box-shadow: 6vmin 0 0.9107731241389503vmin currentColor;
}
.background span:nth-child(20) {
    color: #ff79c6;
    top: 68%;
    left: 89%;
    animation-duration: 43s;
    animation-delay: -35s;
    transform-origin: -22vw 15vh;
    box-shadow: 6vmin 0 1.2742140591249986vmin currentColor;
}
.background span:nth-child(21) {
    color: #8be9fd;
    top: 71%;
    left: 94%;
    animation-duration: 45s;
    animation-delay: -21s;
    transform-origin: -15vw -7vh;
    box-shadow: -6vmin 0 1.2333264412259153vmin currentColor;
}
.background span:nth-child(22) {
    color: #ff79c6;
    top: 19%;
    left: 2%;
    animation-duration: 53s;
    animation-delay: -9s;
    transform-origin: -14vw 1vh;
    box-shadow: 6vmin 0 1.433246028062654vmin currentColor;
}
.background span:nth-child(23) {
    color: #583c87;
    top: 7%;
    left: 75%;
    animation-duration: 28s;
    animation-delay: -29s;
    transform-origin: 11vw 14vh;
    box-shadow: 6vmin 0 0.842876243978764vmin currentColor;
}
.background span:nth-child(24) {
    color: #8be9fd;
    top: 66%;
    left: 80%;
    animation-duration: 51s;
    animation-delay: -22s;
    transform-origin: 13vw -7vh;
    box-shadow: 6vmin 0 0.9744593719877765vmin currentColor;
}
.background span:nth-child(25) {
    color: #8be9fd;
    top: 20%;
    left: 71%;
    animation-duration: 33s;
    animation-delay: -33s;
    transform-origin: -16vw 5vh;
    box-shadow: -6vmin 0 1.5216079324834122vmin currentColor;
}
.background span:nth-child(26) {
    color: #ff79c6;
    top: 36%;
    left: 44%;
    animation-duration: 17s;
    animation-delay: -28s;
    transform-origin: 18vw -16vh;
    box-shadow: 6vmin 0 1.4972051722092174vmin currentColor;
}
.background span:nth-child(27) {
    color: #583c87;
    top: 37%;
    left: 99%;
    animation-duration: 23s;
    animation-delay: -26s;
    transform-origin: 8vw -3vh;
    box-shadow: 6vmin 0 0.9409350119970261vmin currentColor;
}
.background span:nth-child(28) {
    color: #ff79c6;
    top: 39%;
    left: 24%;
    animation-duration: 55s;
    animation-delay: -1s;
    transform-origin: 2vw 23vh;
    box-shadow: -6vmin 0 1.5300018466123233vmin currentColor;
}
.background span:nth-child(29) {
    color: #ff79c6;
    top: 51%;
    left: 86%;
    animation-duration: 43s;
    animation-delay: -40s;
    transform-origin: -21vw -17vh;
    box-shadow: 6vmin 0 0.8096868046569512vmin currentColor;
}
.background span:nth-child(30) {
    color: #ff79c6;
    top: 60%;
    left: 13%;
    animation-duration: 20s;
    animation-delay: -49s;
    transform-origin: 17vw 13vh;
    box-shadow: 6vmin 0 1.6033553716048254vmin currentColor;
}
.background span:nth-child(31) {
    color: #ff79c6;
    top: 3%;
    left: 65%;
    animation-duration: 9s;
    animation-delay: -50s;
    transform-origin: -7vw 12vh;
    box-shadow: 6vmin 0 1.6881564948405874vmin currentColor;
}
.background span:nth-child(32) {
    color: #ff79c6;
    top: 39%;
    left: 19%;
    animation-duration: 55s;
    animation-delay: -14s;
    transform-origin: -21vw 13vh;
    box-shadow: -6vmin 0 1.2917249383865563vmin currentColor;
}
.background span:nth-child(33) {
    color: #583c87;
    top: 20%;
    left: 77%;
    animation-duration: 24s;
    animation-delay: -14s;
    transform-origin: 12vw -1vh;
    box-shadow: 6vmin 0 1.2628014443687852vmin currentColor;
}
.background span:nth-child(34) {
    color: #8be9fd;
    top: 81%;
    left: 86%;
    animation-duration: 55s;
    animation-delay: -29s;
    transform-origin: -2vw 15vh;
    box-shadow: -6vmin 0 1.4797424113693787vmin currentColor;
}
</style>
