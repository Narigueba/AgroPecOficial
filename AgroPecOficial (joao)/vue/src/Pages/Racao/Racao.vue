<script setup>
import InputCustom from '../../components/InputCustom.vue';
import { ref, onMounted } from 'vue';
import ApiService from './ApiService';
import { useRoute } from 'vue-router';


const api = new ApiService();
const route = useRoute();
const racaoId = ref('');
const racaoData = ref(null);
const novaRacao = ref({ nomeRacao: '', peso: 0, unidadeMedida: ''});
const mensagem = ref('');
const listaTipoAnimal = ref(); 

// Função para consultar racaos por ID
const consultarRacaoPorId = async () => {
console.log("racaoId", racaoId.value)
    // try {
    //     racaoData.value = await api.get(`consultarRacaoPorId?id=${racaoId.value}`);
    // } catch (error) {
    //     console.error(error);
    //     mensagem.value = 'Erro ao consultar ração por ID';
    // }
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

// onMounted(() => {
//     selecionarTipoAnimal();
// });
</script>

<template>
    <div class="container-flex">
        <div class="padding grow">
            <!-- <h1 class="router-title">Ração</h1> -->
            <div class="container-consultar_racao bottom">
                <h4 class="container-title">Consultar Ração</h4>
                <InputCustom v-model="racaoId" placeholder="Cod. da Ração" class="inserir-cod"/>
                <div class="consultar-racao-flex">
                    <!-- passando id por parametro URL -->
                    <RouterLink :to="`/consultarRacao/${racaoId}`" class="btn consultar-btn">Consultar Ração</RouterLink>
                    <!-- <button @click="consultarRacaoPorId">teste</button> -->
                    <RouterLink to="/consultarRacoes" class="btn selecionar-btn">Selecionar Rações</RouterLink>
                </div>
            </div>
            <div class="container-inserir_racao">
                <h4 class="container-title">Inserir Nova Ração</h4>
                <div class="inserir-dados">
                    <!-- Inputs para inserir nova racao -->
                    <InputCustom v-model="novaRacao.nomeRacao" placeholder="Nome da Ração" class="inserir-cod" />
                    <InputCustom v-model="novaRacao.peso" placeholder="Peso da Ração" class="inserir-cod" />
                    <InputCustom v-model="novaRacao.unidadeMedida" placeholder="Unidade de Medida" class="inserir-cod" />
                </div>
                <div class="inserir-racao-flex">
                    <button @click="inserirRacao" class="btn inserir-btn">Inserir Ração</button>
                </div>
                <p>{{ mensagem }}</p>
            </div>
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

        .inserir-cod{
            margin: 1rem 0 1rem;
        }

        .consultar-racao-flex{
            display: flex;
            gap: .5rem;
        }

        .inserir-racao-flex{
            display: flex;
            gap: .5rem;
        }

        .inserir-btn{
            background-image: linear-gradient( 109.6deg,  rgba(61,131,97,1) 11.2%, rgba(28,103,88,1) 91.1% );
        }

        .atualizar-btn{
            background-image: radial-gradient( circle 957px at 8.7% 50.5%,  rgba(246,191,13,1) 0%, rgba(249,47,47,1) 90% );
        }

        .deletar-btn{
            background-image: radial-gradient( circle 817.6px at 10% 20%,  rgba(178,34,34,1) 0%, rgba(255,87,51,1) 41.9%, rgba(255,165,0,1) 100.2% );
        }

        .mensagem{
            text-align: center;
            margin: 1.5rem 0;
        }


</style>
