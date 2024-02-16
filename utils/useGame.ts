export function useGame() {
    const startDate = new Date()
    const stacks = reactive([] as Stack[])
    const score = ref(0)
    const isGameOver = ref(false)

    const balls = createBalls()
    stacks.push(new Stack('1', balls.slice(0, 5)))
    stacks.push(new Stack('2', balls.slice(5, 10)))
    stacks.push(new Stack('3', balls.slice(10, 15)))
    stacks.push(new Stack('4', balls.slice(15, 20)))
    stacks.push(new Stack('5', []))

    return {
        score,
        stacks,
        startDate,
        swap(sourceId: string, destinationId: string) {
            const sourceStack = this.findStack(sourceId)
            const destinationStack = this.findStack(destinationId)
            if (sourceStack && destinationStack && !destinationStack.isFull()) {
                const itemball = sourceStack.pop()
                destinationStack.push(itemball)
                score.value = score.value + 1

                // Check if the game is finished
                isGameOver.value = stacks
                    .filter((s) => s.balls.length !== 0)
                    .every((s) => s.isComplete())
            }
        },
        findStack(id: string) {
            return stacks.find((s) => s.id == id)
        },
        getTime() {
            return ''
        },
        checkGameStatus() {
            return this.stacks
                .filter((s) => s.balls.length !== 0)
                .every((s) => s.isComplete())
        },
    }
}
