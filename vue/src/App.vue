<script setup>
import { RouterLink } from 'vue-router';

</script>

<template>
    <nav>
      <RouterLink to="/">Go to Home</RouterLink>
      <RouterLink to="/about">Go to About</RouterLink>
      <RouterLink to="/racao">Ração</RouterLink>
      <RouterLink to="/tipo-animal">Tipo do Animal</RouterLink>
      <RouterLink to="/vacina">Vacina</RouterLink>
      <RouterLink to="/animal">Animal</RouterLink>
      <RouterLink to="/animal-vacina">Animal e Vacina</RouterLink>
    </nav>
    <main>
      <RouterView />
    </main>
</template>

<style scoped>

</style>
