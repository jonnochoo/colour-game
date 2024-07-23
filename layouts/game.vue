<template>
    <div>
        <header
            class="bg-[#E0CA3C] p-4 pl-8 font-['Fredoka_One'] text-5xl text-slate-800"
        >
            <NuxtLink to="/">🕹️Choo Games</NuxtLink>
        </header>
        <section class="container mx-auto pt-12">
            <slot />
        </section>
    </div>
</template>

<script setup lang="ts">
useHead({
    bodyAttrs: {
        class: ['bg-background'].join(' '),
    },
})
</script>

<style scoped>
body {
    background-color: #3e2f5b;
}
</style>
