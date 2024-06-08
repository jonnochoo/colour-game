// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({
    devtools: { enabled: true },
    modules: [
        '@nuxt/test-utils/module',
        '@nuxtjs/tailwindcss',
        '@nuxtjs/google-fonts',
    ],
    googleFonts: {
        families: {
            Roboto: true,
            'Fredoka One': true,
            'Fira Code': true,
        },
    },
})
