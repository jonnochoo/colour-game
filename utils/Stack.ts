import { Ball } from './Ball'

export class Stack {
    balls: Ball[] = []
    constructor(balls: Ball[]) {
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

    push(ball: Ball) {
        this.balls.push(ball)
    }

    pop() {
        return this.balls.pop()
    }
}
