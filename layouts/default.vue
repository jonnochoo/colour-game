<template>
    <div class="h-full">
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

<style scoped></style>
