const defaultTheme = require('tailwindcss/defaultTheme')

/** @type {import('tailwindcss').Config} */
module.exports = {
    theme: {
        extend: {
            colors: {
                raisin: '#ffb7c4',
                test: '#D8B4E2',
            },
            fontFamily: {
                grid: ['Fredoka One', 'sans-serif']
            }
        },
    },
    plugins: [],
}
