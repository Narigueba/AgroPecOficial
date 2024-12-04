import { createMemoryHistory, createRouter } from 'vue-router'

import HomeView from '../Pages/HomeView.vue'
import AboutView from '../Pages/AboutView/AboutView.vue'
import Racao from '../Pages/Racao/Racao.vue'
import TipoAnimal from '../Pages/TipoAnimal/TipoAnimal.vue'
import Vacina from '../Pages/Vacina/Vacina.vue'
import Animal from '../Pages/Animal/Animal.vue'
import AnimalVacina from '../Pages/AnimalVacina/AnimalVacina.vue'

const routes = [
  { path: '/', component: HomeView },
  { path: '/about', component: AboutView },
  { path: '/racao', component: Racao },
  { path: '/tipo-animal', component: TipoAnimal },
  { path: '/vacina', component: Vacina },
  { path: '/animal', component: Animal},
  { path: '/animal-vacina', component: AnimalVacina},
]

const router = createRouter({
  history: createMemoryHistory(),
  routes,
})

export default router;