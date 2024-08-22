<template>
    <ClientOnly>
        <MonacoEditor
            ref="editorRef"
            v-model="value"
            :lang="lang"
            :options="options"
            class="editor h-96"
            @load="load"
        />
    </ClientOnly>
</template>
<script lang="ts" setup>
import type * as monaco from 'monaco-editor'
// import { editor } from 'monaco-editor'

const lang = ref<'plaintext' | 'html' | 'css' | 'javascript'>('plaintext')
const options: monaco.editor.IStandaloneEditorConstructionOptions = {
    automaticLayout: true,
    theme: 'vs-dark',
}
const editorRef = ref()

onMounted(() => {
    console.log(editorRef, editorRef.value)
    // const monaco = editor.getEditors()
})

const load = (editor: monaco.editor.IStandaloneCodeEditor) => {
    editor.lan
    // editor.languages.register({ id: 'mylang' })
    // editor.languages.setMonarchTokensProvider('mylang', {
    //     keywords: ['cat', 'dog'],
    // })
}

const value = ref('')
</script>

<style>
body {
    background-color: #3e2f5b;
}
</style>
