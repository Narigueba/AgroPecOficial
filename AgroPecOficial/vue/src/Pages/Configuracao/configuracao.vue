<template>
        <div class="container-config">
            <div class="row-container">
                <div class="row-flex">
                    <i class="pi pi-user"></i>
                    <h4>Usuário</h4>
                </div>
                <i class="pi pi-angle-right"></i>
            </div>
            <div class="row-container">
                <div class="row-flex">
                    <i class="pi pi-star"></i>
                    <h4>Favoritos</h4>
                </div>
                <i class="pi pi-angle-right"></i>
            </div>
            <div class="row-container">
                <div class="row-flex">
                    <i class="pi pi-headphones"></i>
                    <h4>Suporte</h4>
                </div>
                <i class="pi pi-angle-right"></i>
            </div>
            <div class="row-container">
                <div class="row-flex">
                    <i class="pi pi-sign-out color-red"></i>
                    <h4 class="color-red">Sair da Conta</h4>
                </div>
                <i class="pi pi-angle-right color-red"></i>
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
    .pi{
        font-size: 20px;
        color: rgb(59, 59, 59);
    }
    .color-red{
        color: rgb(228, 26, 26);
    }


</style>