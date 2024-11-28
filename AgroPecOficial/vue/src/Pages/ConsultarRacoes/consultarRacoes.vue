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
            <RouterLink to="/racao"><i class="pi pi-angle-left back"></i></RouterLink>
        </div>
        <div class="container-mensagem">
                <!-- Botão para selecionar todas as racoes -->
                <!--     <button 
                class="btn selecionar-btn"  
                @click="selecionarRacoes">Selecionar Rações
                </button>-->
            <p class="mensagem">{{ mensagem }}</p>
        <!-- Exibição de dados da racao consultada -->
        <!-- <div v-if="racaoData"> 
            <h4>Detalhes da Racao:</h4> 
            <pre>{{ racaoData }}</pre> 
        </div> -->
        <div class="container-dados-enviados">
            <p>{{ racaoData }}</p>
        </div>
    </div>
        
    </div>


            
    
</template>
<style scoped>
.back{
    color: white;
    font-size: 1rem;
    text-align: left;
    margin-bottom: 2rem;
    background-image: linear-gradient( 109.6deg,  rgba(61,131,97,1) 11.2%, rgba(28,103,88,1) 91.1% );
    padding: .6rem;
    border-radius: 50%;
}

</style>