<template>
    <div class="container">
        <img src="../assets/logotipo.png" alt="Imagem Agro-Pec" class="img">
        <h3 class="text-init">Iniciar</h3>
        <a href="../App.vue" class="btn-init"><i class="pi pi-angle-right"></i></a>
    </div>
</template>

<script>

  import 'primeicons/primeicons.css'
  
    export default{
    }

</script>

<style>
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
    #app{
        background: var(--light-green);
    }
    .container{
        height: 100vh;
        width: 100vw;
        display: flex;
        flex-direction: column;
        align-items: center;
        justify-content: center;
        margin: auto;

    }
    .text-init{
        color: var(--white);
        margin: 5rem 0 1rem
    }
    .btn-init{
        background-color: var(--orange);
        padding: 1rem 1.1em;
        border-radius: 50%;
        color: var(--white);
    }
    .pi-angle-right{
        font-size: 7rem;
    }

</style>