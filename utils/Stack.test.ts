import { test, expect } from 'vitest'
import { Stack } from './Stack'
import { RedBall } from './RedBall'
import { BlueBall } from './BlueBall'

test('empty stack should not be full AND incomplete', () => {
    const sut = new Stack([])

    expect(sut.isFull()).toBe(false)
    expect(sut.isComplete()).toBe(false)
})

test('one ball stack should not be full AND incomplete', () => {
    const sut = new Stack([new RedBall()])

    expect(sut.isFull()).toBe(false)
    expect(sut.isComplete()).toBe(false)
})

test('five ball stack should be full AND incomplete', () => {
    const sut = new Stack([
        new BlueBall(),
        new RedBall(),
        new RedBall(),
        new RedBall(),
        new RedBall(),
    ])

    expect(sut.isFull()).toBe(true)
    expect(sut.isComplete()).toBe(false)
})

test('five red ball stack should be full AND complete', () => {
    const sut = new Stack([
        new RedBall(),
        new RedBall(),
        new RedBall(),
        new RedBall(),
        new RedBall(),
    ])

    expect(sut.isFull()).toBe(true)
    expect(sut.isComplete()).toBe(true)
})
