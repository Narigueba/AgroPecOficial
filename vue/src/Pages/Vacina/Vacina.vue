<script setup>
import InputCustom from '../../components/InputCustom.vue';
import { ref, onMounted } from 'vue';
import ApiService from './ApiService';

const api = new ApiService();
const idVacina = ref('');
const vacinaData = ref(null);
const novaVacina = ref({ tipoVacina: ''});
const mensagem = ref('');

const consultarVacinasPorId = async () => {
    try {
        vacinaData.value = await api.get(`consultarVacinasPorId?id=${idVacina.value}`);
    } catch (error) {
        console.error(error);
        mensagem.value = 'Erro ao consultar vacina por ID';
    }
};

const selecionarVacinas = async () => {
    try {
        vacinaData.value = await api.get('selecionarVacinas');
    } catch (error) {
        console.error(error);
        mensagem.value = 'Erro ao selecionar vacinas';
    }
};

const inserirVacina = async () => {
    try {
        const resposta = await api.post('inserirVacina', novaVacina.value);
        mensagem.value = 'Vacina inserida com sucesso!';
        console.log(resposta);
    } catch (error) {
        console.error(error);
        mensagem.value = 'Erro ao inserir vacina';
    }
};

const atualizarVacina = async () => {
    try {
        const resposta = await api.put('atualizarVacina', idVacina.value, novaVacina.value);
        mensagem.value = 'Vacina atualizada com sucesso!';
        console.log(resposta);
    } catch (error) {
        console.error(error);
        mensagem.value = 'Erro ao atualizar vacina';
    }
};

const deletarVacina = async () => {
    try {
        const resposta = await api.delete(`deletarVacina?id=${idVacina.value}`);
        mensagem.value = 'Vacina deletada com sucesso!';
        console.log(resposta);
    } catch (error) {
        console.error(error);
        mensagem.value = 'Erro ao deletar vacina';
    }
};

</script>

<template>
    <div>
        <!-- Input para consultar vacina por ID -->
         <InputCustom label="ID da Vacina" v-model="idVacina" />
        <button @click="consultarVacinasPorId">Consultar Vacina por ID</button>

        <!-- Botão para selecionar todas as vacinas -->
        <button @click="selecionarVacinas">Selecionar Vacina</button>

        <!-- Inputs para inserir nova vacina -->
        <h3>Inserir Nova Vacina</h3>
        <InputCustom label="Tipo da Vacina" v-model="novaVacina.tipoVacina" />
        <button @click="inserirVacina">Inserir Vacina</button>

        <!-- Botão para atualizar uma vacina existente -->
        <button @click="atualizarVacina">Atualizar Vacina</button>

        <!-- Botão para deletar uma vacina -->
        <button @click="deletarVacina">Deletar Vacina</button>

        <!-- Exibição de mensagem -->
        <p>{{ mensagem }}</p>

        <!-- Exibição de dados da vacina consultada -->
        <div v-if="vacinaData">
            <h4>Detalhes da Vacina:</h4>
            <pre>{{ vacinaData }}</pre>
        </div>
    </div>
</template>