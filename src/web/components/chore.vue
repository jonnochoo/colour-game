<template>
  <div
    @click="onClick"
    class="border-1 bg-white p-4 rounded-md hover:bg-blue-300 hover:cursor-pointer mb-4 border-l-8 shadow-gray-900 drop-shadow-md"
    :class="{
      'border-teal-400 line-through opacity-30': isCompleted,
      'border-pink-400': !isCompleted,
    }"
  >
    <Icon
      v-if="!isCompleted"
      name="ic:baseline-check-box-outline-blank"
      color="black"
    /><Icon v-else name="ic:baseline-check-box" color="black" />

    {{ data.description }}
  </div>
  <!-- <img class="inline" src="@job.ImageUrl" /> -->
</template>

<script setup lang="ts">
import { type Chore } from '~/types/index'

const emit = defineEmits(['onClick'])
const props = defineProps<{
  data: Chore
}>()

let isCompleted = ref(props.data.isCompleted)
const onClick = () => {
  isCompleted.value = !isCompleted.value
  emit('onClick', {
    description: props.data.description,
    isCompleted: isCompleted.value,
  })
}
</script>
../types/type ../types
