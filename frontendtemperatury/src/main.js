import { createApp } from 'vue'
import App from './App.vue'
import "bootstrap/dist/css/bootstrap.min.css"
import "bootstrap"
import 'v-calendar/dist/style.css'
import { SetupCalendar, Calendar, DatePicker } from "v-calendar"
import axios from 'axios'

const axiosInstance = axios.create({
    headers:{
        APIKEY:process.env.VUE_APP_APIKEY
    }
})
const app=createApp(App)
app.config.globalProperties.$axios = { ...axiosInstance }
app.use(SetupCalendar).component("Calendar", Calendar).component("DatePicker", DatePicker).mount('#app')
