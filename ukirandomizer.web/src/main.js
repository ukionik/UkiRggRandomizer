import { createApp } from 'vue'
import { createRouter, createWebHashHistory} from 'vue-router'
import 'reset-css/reset.css'
import App from "./App";

const routes = [
    {
        path: "/",
        name: "App",
        component: App
    },
]

const router = createRouter({
    // 4. Provide the history implementation to use. We are using the hash history for simplicity here.
    history: createWebHashHistory(),
    routes, // short for `routes: routes`
})

const app = createApp({})
app.use(router)
app.mount('#app')