<template>
    <div
        class="relative rounded-3xl bg-gradient-to-b from-[#3e2f5b] to-[#3e2f5b] p-8 font-[lexend] text-2xl text-white opacity-85"
        :class="props.class"
    >
        <slot />
        <button
            @click="refreshData"
            class="fixed absolute right-4 top-4 h-6 w-6 rounded rounded-full bg-[#33264a] opacity-40"
        >
            &nbsp;
        </button>
    </div>
</template>

<script setup lang="ts">
const props = defineProps<{ class?: string }>()
const emit = defineEmits<{
    refreshedClick: []
}>()

const refreshData = () => {
    emit('refreshedClick')
}
</script>
