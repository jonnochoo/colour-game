<template>
    <section class="menu text-white container mx-auto p-8 text-4xl mt-8">
        <div class="flex flex-col gap-4">
            <GameLink name="Colour Sorter" path="/sorter" />
            <GameLink name="Word Scrambler" path="/word" />
        </div>
    </section>
</template>
<script setup lang="ts"></script>

<style>
body {
    background-color: #3e2f5b;
}
header {
    font-family: 'Fredoka One', monospace;
}
.menu {
    font-family: 'Fira Code', monospace;
    font-weight: 100;
}
.menu li {
    padding-top: 10px;
}
</style>
