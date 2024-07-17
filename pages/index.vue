<template>
    <div>
        <section class="grid grid-cols-3 gap-4">
            <GridBox to="/bible" text="Bible" />
            <GridBox to="/game" text="Game" />
            <GridBox to="/dashboard" text="Dashboard" />
        </section>
    </div>
</template>
<script setup lang="ts">
definePageMeta({
    layout: 'dashboard',
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
    background-color: #1b1428;
}
</style>
