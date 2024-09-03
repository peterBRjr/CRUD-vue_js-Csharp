<script setup>
import { useRouter , RouterView } from 'vue-router';

const router = useRouter();

const telainicial = () => {
  router.push('/');
};
</script>

<template>

<nav class="navbar" style="background-color: #A9A9A9 ;">
  <div class="container-fluid">
      <a class="navbar-brand destaque" href="#" @click.prevent="telainicial">Tarefas</a>
    </div>
</nav>
  <div class="container">
    <RouterView />
  </div>
  
</template>


<style scoped>
.destaque {
  font-size: 1.5rem; /* Aumenta o tamanho da fonte */
  color: #ffffff; /* Define a cor do texto para branco */
  font-weight: bold; /* Torna o texto em negrito */
  text-decoration: none; /* Remove o sublinhado do link */
}

.destaque:hover {
  color: black; /* Altera a cor do texto quando o mouse está sobre ele */
}
</style>