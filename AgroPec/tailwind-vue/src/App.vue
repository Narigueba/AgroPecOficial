<template>
  <Initial v-show="showInitial"></Initial>
  <!-- 
    Renderização Condicional

    v-if:
    A diretiva v-if é usada para renderizar condicionalmente um bloco. 
    O bloco só será renderizado se a expressão da diretiva retornar um valor verdadeiro.

    v-show:
    Outra opção para mostrar condicionalmente um elemento é a diretiva v-show.
    A utilização é basicamente a mesma.
    A diferença é que um elemento com v-show sempre será renderizado e permanecerá 
    no DOM; v-show simplesmente alterna a propriedade CSS display do elemento.

    v-else:
    Um elemento v-else deve seguir imediatamente um elemento v-if ou v-else-if, caso 
    contrário não será reconhecido.
   -->
  

  <!-- <div>
      <h1 class="name" v-show="showname">Nome: {{ name }}</h1>
      <h1 class="lastName" v-show="showlastName" >Sobrenome: {{ lastName }}</h1>
  </div> -->
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
        todos: [
          {text: 'Aprender JS'},
          {text: 'Aprender Vue'},
          {text: 'Criar algo incrível'},
        ]

      }
    }
  }
</script>