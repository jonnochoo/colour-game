export class Ball {
    id: string
    colour: string
    constructor(colour: string) {
        this.id = crypto.randomUUID()
        this.colour = colour
    }
}
