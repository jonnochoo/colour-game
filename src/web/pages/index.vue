<template>
    <h1 class="mb-8 text-4xl text-white">My Collection Of Random Apps</h1>
    <div class="container mx-4 grid gap-4 lg:grid-cols-5">
        <GridBox to="/bible" text="Bible" class="text-green-500" icon="book" />
        <GridBox to="/game" text="Game" class="text-blue-500" icon="gamepad" />
        <GridBox
            to="/chore"
            text="Chores"
            class="text-my-aqua"
            icon="gamepad"
        />
    </div>
</template>
<script setup lang="ts">
definePageMeta({
    layout: 'default',
})
</script>

<style scoped>
.menu {
    font-family: 'Fira Code', monospace;
    font-weight: bold;
}
</style>
