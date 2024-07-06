<template>
    <section class="menu text-white container mx-auto p-8 text-4xl">
        <div class="flex flex-col gap-6">
            <GameLink name="Colour Sorter" path="/sorter" />
            <GameLink name="Word Scrambler" path="/word" />
        </div>
        <div class="flex items-center justify-center">
            <img
                src="https://media0.giphy.com/media/v1.Y2lkPTc5MGI3NjExb2tqNGFnNXFjOTlybGxqcno2dTJrZnllaXAxamU2ZWRmNzlzY3IyNyZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9cw/lDcLbZlvmboCvMunkc/giphy.webp"
                alt=""
            />
        </div>
    </section>
</template>
<script setup lang="ts">

definePageMeta({
    layout: 'game',
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
</style>
