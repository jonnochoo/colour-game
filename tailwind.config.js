const defaultTheme = require('tailwindcss/defaultTheme')

/** @type {import('tailwindcss').Config} */
module.exports = {
    theme: {
        extend: {
            fontFamily: {
                grid: ['Fredoka One', 'sans-serif'],
                'normal-dashboard': ['Lexend', 'sans-serif'],
            },
            colors: {
                background: '#1b1428',
                'my-red': '#f87359',
                'my-orange': '#FFB86C',
                'my-yellow': '#fceb3c',
                'my-aqua': '#4dceb0',
                'my-green': '#50FA7B',
            },
        },
    },
    plugins: [],
}
