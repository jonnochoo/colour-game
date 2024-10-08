<template>
    <spinner v-if="pending" />
    <error v-else-if="error" />
    <div v-else>
        <section
            class="container mx-auto rounded-2xl bg-[#241b2f] p-8 font-[Lexend] lg:mt-10 lg:w-2/3 lg:text-xl 2xl:w-1/2"
        >
            <div v-if="data.passages.length >= 1">
                <h2 class="mb-3 text-4xl font-bold">
                    {{ data?.passageChunksv2?.verse }}
                </h2>
                <span
                    class="mb-3 whitespace-pre-line"
                    :class="{
                        'align-text-top text-sm': passage.includes('['),
                    }"
                    v-for="(passage, index) in data?.passageChunksv2.content"
                >
                    {{ passage }}
                </span>
                <div v-if="data?.passageChunksv2?.footnotes.length > 0">
                    <h2 class="mb-3 mt-6 font-bold text-gray-500">Footnotes</h2>
                    <div
                        v-if="data.passages.length >= 1"
                        class="mb-3 text-sm text-gray-500"
                        v-for="(passage, index) in data?.passageChunksv2
                            ?.footnotes"
                    >
                        ({{ index + 1 }}) {{ passage }}
                    </div>
                </div>
            </div>
            <p v-else>
                Sorry we couldn't find a passage '{{ passageToSearch }}'
            </p>
        </section>
    </div>

    <button
        class="fixed bottom-0 right-0 m-3 h-12 w-12 rounded-full bg-orange-500 p-2"
        @click="openModal"
    >
        +
    </button>

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
                    class="p-2 font-[Lexend] text-2xl text-gray-800 outline-none"
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
const passageToSearch = ref('Matthew 7:24-25')
const { data, pending, error, refresh } = await useLazyFetch(`/api/verse`, {
    query: { passage: passageToSearch },
})

const openModal = () => {
    passageToInput.value = ''
    passageDialog?.value?.showModal()
}
const onSubmit = async () => {
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

<style></style>
