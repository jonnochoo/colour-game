<template>
    <div class="z-10">
        <header class="flex items-center">
            <div>
                <h1 class="font-[lexend] text-2xl text-white lg:text-6xl">
                    🏏 The Choo Family Dashboard
                </h1>
            </div>
        </header>
        <div class="mt-8 grid gap-6 lg:grid-cols-3">
            <GridBible />
            <GridClock />
            <!-- <GridWeather /> -->
            <GridNextMeal />
            <GridMeals />
            <GridEvents />
            <GridGoals />
            <GridElijah />
            <GridAbigail />
        </div>
    </div>

    <div class="background z-0">
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
definePageMeta({
    layout: 'dashboard',
})
</script>
<style>
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
    z-index: -10;
    width: 100vw;
    height: 100vh;
    top: 0;
    left: 0;
    background: #1b1428;
    overflow: hidden;
}

.background span {
    width: 5vmin;
    height: 5vmin;
    border-radius: 5vmin;
    backface-visibility: hidden;
    position: absolute;
    animation: move;
    animation-duration: 45;
    animation-timing-function: linear;
    animation-iteration-count: infinite;
}

.background span:nth-child(0) {
    color: #ff79c6;
    top: 63%;
    left: 43%;
    animation-duration: 48s;
    animation-delay: -20s;
    transform-origin: 11vw 19vh;
    box-shadow: -10vmin 0 1.729393489737698vmin currentColor;
}
.background span:nth-child(1) {
    color: #ff79c6;
    top: 33%;
    left: 80%;
    animation-duration: 52s;
    animation-delay: -20s;
    transform-origin: -15vw 8vh;
    box-shadow: -10vmin 0 2.135658798204335vmin currentColor;
}
.background span:nth-child(2) {
    color: #ff79c6;
    top: 82%;
    left: 14%;
    animation-duration: 49s;
    animation-delay: -3s;
    transform-origin: 18vw -7vh;
    box-shadow: 10vmin 0 1.5876999901545397vmin currentColor;
}
.background span:nth-child(3) {
    color: #583c87;
    top: 81%;
    left: 23%;
    animation-duration: 16s;
    animation-delay: -39s;
    transform-origin: -1vw -14vh;
    box-shadow: 10vmin 0 1.7322365758842997vmin currentColor;
}
.background span:nth-child(4) {
    color: #8be9fd;
    top: 54%;
    left: 43%;
    animation-duration: 30s;
    animation-delay: -28s;
    transform-origin: 5vw -2vh;
    box-shadow: -10vmin 0 1.3801922503435793vmin currentColor;
}
.background span:nth-child(5) {
    color: #ff79c6;
    top: 49%;
    left: 95%;
    animation-duration: 9s;
    animation-delay: -2s;
    transform-origin: 16vw -2vh;
    box-shadow: -10vmin 0 1.9074566418665968vmin currentColor;
}
.background span:nth-child(6) {
    color: #8be9fd;
    top: 62%;
    left: 75%;
    animation-duration: 24s;
    animation-delay: -49s;
    transform-origin: 3vw 21vh;
    box-shadow: 10vmin 0 1.4038834870353587vmin currentColor;
}
.background span:nth-child(7) {
    color: #ff79c6;
    top: 13%;
    left: 71%;
    animation-duration: 25s;
    animation-delay: -11s;
    transform-origin: 2vw -6vh;
    box-shadow: -10vmin 0 1.3197100111341311vmin currentColor;
}
.background span:nth-child(8) {
    color: #583c87;
    top: 60%;
    left: 8%;
    animation-duration: 9s;
    animation-delay: -42s;
    transform-origin: 16vw 14vh;
    box-shadow: 10vmin 0 1.9650790254912527vmin currentColor;
}
.background span:nth-child(9) {
    color: #8be9fd;
    top: 51%;
    left: 59%;
    animation-duration: 10s;
    animation-delay: -29s;
    transform-origin: 19vw -24vh;
    box-shadow: 10vmin 0 1.6640112055003533vmin currentColor;
}
.background span:nth-child(10) {
    color: #583c87;
    top: 37%;
    left: 73%;
    animation-duration: 14s;
    animation-delay: -14s;
    transform-origin: -4vw -22vh;
    box-shadow: 10vmin 0 1.4419174576793623vmin currentColor;
}
.background span:nth-child(11) {
    color: #ff79c6;
    top: 97%;
    left: 51%;
    animation-duration: 6s;
    animation-delay: -17s;
    transform-origin: 18vw 21vh;
    box-shadow: -10vmin 0 1.3100136815450283vmin currentColor;
}
.background span:nth-child(12) {
    color: #ff79c6;
    top: 49%;
    left: 26%;
    animation-duration: 34s;
    animation-delay: -42s;
    transform-origin: 2vw -4vh;
    box-shadow: -10vmin 0 2.180285340802927vmin currentColor;
}
.background span:nth-child(13) {
    color: #583c87;
    top: 92%;
    left: 6%;
    animation-duration: 50s;
    animation-delay: -3s;
    transform-origin: -24vw -22vh;
    box-shadow: 10vmin 0 1.87642391487289vmin currentColor;
}
.background span:nth-child(14) {
    color: #ff79c6;
    top: 39%;
    left: 99%;
    animation-duration: 23s;
    animation-delay: -37s;
    transform-origin: -17vw -24vh;
    box-shadow: -10vmin 0 2.0206040026032817vmin currentColor;
}
.background span:nth-child(15) {
    color: #8be9fd;
    top: 78%;
    left: 58%;
    animation-duration: 25s;
    animation-delay: -24s;
    transform-origin: 10vw 1vh;
    box-shadow: -10vmin 0 1.4183794405955863vmin currentColor;
}
.background span:nth-child(16) {
    color: #ff79c6;
    top: 16%;
    left: 92%;
    animation-duration: 17s;
    animation-delay: -1s;
    transform-origin: 25vw 12vh;
    box-shadow: 10vmin 0 1.72757723826182vmin currentColor;
}
.background span:nth-child(17) {
    color: #583c87;
    top: 72%;
    left: 92%;
    animation-duration: 8s;
    animation-delay: -34s;
    transform-origin: 5vw 11vh;
    box-shadow: -10vmin 0 1.7806694069078979vmin currentColor;
}
.background span:nth-child(18) {
    color: #8be9fd;
    top: 40%;
    left: 95%;
    animation-duration: 28s;
    animation-delay: -2s;
    transform-origin: -15vw -23vh;
    box-shadow: 10vmin 0 1.585987136619691vmin currentColor;
}
.background span:nth-child(19) {
    color: #583c87;
    top: 69%;
    left: 25%;
    animation-duration: 28s;
    animation-delay: -32s;
    transform-origin: -11vw 10vh;
    box-shadow: 10vmin 0 1.7138807190545766vmin currentColor;
}
</style>
