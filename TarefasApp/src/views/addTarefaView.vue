<script setup>
import axios from 'axios';
import { reactive, ref, onMounted } from 'vue';
import { useRouter } from 'vue-router';

let newTarefa = reactive({
  descricao: '',
  dataCriacao: '',
  status: 0
});

const router = useRouter();
onMounted(() => {
  const hoje = new Date();
  const ano = hoje.getFullYear();
  const mes = String(hoje.getMonth() + 1).padStart(2, '0');
  const dia = String(hoje.getDate()).padStart(2, '0');

  newTarefa.dataCriacao = `${ano}-${mes}-${dia}`;
});

const addTarefa = () => {
  if (newTarefa.descricao === '') {
    alert('A descrição da tarefa é obrigatória!');
    return;
  }
  axios.post('http://localhost:5127/Tarefas', newTarefa)
    .then(() => {
      router.push('/');
    })
};
</script>

<template>
  <div>
    <form @submit.prevent="addTarefa">
      <legend>
        Adicionar nova Tarefa!
      </legend>
      <div class="mb-3">
        <label for="txtdescricao" class="form-label">Digite a Tarefa:</label>
        <input type="text" class="form-control" id="txtdescricao" aria-describedby="emailHelp"
          v-model="newTarefa.descricao" />
      </div>
      <div class="mb-3">
        <label for="txtdatacriacao" class="form-label">Data de Criação:</label>
        <input disabled="true" type="date" class="form-control" id="txtdatacriacao" v-model="newTarefa.dataCriacao" />
      </div>
      <button type="submit" class="btn btn-primary">Adicionar Tarefa</button>
    </form>
  </div>
</template>

<style></style>
