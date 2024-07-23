<template>
  <div>
    <div class="flex mb-6">
      <div class="flex-grow">
        <h2 class="font-extralight text-4xl text-white">
          {{ data.name }} has completed
          <span>
            {{ numberOfCompleted }} out of {{ filteredChores.length }} chores
          </span>
        </h2>
      </div>
    </div>
    <div v-if="!isAllCompleted">
      <Chore
        v-for="chore in filteredChores"
        :key="chore.description"
        :data="chore"
        @onClick="onClick"
      />
    </div>
    <div v-else class="pl-2 flex justify-center items-center">
      <img
        class="drop-shadow-lg rounded-lg mt-10"
        :src="content.imageUrl"
        alt=""
        placeholder="Loading..."
      />
    </div>
  </div>
</template>

<script setup lang="ts">
import { format } from 'date-fns'
import { type Category, type ChoreList } from '~/types/index'

const props = defineProps<{
  data: ChoreList
  category: Category
}>()

const content = reactive({
  chores: props.data.chores,
  imageUrl: getRandomImage(),
})
const numberOfCompleted = computed(() => {
  return filteredChores.value.filter((c) => c.isCompleted).length
})
const isAllCompleted = computed(() => {
  return filteredChores.value.every((c) => c.isCompleted)
})

const filteredChores = computed(() => {
  const dayOfWeek = format(new Date(), 'EEEE')
  return content.chores.filter(
    (x) =>
      x.category == props.category &&
      (x.frequencyType.$type === 'daily' ||
        (x.frequencyType.$type === 'weekly' &&
          x.frequencyType?.daysOfWeek?.includes(dayOfWeek)))
  )
})

const onClick = (e) => {
  const chore = content.chores.find((c) => c.description === e.description)
  console.log(e, chore)
  chore.isCompleted = e.isCompleted
}

function getRandomImage() {
  const randomNumber = getRandomInt(0, props.data.imageUrls.length - 1)
  const imageUrl = props.data.imageUrls[randomNumber]
  return imageUrl
}

function getRandomInt(min: number, max: number) {
  min = Math.ceil(min)
  max = Math.floor(max)
  return Math.floor(Math.random() * (max - min + 1)) + min
}
</script>
