export function createBalls() {
    const balls = []
    balls.push(new RedBall())
    balls.push(new RedBall())
    balls.push(new RedBall())
    balls.push(new RedBall())
    balls.push(new RedBall())

    balls.push(new YellowBall())
    balls.push(new YellowBall())
    balls.push(new YellowBall())
    balls.push(new YellowBall())
    balls.push(new YellowBall())

    balls.push(new GreenBall())
    balls.push(new GreenBall())
    balls.push(new GreenBall())
    balls.push(new GreenBall())
    balls.push(new GreenBall())

    balls.push(new BlueBall())
    balls.push(new BlueBall())
    balls.push(new BlueBall())
    balls.push(new BlueBall())
    balls.push(new BlueBall())

    return balls.sort(() => (Math.random() > 0.5 ? 1 : -1))
}

// function createBalls(ball: Ball, number: number) {
//     for (let i = 1; i <= number; number++) {
//         ball
//     }
// }
