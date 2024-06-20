<template>
    <div>
        <section
            class="mx-auto container mt-10 bg-[#241b2f] p-8 text-2xl rounded-2xl w-1/3"
        >
            <p
                class="mb-3"
                :class="{ 'font-bold text-4xl mb-6': index == 0 }"
                v-for="(passage, index) in data.passages[0]?.split('\n\n')"
            >
                {{ passage }}
            </p>
        </section>
    </div>

    <!-- Modal -->
    <dialog
        ref="passageDialog"
        class="backdrop:bg-black backdrop:backdrop-blur-[3px] backdrop:bg-opacity-50 rounded-lg"
    >
        <div class="bg-white">
            <form method="dialog" @submit="onSubmit">
                <input
                    v-model="passageToInput"
                    type="text"
                    autofocus
                    placeholder="Enter a bible verse"
                    class="p-2 text-black outline-none"
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
const { data, error, refresh } = await useFetch(`/api/verse`, {
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
useKeypress({
    keyEvent: 'keydown',
    keyBinds: [
        {
            keyCode: '/', // or keyCode as integer, e.g. 40
            modifiers: 'ctrlKey',
            success: openModal,
        },
        // {
        //     keyCode: 'esc', // or keyCode as integer, e.g. 40
        //     success: function () {
        //         passageDialog.close()
        //     },
        // },
    ],
})
</script>
