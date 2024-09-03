<script setup>
import { onMounted, ref } from 'vue';
import axios from 'axios'

const tarefas = ref([])

onMounted(() => {
  axios.get('http://localhost:5127/Tarefas').then(response => {
    tarefas.value = response.data
  })
})

function editTask(id) {
  axios.put(`https://localhost:7109/Tarefas/${id}`)
    .then(response => {
      tarefas.value = response.data;
      tarefas.value.situacao = 'Concluída';
    })

}
function deleteTask(id) {
  axios.delete(`https://localhost:7109/Tarefas/${id}`)
    .then(response => {
      tarefas.value = response.data;
    })

}
function formatarData(data) {
  const date = new Date(data);

  const day = String(date.getDate()).padStart(2, '0');
  const month = String(date.getMonth() + 1).padStart(2, '0');
  const year = date.getFullYear();
  return `${day}/${month}/${year}`;
}
</script>
<template>
  <h1>Inicio</h1>
  <div class="container">
    <nav class="navbar bg-body-tertiary">
      <div class="col col-md-4">
        <RouterLink class="btn" style="background-color: green; color: white;" to="/add">
          Adicionar Tarefa
        </RouterLink>
      </div>
    </nav>
    <div class="row">
      <div class="col col-md-4" v-for="item in tarefas" :key="item.id">
        <div class="card">
          <div class="card-body">
            <h5 class="card-title" :id="item.id">{{ item.descricao }}</h5>
            <h6 class="card-subtitle mb-2 text-muted">Data Criação {{ formatarData(item.dataCriacao) }}</h6>
            <h6 v-if="item.situacao === 0">Em andamento</h6>
            <h6 v-else-if="item.situacao === 1">Concluído</h6>
            <h6 v-if="item.situacao === 1">Data de Conclusão {{ formatarData(item.dataConclusao) }}</h6>
            <p class="card-text">.</p>
            <div class="d-flex mt-3">
              <button v-if="item.situacao === 0" class="btn btn-success me-2" @click="editTask(item.id)"
                :disabled="item.situacao === 1">
                Concluir
              </button>
              <button class="btn btn-danger" @click="deleteTask(item.id)">
                Excluir
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<style></style>