import { test, expect } from 'vitest'
import { generateRandomNumber } from './random'

test('generate random number', () => {
    const sut = generateRandomNumber(1, 10)
    expect(sut).toBeGreaterThanOrEqual(1)
    expect(sut).toBeLessThanOrEqual(10)
})
