<script setup>
</script>

<template>
    <nav>
      <RouterLink to="/">Go to Home</RouterLink>
      <RouterLink to="/about">Go to About</RouterLink>
      <RouterLink to="/racao">Ração</RouterLink>
      <RouterLink to="/tipo-animal">Tipo do Animal</RouterLink>
    </nav>
    <main>
      <RouterView />
    </main>
</template>

<style scoped>

</style>
