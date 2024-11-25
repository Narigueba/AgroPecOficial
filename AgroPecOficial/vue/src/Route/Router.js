import { createMemoryHistory, createRouter } from 'vue-router'

import HomeView from '../Pages/HomeView.vue'
import AboutView from '../Pages/AboutView/AboutView.vue'
import Racao from '../Pages/Racao/Racao.vue'
import Vacina from '../Pages/Vacina/Vacina.vue'
import Configuracao from '../Pages/Configuracao/configuracao.vue'
import ConsultarRacoes from '../Pages/ConsultarRacoes/consultarRacoes.vue'
import ConsultarRacao from '../Pages/ConsultarRacao/consultarRacao.vue'
import ConsultarVacinas from '../Pages/ConsultarVacinas/consultarVacinas.vue'
import ConsultarVacina from '../Pages/ConsultarVacina/consultarVacina.vue'
import TipoAnimal from '../Pages/TipoAnimal/TipoAnimal.vue'
import Animal from '../Pages/Animal/Animal.vue'
import ConsultarAnimal from '../Pages/ConsultarAnimal/consultarAnimal.vue'
import ConsultarAnimais from '../Pages/ConsultarAnimais/consultarAnimais.vue'


const routes = [
  { path: '/', component: HomeView },
  { path: '/about', component: AboutView },
  { path: '/racao', component: Racao },
  { path: '/vacina', component: Vacina },
  { path: '/configuracao', component: Configuracao },
  { path: '/consultarRacoes', component: ConsultarRacoes },
  { path: '/consultarRacao', component: ConsultarRacao },
  { path: '/consultarVacinas', component: ConsultarVacinas },
  { path: '/consultarVacina', component: ConsultarVacina },
  { path: '/TipoAnimal', component: TipoAnimal },
  { path: '/Animal', component: Animal },
  { path: '/consultarAnimal', component: ConsultarAnimal },
  { path: '/consultarAnimais', component: ConsultarAnimais }
]

const router = createRouter({
  history: createMemoryHistory(),
  routes,
})

export default router;