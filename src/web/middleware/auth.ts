const authStore = useAuthStore()
export default defineNuxtRouteMiddleware((to, from) => {
    // isAuthenticated() is an example method verifying if a user is authenticated
    if (authStore.isAuthenticated === false) {
        return navigateTo('/login')
    }
})
