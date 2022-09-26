import { createApp } from 'vue'
import App from './App.vue'
import "bootstrap/dist/css/bootstrap.min.css"
import "bootstrap"
import 'v-calendar/dist/style.css'
import { SetupCalendar, Calendar, DatePicker } from "v-calendar"
createApp(App).use(SetupCalendar).component("Calendar", Calendar).component("DatePicker", DatePicker).mount('#app')
