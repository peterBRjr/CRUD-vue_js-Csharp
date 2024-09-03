import { createRouter, createWebHistory } from 'vue-router'
import tarefas from '../views/tarefasView.vue'
import addTarefa from '../views/addTarefaView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: tarefas
    }, 
    {
      path: '/add',
      name: 'add',
      component: addTarefa
    },
    
  ]
})

export default router
