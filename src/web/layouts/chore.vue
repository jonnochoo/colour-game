<template>
    <div>
        <div class="container mx-auto pt-12">
            <slot />
        </div>
    </div>
</template>

<script setup lang="ts">
useHead({
    bodyAttrs: {
        class: ["bg-[url('/bground1.png')]", 'bg-no-repeat', 'bg-cover'].join(
            ' '
        ),
    },
})
</script>

<style scoped></style>
