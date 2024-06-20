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
        class="fixed inset-0 bg-black backdrop-blur-[3px] bg-opacity-50 flex items-center justify-center backdrop:bg-slate-600"
    >
        <div class="bg-white rounded-lg shadow-lg p-8">
            <form method="dialog" onsubmit="update">
                <input
                    v-model="searchPassage"
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

const passageDialog = ref(null)

const searchPassage = ref('Matthew 11:15-27')
const { data, error, refresh } = await useFetch(
    `/api/verse?passage=${searchPassage.value}`
)

const openModal = () => {
    searchPassage.value = ''
    passageDialog.showModal()
}
const update = async () => {
    console.log('search', searchPassage.value)
    // await refresh()
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
