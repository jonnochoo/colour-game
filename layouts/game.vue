<template>
    <div>
        <header class="p-4 pl-8 text-slate-800 bg-[#E0CA3C] text-5xl">
            <NuxtLink to="/">🕹️Choo Games</NuxtLink>
        </header>
        <section class="container mx-auto pt-12">
            <slot />
        </section>
    </div>
</template>

<style>
body {
    background-color: #3e2f5b;
}
</style>
