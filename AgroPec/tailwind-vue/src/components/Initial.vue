<template>
    <div class="container">
        <!-- 
            V-For:
            Podemos utilizar a diretiva v-for para renderizar uma lista de elementos com base nos dados de um Array. 
            A diretiva requer uma sintaxe especial na forma de item in items, onde items é a fonte de dados e item é 
            um apelido para o elemento que estiver sendo iterado

            V-Bind:
            ​Para dar uma dica ao Vue e ele poder rastrear a identidade de cada nó e assim reutilizar e reordenar 
            elementos existentes, defina um atributo key único para cada item.

            De fato, é recomendado oferecer um atributo key para v-for sempre que possível, a menos que esteja iterando
            conteúdo DOM simples, ou esteja intencionalmente se apoiando no comportamento padrão para ganho de desempenho.
        -->
        <div 
        v-for="obj in todos"
        v-bind:key="obj.id"
        class="todos-item"
        >
            <h6>{{ obj.title }}</h6>
            <h6>{{ obj.id }}</h6>
            <h6>{{ obj.userId }}</h6>
            <h6>{{ obj.completed }}</h6>
        </div>
    </div>
</template>

<script>

  import 'primeicons/primeicons.css'
  
    export default{
        name: 'App',
        data () {
            return {
                // Array
                todos: [
                {
                "userId": 1,
                "id": 1,
                "title": "delectus aut autem",
                "completed": false
        },
            {
                "userId": 1,
                "id": 2,
                "title": "quis ut nam facilis et officia qui",
                "completed": false
        },
            {
                "userId": 1,
                "id": 3,
                "title": "fugiat veniam minus",
                "completed": false
        },
            {
                "userId": 1,
                "id": 4,
                "title": "et porro tempora",
                "completed": true
        },

                ]
            }
        }
    }

</script>

<style>
    #app{
        height: 100vh;
        width: 100vw;
    }
    :root{
        --white: #ffffff;
        --light-green: #68DC39;
        --orange: #EB5E1C;
    }
    h1{
        font-size: 68px;
    }
    h2{
        font-size: 40px;
    }
    h3{
        font-size: 28px;
    }
    h4{
        font-size: 24px;
    }
    h5{
        font-size: 20px;
    }
    h6{
        font-size: 16px;
    }

    body{
        width: 100vw;
        height: 100vh;
        padding: 0;
        margin: 0;
    }
    #app{
        background: var(--light-green);
    }
    .container{

        height: 100vh;
        width: 100vw;
        margin: 0;
        padding: 0;
        display: flex;
        flex-direction: column;
        align-items: center;
        justify-content: center;
        margin: auto;

    }
    .text-init{
        color: var(--white);
        margin: 3rem 0 1rem
    }
    .btn-init{
        background-color: var(--orange);
        padding: 1rem 1.1em;
        border-radius: 50%;
        color: var(--white);
    }
    .pi-angle-right{
        font-size: 4rem;
    }
    .todos-item{
        background-color: rgb(218, 16, 16);
        margin-top: 1rem;
        padding: 0.4rem 4rem;
        border-radius: 50px;
        box-shadow: 3px 5px var(--orange);
    }

</style>