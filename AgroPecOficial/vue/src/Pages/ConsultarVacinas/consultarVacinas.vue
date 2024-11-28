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
        <div class="mensagem">
            <!-- Exibição de mensagem -->
            <p>{{ mensagem }}</p>

            <!-- Exibição de dados da racao consultada -->
            <div v-if="vacinaData"> 
                <h4>Detalhes da Vacina:</h4> 
                <pre>{{ vacinaData }}</pre> 
            </div>
        </div>
</template>