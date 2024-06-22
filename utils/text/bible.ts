export function removeUnnecessaryNewLine(inputText: string) {
    const paragraphs = inputText.split('\n\n')

    const replacedParagraphs = paragraphs.map((paragraph) =>
        paragraph.replace(/\n/g, '')
    )

    return replacedParagraphs.join('\n\n')
}
