// https://nuxt.com/docs/api/configuration/nuxt-config
import tailwindTypography from '@tailwindcss/typography'

export default defineNuxtConfig({
    devtools: { enabled: true },
    css: ['~/assets/css/main.css'],
    modules: [
        '@nuxt/test-utils/module',
        '@nuxtjs/google-fonts',
        '@nuxtjs/tailwindcss',
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
        },
    },
    runtimeConfig: {
        apiSecret: '',
    },
})
