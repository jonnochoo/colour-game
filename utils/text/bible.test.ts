import { test, expect } from 'vitest'
import { removeUnnecessaryNewLine } from './bible'

test('generate random number', () => {
    const sut = removeUnnecessaryNewLine(
        'hi there this should disappear \n but this should stay \n\n  eol'
    )
    expect(sut).toBe(
        'hi there this should disappear  but this should stay \n\n  eol'
    )
})
