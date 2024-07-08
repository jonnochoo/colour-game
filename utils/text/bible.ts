export function removeUnnecessaryNewLine(inputText: string): string {
    const paragraphs = inputText.split('\n\n')

    const replacedParagraphs = paragraphs.map((paragraph) =>
        paragraph.replace(/\n/g, '')
    )

    return replacedParagraphs.join('\n\n')
}

type passage = {
    verse: string
    content: string[]
    footnotes: string[]
}
export function splitPassageAndFootNote(text: string): passage | null {
    const getVerseRegex = /\n\n/
    const splitForVerse = text.split(getVerseRegex)
    const verse = splitForVerse[0]
    const regex = /\n\nFootnotes\n\n/
    const result = text.replace(verse, '').split(regex)
    const passageText = result[0].replace('\n\n', '') // Remove first line breaks
    return {
        verse: verse,
        content: parsePassageIntoVerses(passageText),
        footnotes: result.length == 2 ? parseFootnoteIntoArray(result[1]) : [],
    }
}

export function parsePassageIntoVerses(inputText: string): string[] {
    const regex = /(\[\d+\])/
    const result = inputText.split(regex)
    const filteredResult = result.filter((item: string) => item !== '')
    return filteredResult
}

export function parseFootnoteIntoArray(inputText: string): string[] {
    const regex = /\(\d+\)/
    const result = inputText.split(regex)
    const filteredResult = result.filter((item: string) => item !== '')
    return filteredResult
}
