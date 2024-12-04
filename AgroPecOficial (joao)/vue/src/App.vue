<script setup>
</script>

<template>

      <main class="container">
        <!-- <nav class="container-button">
          <RouterLink to="/" class="button-links"><i class="pi pi-home"></i></RouterLink>
          <RouterLink to="/Animal" class="button-links"><i class="pi pi-id-card"></i></RouterLink>
          <RouterLink to="/racao" class="button-links"><i class="pi pi-warehouse"></i></RouterLink>
          <RouterLink to="/vacina" class="button-links"><i class="pi pi-heart"></i></RouterLink>
          <RouterLink to="/configuracao" class="button-links"><i class="pi pi-cog"></i></RouterLink>
        </nav> -->
        <RouterView/>
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
      ul{
        list-style-type: none;
      }
      input {
        padding: 10px;
        font-size: .8rem;
        border: 1px solid #ccccccc5;
        border-radius: .5rem;
        width: 100%;
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

      .back{
            color: white;
            font-size: 5rem;
            text-align: left;
            margin-bottom: 2rem;
            background-image: linear-gradient( 109.6deg,  rgba(61,131,97,1) 11.2%, rgba(28,103,88,1) 91.1% );
            padding: .4rem;
            border-radius: 50%;
        }

      .router-link-back{
        display: flex;
        justify-content: left;
        padding: 1.5rem;
      }

      .container{
        font-family: "Poppins", serif;
        background-color: white;
        min-height: 100vh;
        position: relative;
      }

      .container-title{
            font-size: 1.25rem;
            text-transform: capitalize;
            border-bottom: 2px solid #2C5C18;
            max-width: max-content;
            color: #2C5C18;
            font-weight: 400;
        }

      .container-button{
        display: flex;
        justify-content: center;
        padding: 1.5rem;
        gap: 1.3rem;
        background-image: linear-gradient( 109.6deg,  rgba(61,131,97,1) 11.2%, rgba(28,103,88,1) 91.1% );
        box-shadow: 0 0 10px rgba(0, 0, 0, 0.541);
        position: fixed;
        width: 100%;
        bottom: 0;
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

      .padding{
        padding: 2rem 2rem;
      }

      .router-title{
        text-align: center;
        font-weight: bold;
        color: rgb(48, 48, 48);
      }

      .container-flex{
        display: flex;
        flex-direction: column;
        height: 100vh;
      }

      .grow{
            flex: 1 0 0;
      }

      .btn{
            font-size: .8rem;
            flex: 1 0 0;
            padding: .6rem 1rem;
            background-image: linear-gradient( 109.6deg,  rgba(61,131,97,1) 11.2%, rgba(28,103,88,1) 91.1% );
            color: white;
            border: none;
            border-radius: .5rem;   
            box-shadow: 5px 5px 10px rgba(105, 105, 105, 0.308);
            text-decoration: none;
            display: flex;
            align-items: center;
            justify-content: center;
            text-align: center;
        }

      .atualizar-btn{
            background-image: radial-gradient( circle 957px at 8.7% 50.5%,  rgba(246,191,13,1) 0%, rgba(249,47,47,1) 90% );
            box-shadow: 5px 5px 10px rgba(0, 0, 0, 0.318);
        }

      .deletar-btn{
            background-image: radial-gradient( circle 817.6px at 10% 20%,  rgba(178,34,34,1) 0%, rgba(255,87,51,1) 41.9%, rgba(255,165,0,1) 100.2% );
            box-shadow: 5px 5px 10px rgba(0, 0, 0, 0.318);
        } 

      .bottom{
          margin-bottom: 2.5rem;
        }

      .w-700{
          font-weight: 700;
        }

      .w-200{
        font-weight: 300;
    }
      
      
        
      @media (min-width: 48.75rem) {
        .container-flex{
          flex-direction: row-reverse;
        }

        .container-button{
          height: 100vh;
          position: fixed;
          left: 0;
          flex-direction: column;
          justify-content: flex-start;
          padding: 3rem 2.2rem 0;
          box-shadow: 10px 0 10px 0 rgba(0, 0, 0, 0.212);
          width: inherit;
        }

        .pi{
          font-size: 1.7rem;
        }

        .container-title{
          font-size: 1.6rem;
        }

        input{
          padding: 15px;
        } 

        .btn{
          font-size: .9rem;
          padding: .9rem 4rem;
        }
        .padding{
          padding: 3rem 5% 3rem 20%;
        }
        .bottom{
          margin-bottom: 3.5rem;
        }  
      }

      @media (min-width: 71.68rem){
        .padding{
          padding: 3rem 25% 3rem 30%;
        }

      }





</style>
