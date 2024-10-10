<template>
  <Initial v-show="showInitial"></Initial>

  <div>
      <h1 class="name" v-show="showname">Nome: {{ name }}</h1>
      <h1 class="lastName" v-show="showlastName" >Sobrenome: {{ lastName }}</h1>
  </div>
</template>

<script>
  import Initial from './components/Initial.vue'

  export default{
    name: 'App',
    components: {
      Initial
    },
    data () {
      return {
        showInitial: true,
        name: 'Jon',
        lastName: 'Snow',
        showname: false,
        showlastName: false,

      }
    }
  }
</script>