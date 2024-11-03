// https://nuxt.com/docs/api/configuration/nuxt-config
import tailwindTypography from '@tailwindcss/typography'

export default defineNuxtConfig({
    devtools: { enabled: true },
    css: ['~/assets/css/main.css'],
    ssr: false,
    modules: [
        '@nuxt/test-utils/module',
        '@nuxtjs/google-fonts',
        '@nuxtjs/tailwindcss',
        '@pinia/nuxt',
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
            'Happy Monkey': true,
        },
    },
    runtimeConfig: {
        apiSecret: '',
        weatherApiKey: '',
        trelloApiKey: '',
        trelloToken: '',
        googleCalendarServiceAccountEmail: '',
        googleCalendarPrivateKey: '',
        public: {
            baseUrl: 'http://jonno-pi.tail88a240.ts.net:5000/',
        },
    },
})
