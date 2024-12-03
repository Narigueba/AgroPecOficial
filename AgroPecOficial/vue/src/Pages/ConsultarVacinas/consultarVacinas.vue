<script setup>
import InputCustom from '../../components/InputCustom.vue';
import { ref, onMounted } from 'vue';
import ApiService from '../Vacina/ApiService';

const api = new ApiService();
const vacinaId = ref('');
const vacinaData = ref(null);
const novaVacina = ref({ tipoVacina: ''});
const mensagem = ref('');
const listaTipoAnimal = ref(); 

// Função para consultar racaos por ID
const consultarVacinasPorId = async () => {
    try {
        vacinaData.value = await api.get(`consultarVacinasPorId?id=${vacinaId.value}`);
    } catch (error) {
        console.error(error);
        mensagem.value = 'Erro ao consultar vacina por ID';
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
const selecionarVacinas = async () => {
    try {
        vacinaData.value = await api.get('selecionarVacinas');
    } catch (error) {
        console.error(error);
        mensagem.value = 'Erro ao selecionar vacina' + error.message;
    }
};

// Função para inserir uma nova racao
const inserirVacina = async () => {
    try {
        const resposta = await api.post('inserirVacina', novaVacina.value);
        mensagem.value = 'Vacina inserida com sucesso!';
        console.log(resposta);
    } catch (error) {
        console.error(error);
        mensagem.value = 'Erro ao inserir vacina' + error.message;
    }
};

// Função para atualizar uma racao existente
const atualizarVacina = async () => {
    try {
        const resposta = await api.put('atualizarVacina',vacinaId.value, novaVacina.value);
        mensagem.value = 'Vacina atualizada com sucesso!';
        console.log(resposta);
    } catch (error) {
        console.error(error);
        mensagem.value = 'Erro ao atualizar vacina';
    }
};

// Função para deletar uma racao
const deletarVacina = async () => {
    try {
        const resposta = await api.delete(`deletarVacina?id=${vacinaId.value}`);
        mensagem.value = 'Vacina deletado com sucesso!';
        console.log(resposta);
    } catch (error) {
        console.error(error);
        mensagem.value = 'Erro ao deletar vacina';
    }
};

onMounted(() => {
    selecionarVacinas();
});
</script>
<template>
    <div>
        <div class="router-link-back">
            <RouterLink to="/vacina"><i class="pi pi-angle-left back"></i></RouterLink>
        </div>
        <div class="container-mensagem">
            <!-- <p class="mensagem">{{ mensagem }}</p> -->
            <ul>
                <li v-for="vacina in vacinaData" :key="vacina.id" class="item-vacina">
                    <img src="" alt="">
                    <div class="nome-vacina">
                        <p class="w-700">Nome: </p>
                        <p class="w-200">{{ vacina.tipoVacina }}</p>
                    </div>    
                    <div class="racao-atualizar-deletar">
                        <button @click="atualizarVacina" class="btn atualizar-btn">Atualizar</button>
                        <button @click="deletarVacina" class="btn deletar-btn">Deletar</button>
                    </div>
                </li>
            </ul>
        </div>
    </div>
    </template>
    <style scoped>
        .container-mensagem{
            display: flex;
            justify-content: center;
            gap: 5rem;
        }
        .container-mensagem ul{
            padding: 0;
            display: flex;
            justify-content: center;
            flex-wrap: wrap;
            gap: 2rem;
            margin-bottom: 4rem;
        }
        .item-vacina{
            display: flex;
            background-image: linear-gradient( 109.6deg,  rgba(61,131,97,1) 11.2%, rgba(28,103,88,1) 91.1% );
            color: white;
            padding: 1rem;
            border-radius: 10px ;
            box-shadow: 0 0 10px 1px rgba(0, 0, 0, 0.473);
            gap: 1rem;  
        }
        .nome-vacina{
            display: flex;
            flex: 1 0 0;
            color: white;
            gap: 0.5rem;
        }
        .racao-atualizar-deletar{
        display: flex;
        flex-direction: column;
        gap: .5rem;
        }

    </style>