<template>
    <div class="container-flex">
        <div class="container-config grow padding">
            <RouterLink to="/usuario" class="btn-config consultar-btn row-container">
                <div class="row-flex">
                    <i class="config-pi pi pi-user "></i>
                    <h4>Usuário</h4>
                </div>
                <i class="config-pi pi pi-angle-right"></i>
            </RouterLink>
            <RouterLink to="/favoritos" class="btn-config consultar-btn row-container">
                <div class="row-flex">
                    <i class="config-pi pi pi-star "></i>
                    <h4>Favoritos</h4>
                </div>
                <i class="config-pi pi pi-angle-right"></i>
            </RouterLink>
            <RouterLink to="/suporte" class="btn-config consultar-btn row-container">
                <div class="row-flex">
                    <i class="config-pi pi pi-headphones"></i>
                    <h4>Suporte</h4>
                </div>
                <i class="config-pi pi pi-angle-right"></i>
            </RouterLink>
            <RouterLink to="/logout" class="btn-config consultar-btn row-container">
                <div class="row-flex">
                    <i class="config-pi pi pi-sign-out color-red"></i>
                    <h4 class="color-red">Sair da Conta</h4>
                </div>
                <i class="config-pi pi pi-angle-right"></i>
            </RouterLink>
        </div> 
        <nav class="container-button">
            <RouterLink to="/" class="button-links"><i class="pi pi-home"></i></RouterLink>
            <RouterLink to="/Animal" class="button-links"><i class="pi pi-id-card"></i></RouterLink>
            <RouterLink to="/racao" class="button-links"><i class="pi pi-warehouse"></i></RouterLink>
            <RouterLink to="/vacina" class="button-links"><i class="pi pi-heart"></i></RouterLink>
            <RouterLink to="/configuracao" class="button-links"><i class="pi pi-cog"></i></RouterLink>
        </nav>
    </div>   
</template>

<style scoped>

    h4{
        font-size: 20px;
        color: #2C5C18;
    }
    .btn-config{
        text-decoration: none;
    }
    .container-config{
        display: flex;
        flex-direction: column;
        gap: 1.5rem;
        width: 100vw;
    }
    .row-container{
        display: flex;
        align-items: center;
        justify-content: space-between;
        
    }
    .row-flex{
        display: flex;
        gap: 0.7rem;
        align-items: center;
    }
    .config-pi{
        font-size: 25px;
        color: rgb(59, 59, 59);
    }
    .color-red{
        color: rgb(228, 26, 26);
    }
    


</style>