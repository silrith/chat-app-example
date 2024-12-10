import './assets/main.css'

import { createApp } from 'vue'
import { createPinia } from 'pinia'

import App from './App.vue'
import router from './router'
import connection from './signalR'

const app = createApp(App)

app.use(createPinia())
app.use(router)

app.config.globalProperties.$signalR = connection

app.mount('#app')
