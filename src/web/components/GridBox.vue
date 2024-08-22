<template>
    <RouterLink
        :to="to"
        class="rounded-2xl bg-gradient-to-b from-[#3e2f5b] to-[#3e2f5b] p-4 font-[lexend] text-2xl text-white opacity-85"
    >
        <span class="pl-4" :class="props.class"
            ><font-awesome-icon :icon="['fas', props.icon]" />
            {{ props.text }}</span
        >
    </RouterLink>
</template>

<script setup lang="ts">
const props = defineProps<{
    text: string
    to: string
    class: string
    icon: string
}>()

/* import the fontawesome core */
import { library } from '@fortawesome/fontawesome-svg-core'
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'
import {
    faUserSecret,
    faBook,
    faGamepad,
} from '@fortawesome/free-solid-svg-icons'
library.add(faUserSecret)
library.add(faBook)
library.add(faGamepad)
</script>
