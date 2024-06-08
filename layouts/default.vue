<template>
    <div>
        <header class="p-4 pl-8 text-slate-800 bg-[#E0CA3C] text-5xl">
            <NuxtLink to="/">🕹️Choo Games</NuxtLink>
        </header>
        <section class="container mx-auto">
            <slot />
        </section>
    </div>
</template>

<style>
body {
    background-color: #3e2f5b;
}
header {
    font-family: 'Fredoka One', monospace;
}
</style>
