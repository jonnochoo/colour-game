import { test, expect } from 'vitest'
import { Stack } from './Stack'
import { BlueBall } from './BlueBall'
import { PurpleBall } from './PurpleBall'

test('empty stack should not be full AND incomplete', () => {
    const sut = new Stack([])

    expect(sut.isFull()).toBe(false)
    expect(sut.isComplete()).toBe(false)
})

test('one ball stack should not be full AND incomplete', () => {
    const sut = new Stack([new BlueBall()])

    expect(sut.isFull()).toBe(false)
    expect(sut.isComplete()).toBe(false)
})

test('five ball stack should be full AND incomplete', () => {
    const sut = new Stack([
        new PurpleBall(),
        new BlueBall(),
        new BlueBall(),
        new BlueBall(),
        new BlueBall(),
    ])

    expect(sut.isFull()).toBe(true)
    expect(sut.isComplete()).toBe(false)
})

test('five red ball stack should be full AND complete', () => {
    const sut = new Stack([
        new BlueBall(),
        new BlueBall(),
        new BlueBall(),
        new BlueBall(),
        new BlueBall(),
    ])

    expect(sut.isFull()).toBe(true)
    expect(sut.isComplete()).toBe(true)
})
