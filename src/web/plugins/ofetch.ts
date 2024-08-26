import { ofetch } from 'ofetch'

export default defineNuxtPlugin((_nuxtApp) => {
    globalThis.$fetch = ofetch.create({
        onRequest({ request, options }) {
            // This only applies the authentication to those with a baseURL
            // NOTE: Having problems with getting this to work with the useAuthStore (or composables), let's figure this out
            if (options.baseURL) {
                const token = localStorage.getItem('token')
                const tokenObj = JSON.parse(token)
                console.log('tok', tokenObj)
                options.headers = { Authorization: `Bearer ${tokenObj.token}` }
            }
        },
        onRequestError({ error }) {
            console.error(error)
        },
    })
})
