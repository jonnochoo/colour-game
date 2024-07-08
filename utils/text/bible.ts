export function removeUnnecessaryNewLine(inputText: string): string {
    const paragraphs = inputText.split('\n\n')

    const replacedParagraphs = paragraphs.map((paragraph) =>
        paragraph.replace(/\n/g, '')
    )

    return replacedParagraphs.join('\n\n')
}

type passage = {
    content: string[]
    footnotes: string[]
}
export function splitPassageAndFootNote(text: string): passage | null {
    const regex = /\n\nFootnotes\n\n/
    const result = text.split(regex)
    const passageText = result[0]
    return {
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
