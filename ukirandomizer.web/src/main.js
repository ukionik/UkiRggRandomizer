import { createApp } from 'vue'
import { createRouter, createWebHistory } from 'vue-router'
import 'reset-css/reset.css'
import App from "./App"
import RggConsoles from "./components/RggConsoles"
import RggWheel from "./components/RggWheel"

const routes = [
    { name: "Home", path: "/", component: RggConsoles },
    { name: "Wheel",  path: "/wheel/:platformName", component: RggWheel},
]

const router = createRouter({
    // 4. Provide the history implementation to use. We are using the hash history for simplicity here.
    history: createWebHistory(),
    routes, // short for `routes: routes`
})

// 5. Create and mount the root instance.
const app = createApp(App)
app.use(router)
app.mount('#app')