<template>
    <h1 class="font-[lexend] text-5xl text-white">🏏 Choo Family Dashboard</h1>
    <div class="mt-8 grid grid-cols-3 gap-6">
        <DashGrid>
            <p class="border-l-4 border-[#ffd38f] bg-[#3e2f5b] pl-4 text-2xl">
                Therefore, get rid of all moral filth and the evil that is so
                prevalent and humbly accept the word planted in you, which can
                save you.
            </p>
        </DashGrid>
        <DashGrid
            class="s drop-shadow-orange-100 text sky-200 rounded-2xl bg-[#3e2f5b] p-6 font-[lexend] text-white"
        >
            The current temp
            <p class="text-8xl">14°</p>
        </DashGrid>
        <DashGrid
            class="rounded-2xl bg-[#3e2f5b] p-8 font-[ibm_plex_sans] text-white"
        >
            <p class="text-center text-8xl">9:27PM</p>
            <p class="text-center text-4xl">Mon, 15th July</p>
        </DashGrid>
        <DashGrid
            class="rounded-2xl bg-[#3e2f5b] p-8 font-[ibm_plex_sans] text-white"
        ></DashGrid>
        <DashGrid
            class="rounded-2xl bg-[#3e2f5b] p-8 font-[ibm_plex_sans] text-white"
        >
            <p class="mb-4 text-2xl text-[#f87359]">Next Meal</p>
            <p class="text-4xl">Fish</p>
        </DashGrid>
        <DashGrid
            class="rounded-2xl bg-[#3e2f5b] p-8 font-[ibm_plex_sans] text-white"
        >
            <p class="mb-4 text-2xl text-[#f87359]">Upcoming Events</p>
            <p class="text-4xl">Fish</p>
        </DashGrid>
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
</style>
