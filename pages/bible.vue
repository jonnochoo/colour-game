<template>
    <spinner v-if="pending" />
    <error v-else-if="error" />
    <div v-else>
        <section
            class="container mx-auto rounded-2xl bg-[#241b2f] p-8 text-2xl lg:mt-10 lg:w-2/3 2xl:w-1/2"
        >
            <p
                v-if="data.passages.length >= 1"
                class="mb-3"
                :class="{ 'mb-6 text-4xl font-bold': index == 0 }"
                v-for="(passage, index) in data.passages[0]?.split('\n\n')"
            >
                {{ passage }}
            </p>
            <p v-else>
                Sorry we couldn't find a passage '{{ passageToSearch }}'
            </p>
        </section>
    </div>

    <!-- Modal -->
    <dialog
        ref="passageDialog"
        class="rounded-lg backdrop:bg-black backdrop:bg-opacity-50 backdrop:backdrop-blur-[3px]"
    >
        <div class="bg-white p-4">
            <form method="dialog" @submit="onSubmit">
                <input
                    v-model="passageToInput"
                    type="text"
                    autofocus
                    placeholder="Enter a bible verse"
                    class="p-2 text-2xl text-gray-800 outline-none"
                />
            </form>
        </div>
    </dialog>
</template>
<script lang="ts" setup>
import { useKeypress } from 'vue3-keypress'
definePageMeta({
    layout: 'bible',
})

const passageDialog = ref<HTMLDialogElement>()

const passageToInput = ref('')
const passageToSearch = ref('Matthew 11:15-20')
const { data, pending, error, refresh } = await useFetch(`/api/verse`, {
    query: { passage: passageToSearch },
})

const openModal = () => {
    passageToInput.value = ''
    passageDialog?.value?.showModal()
}
const onSubmit = async () => {
    console.log('search', passageToInput.value)
    passageToSearch.value = passageToInput.value
    await refresh()
}

// Key listeners
useKeypress({
    keyEvent: 'keydown',
    keyBinds: [
        {
            keyCode: '/', // or keyCode as integer, e.g. 40
            success: openModal,
        },
    ],
})
</script>

<style>
body {
    font-family: 'Noto Sans', 'monospace';
}
</style>
