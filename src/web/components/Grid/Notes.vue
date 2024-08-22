<template>
    <DashGrid @refreshed-click="store.refresh">
        <div v-if="pending"><GridPending /></div>
        <div v-else-if="error">{{ error }}</div>
        <div v-else>
            <ClientOnly>
                <h2 class="mb-6 text-4xl font-bold text-my-aqua">
                    Think About...
                </h2>
                <p>{{ note.text }}</p>
            </ClientOnly>
        </div>
    </DashGrid>
</template>

<script lang="ts" setup>
const store = useNotesStore()
const { note, error, pending } = storeToRefs(store)

await store.refresh()
</script>
