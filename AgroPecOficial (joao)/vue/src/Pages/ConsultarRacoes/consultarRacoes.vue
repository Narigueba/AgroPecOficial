<script setup>
import InputCustom from '../../components/InputCustom.vue';
import { ref, onMounted } from 'vue';
import ApiService from './ApiService';


const api = new ApiService();
const racaoId = ref('');
const racaoData = ref(null);
const novaRacao = ref({ nomeRacao: '', peso: 0, unidadeMedida: ''});
const mensagem = ref('');
const listaTipoAnimal = ref(); 

// Função para consultar racaos por ID
const consultarRacaoPorId = async () => {
    try {
        racaoData.value = await api.get(`consultarRacaoPorId?id=${racaoId.value}`);
    } catch (error) {
        console.error(error);
        mensagem.value = 'Erro ao consultar ração por ID';
    }
};

// const selecionarTipoAnimal = async () => {
//     try {
//         listaTipoAnimal.value = await api.getTipoAnimal('selecionarTiposAnimais');
//     } catch (error) {
//         console.error(error);
//         mensagem.value = 'Erro ao selecionar racao' + error.message;
//     }
// };

// Função para selecionar todos as racoes
const selecionarRacoes = async () => {
    try {
        racaoData.value = await api.get('selecionarRacoes');
    } catch (error) {
        console.error(error);
        mensagem.value = 'Erro ao selecionar ração' + error.message;
    }
};

// Função para inserir uma nova racao
const inserirRacao = async () => {
    try {
        const resposta = await api.post('inserirRacao', novaRacao.value);
        mensagem.value = 'Racao inserido com sucesso!';
        console.log(resposta);
    } catch (error) {
        console.error(error);
        mensagem.value = 'Erro ao inserir racao' + error.message;
    }
};

// Função para atualizar uma racao existente
const atualizarRacao = async () => {
    try {
        const resposta = await api.put('atualizarRacao',racaoId.value, novaRacao.value);
        mensagem.value = 'Ração atualizada com sucesso!';
        console.log(resposta);
    } catch (error) {
        console.error(error);
        mensagem.value = 'Erro ao atualizar ração';
    }
};

// Função para deletar uma racao
const deletarRacao = async () => {
    try {
        const resposta = await api.delete(`deletarRacao?id=${racaoId.value}`);
        mensagem.value = 'Ração deletada com sucesso!';
        console.log(resposta);
    } catch (error) {
        console.error(error);
        mensagem.value = 'Erro ao deletar ração';
    }
};

 onMounted(() => {
    selecionarRacoes();
 });

 
</script>
<template>
        <div>
            <div class="container-content">
                <div class="router-link-back">
                    <RouterLink to="/racao"><i class="pi pi-angle-left back"></i></RouterLink>
                </div>        
                <div class="dados-container">
                    <ul>
                        <li v-for="racao in racaoData" :key="racao.id" :class="{ importante: racao.peso > 5 }" class="item-racao">
                            <div>
                                <img :src="racao.imagem" alt="" class="img">
                            </div>
                            <div class=" container-dados-recebidos grow">
                                <div class="dados-recebidos grow">
                                    <div class="dados-nome">
                                        <p class="w-700">Nome:</p>
                                        <p class="w-300">{{ racao.nomeRacao }}</p>
                                    </div>
                                    <div class="dados-peso">
                                        <p class="w-700">Peso:</p>
                                        <div class="dados-valor-peso">
                                            <p class="w-300">{{ racao.peso }}</p>
                                            <p class="racao-medida w-300">{{ racao.unidadeMedida }}</p>
                                        </div>
                                    </div>
                                </div>
                                <div class="racao-atualizar-deletar">
                                    <button @click="atualizarRacao" class="btn atualizar-btn">Atualizar</button>
                                    <button @click="deletarRacao" class="btn deletar-btn">Deletar</button>
                                </div>
                            </div>

                        </li>
                    </ul>
                </div>
            </div>
        </div>     
        <!-- <p class="mensagem">{{ mensagem }}</p> -->



            
    
</template>
<style scoped>

    .img{
        max-width: 100%;
        border-radius: 10px 10px 0 0;
    }

    .dados-container{
        margin: 0 auto;
}
    ul{
    padding: 0 5rem;
    display: flex;
    justify-content: center;
    flex-wrap: wrap;
    gap: 2rem;
    margin-bottom: 4rem;
    }
    .item-racao{
        display: flex;
        flex-direction: column;
        align-items: center;
        max-width: 440px;
    }
    .container-dados-recebidos{
        display: flex;
        /* flex-direction: column; */
        background-image: linear-gradient( 109.6deg,  rgba(61,131,97,1) 11.2%, rgba(28,103,88,1) 91.1% );
        color: white;
        width: 100%;
        padding: 1rem 1.5rem;
        border-radius: 0 0 10px 10px ;
        gap: 1rem;      
    }
    .grow{
        flex: 1 0 0;
    }
    .dados-recebidos{
        display: flex;
        flex-direction: column;
    }
    .dados-nome{
        display: flex;
        gap: 0.5rem;
    }
    .dados-peso{
        display: flex;
        gap: 0.5rem;
    }
    .dados-valor-peso{
        display: flex;
        gap: 0.1rem;
    }
    .racao-atualizar-deletar{
        display: flex;
        flex-direction: column;
        gap: .5rem;
    }

    @media (min-width: 37.56rem) {
        .container-dados-recebidos{
            padding: 2rem 2.5rem;
            flex-direction: column;
        }
    }




</style>