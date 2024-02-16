import { Ball } from './Ball'

export class Stack {
    id: string
    balls: Ball[] = []
    shouldShake: bool
    constructor(id: string, balls: Ball[]) {
        this.id = id
        this.balls = balls
    }

    isFull() {
        return this.balls.length == 5
    }

    isComplete() {
        return (
            this.isFull() &&
            this.balls.every((b) => b.colour === this.balls[0].colour)
        )
    }
    shake() {
        this.shouldShake = true
        setTimeout(() => {
            this.shouldShake = false
        }, 1000)
    }
    push(ball: Ball) {
        this.balls.push(ball)
    }

    pop() {
        return this.balls.pop()
    }
}
