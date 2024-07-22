<template>
    <div class="container">
        <section class="mx-4 grid gap-4 lg:grid-cols-3">
            <GridBox
                to="/bible"
                text="Bible"
                class="text-green-500"
                icon="book"
            />
            <GridBox
                to="/game"
                text="Game"
                class="text-blue-500"
                icon="gamepad"
            />
            <GridBox
                to="/dashboard"
                text="Dashboard"
                class="text-my-aqua"
                icon="gamepad"
            />
        </section>
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
.menu li {
    padding-top: 10px;
}
body {
    background-color: red;
}
</style>
