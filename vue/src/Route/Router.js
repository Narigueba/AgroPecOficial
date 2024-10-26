import { createMemoryHistory, createRouter } from 'vue-router'

import HomeView from '../Pages/HomeView.vue'
import AboutView from '../Pages/AboutView/AboutView.vue'
import NovaRota from '../Pages/NovaRota/NovaRota.vue'

const routes = [
  { path: '/', component: HomeView },
  { path: '/about', component: AboutView },
  { path: '/novarota', component: NovaRota },
]

const router = createRouter({
  history: createMemoryHistory(),
  routes,
})

export default router;