// https://nuxt.com/docs/api/configuration/nuxt-config
import tailwindTypography from '@tailwindcss/typography'

export default defineNuxtConfig({
    devtools: { enabled: true },
    css: ['~/assets/css/main.css'],
    modules: [
        '@nuxt/test-utils/module',
        '@nuxtjs/google-fonts',
        '@nuxtjs/tailwindcss',
        'nuxt-monaco-editor',
    ],
    tailwindcss: {
        config: {
            plugins: [tailwindTypography],
        },
    },
    googleFonts: {
        prefetch: true,
        preconnect: true,
        families: {
            Roboto: true,
            'Fredoka One': true,
            'Fira Code': true,
            Lexend: true,
            'IBM Plex Sans Condensed': true,
            'IBM Plex Sans': true,
        },
    },
    runtimeConfig: {
        apiSecret: '',
        weatherApiKey: '',
        trelloApiKey: '',
        trelloToken: '',
        googleCalendarServiceAccountEmail: '',
        googleCalendarPrivateKey: '',
    },
})
