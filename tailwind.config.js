const defaultTheme = require('tailwindcss/defaultTheme')

/** @type {import('tailwindcss').Config} */
module.exports = {
    theme: {
        extend: {
            fontFamily: {
                grid: ['Fredoka One', 'sans-serif'],
            },
            colors: {
                background: '#1b1428',
            },
        },
    },
    plugins: [],
}
