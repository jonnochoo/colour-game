import { test, expect } from 'vitest'
import {
    parsePassageIntoVerses,
    removeUnnecessaryNewLine,
    splitPassageAndFootNote,
} from './bible'

test('generate random number', () => {
    const sut = removeUnnecessaryNewLine(
        'hi there this should disappear \n but this should stay \n\n  eol'
    )
    expect(sut).toBe(
        'hi there this should disappear  but this should stay \n\n  eol'
    )
})

// test('parse footnote', () => {
//     const test =
//         '"John 3:16\n\nFor God So Loved the World\n\n  [16] “For God so loved the world,(1) that he gave his only Son, that whoever believes in him should not perish but have eternal life.\n\nFootnotes\n\n(1) 3:16 Or *For this is how God loved the world*\n (ESV)"'
//     const actual = parseText(test)
//     expect(actual).toBe([''])
// })

test('parse splitPassageAndFootNote', () => {
    const test =
        'John 3:15–16\n\n  [15] that whoever believes in him may have eternal life.(1)\n\nFor God So Loved the World\n\n  [16] “For God so loved the world,(2) that he gave his only Son, that whoever believes in him should not perish but have eternal life.\n\nFootnotes\n\n(1) 3:15 Some interpreters hold that the quotation ends at verse 15\n\n(2) 3:16 Or *For this is how God loved the world*\n (ESV)'
    const actual = splitPassageAndFootNote(test)
    expect(actual?.content).toStrictEqual([
        '  ',
        '[15]',
        ' that whoever believes in him may have eternal life.(1)\n\nFor God So Loved the World\n\n  ',
        '[16]',
        ' “For God so loved the world,(2) that he gave his only Son, that whoever believes in him should not perish but have eternal life.',
    ])
    expect(actual?.footnotes).toStrictEqual([
        ' 3:15 Some interpreters hold that the quotation ends at verse 15\n\n',
        ' 3:16 Or *For this is how God loved the world*\n (ESV)',
    ])
})
