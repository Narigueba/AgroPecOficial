<script setup>
</script>

<template>

      <main class="container">
        <nav class="container-button">
          <RouterLink to="/" class="button-links"><i class="pi pi-home"></i></RouterLink>
          <RouterLink to="/Animal" class="button-links"><i class="pi pi-id-card"></i></RouterLink>
          <RouterLink to="/racao" class="button-links"><i class="pi pi-warehouse"></i></RouterLink>
          <RouterLink to="/vacina" class="button-links"><i class="pi pi-heart"></i></RouterLink>
          <RouterLink to="/configuracao" class="button-links"><i class="pi pi-cog"></i></RouterLink>
        </nav>
        <RouterView class="router"/>
      </main>



</template>

<style>
      @import url('https://fonts.googleapis.com/css2?family=Playfair+Display:ital,wght@0,400..900;1,400..900&family=Poppins:ital,wght@0,100;0,200;0,300;0,400;0,500;0,600;0,700;0,800;0,900;1,100;1,200;1,300;1,400;1,500;1,600;1,700;1,800;1,900&display=swap');

      h1{
        font-size: 2.1rem;
      }

      h2{
        font-size: 1.8rem;
      }
   
      h3{
        font-size: 1.5rem;
      }

      h4{
        font-size: 1.2rem;
      }

      h5{
        font-size: 1rem;
      }

      h6{
        font-size: 0.8rem;
      }


      
      :root{
        --color-white: white;
        --light-green: #86E361;
        --green: #68DC39;
        --dark-green: #2C5C18;
        --orange: #EB5E1C;
        --brown: #7D2D08;
        --red: rgb(228, 9, 9);
      }

      .html{
        font-weight: 100;
        font-size: 62.5%;
      }

      .container{
        font-family: "Poppins", serif;
        /* display: flex;
        flex-direction: column-reverse;
        justify-content: space-between;
        align-items: center; */
        background-color: white;
        min-height: 100vh;
        position: relative;
      }

      .container-button{
        width: 100%;
        display: flex;
        justify-content: center;
        padding: 1.5rem;
        gap: 1.3rem;
        background-image: linear-gradient( 109.6deg,  rgba(61,131,97,1) 11.2%, rgba(28,103,88,1) 91.1% );
        box-shadow: 0 0 10px rgba(0, 0, 0, 0.541);
        position: fixed;
        bottom: 0px;
        

      }

      .button-links{
        display: flex;
        align-items: center;
        justify-content: center;
        text-decoration: none;
        color: white;
        padding: .7rem;
        border-radius: 10px;
      }

      .button-links:hover{
          box-shadow: inset 0 0 5px 1px #00000063;
      }

      .pi{
        font-size: 1.5rem;
      }

      .router{
        padding: 2rem 2rem 0;
      }

      .router-title{
        text-align: center;
        font-weight: bold;
        color: rgb(48, 48, 48);
      }





</style>
