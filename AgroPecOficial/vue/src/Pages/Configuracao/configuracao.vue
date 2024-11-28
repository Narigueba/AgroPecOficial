<template>
        <div class="container-config">
            <nav class="container-button">
                <RouterLink to="/" class="button-links"><i class="pi pi-home"></i></RouterLink>
                <RouterLink to="/Animal" class="button-links"><i class="pi pi-id-card"></i></RouterLink>
                <RouterLink to="/racao" class="button-links"><i class="pi pi-warehouse"></i></RouterLink>
                <RouterLink to="/vacina" class="button-links"><i class="pi pi-heart"></i></RouterLink>
                <RouterLink to="/configuracao" class="button-links"><i class="pi pi-cog"></i></RouterLink>
            </nav>
            <div class="row-container">
                <div class="row-flex">
                    <i class="config-pi pi pi-user "></i>
                    <h4>Usuário</h4>
                </div>
                <i class="config-pi pi pi-angle-right"></i>
            </div>
            <div class="row-container">
                <div class="row-flex">
                    <i class="config-pi pi pi-star"></i>
                    <h4>Favoritos</h4>
                </div>
                <i class="config-pi pi pi-angle-right"></i>
            </div>
            <div class="row-container">
                <div class="row-flex">
                    <i class="config-pi pi pi-headphones"></i>
                    <h4>Suporte</h4>
                </div>
                <i class="config-pi pi pi-angle-right"></i>
            </div>
            <div class="row-container">
                <div class="row-flex">
                    <i class="config-pi pi pi-sign-out color-red"></i>
                    <h4 class="color-red">Sair da Conta</h4>
                </div>
                <i class="config-pi pi pi-angle-right color-red"></i>
            </div>
        </div>    
</template>

<style scoped>

    h4{
        font-size: 20px;
        color: #2C5C18;
    }
    .container-config{
        display: flex;
        flex-direction: column;
        gap: 1rem;
        width: 100vw;
    }
    .row-container{
        display: flex;
        align-items: center;
        justify-content: space-between;
        
    }
    .row-flex{
        display: flex;
        gap: 0.5rem;
        align-items: center;
    }
    .config-pi{
        font-size: 20px;
        color: rgb(59, 59, 59);
    }
    .color-red{
        color: rgb(228, 26, 26);
    }


</style>