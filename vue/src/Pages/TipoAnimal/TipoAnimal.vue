<script setup>
import InputCustom from '../../components/InputCustom.vue';
import { ref, onMounted } from 'vue';
import ApiService from './ApiService';
const api = new ApiService();
const idTipoAnimal = ref('');
const tipoAnimalData = ref(null);
const novoTipoAnimal = ref({ animal: '', especie: ''});
const mensagem = ref('');

// Função para consultar tipos de animais por ID
const consultarTiposAnimaisPorId = async () => {
    try {
        tipoAnimalData.value = await api.get(`consultarTiposAnimaisPorId?id=${idTipoAnimal.value}`);
    } catch (error) {
        console.error(error);
        mensagem.value = 'Erro ao consultar tipo de animal por ID';
    }
};

// Função para selecionar todos os tipos de animais
const selecionarTiposAnimais = async () => {
    try {    
        tipoAnimalData.value = await api.get('selecionarTiposAnimais');
    } catch (error) {    
        console.error(error);
        mensagem.value = 'Erro ao selecionar tipo de animal';
    }   
};

// Função para inserir um novo tipo de animal
const inserirTiposAnimais = async () => {
    try {
        const resposta = await api.post('inserirTiposAnimais', novoTipoAnimal.value);
        mensagem.value = 'Tipo de animal inserido com sucesso!';
        console.log(resposta);
    } catch (error) {
        console.error(error);
        mensagem.value = 'Erro ao inserir tipo de animal';
    }
};

// Função para atualizar um tipo de animal existente
const atualizarTipoAnimal = async () => {
    try {
        const resposta = await api.put('atualizarTipoAnimal', idTipoAnimal.value, novoTipoAnimal.value);
        mensagem.value = 'Tipo de animal atualizado com sucesso!';
        console.log(resposta);
    } catch (error) {
        console.error(error);
        mensagem.value = 'Erro ao atualizar tipo de animal';
    }
};

// Função para deletar um tipo de animal
const deletarTipoAnimal = async () => {
    try {
        const resposta = await api.delete(`deletarTipoAnimal?id=${idTipoAnimal.value}`);
        mensagem.value = 'Tipo de animal deletado com sucesso!';
        console.log(resposta);
    } catch (error) {
        console.error(error);
        mensagem.value = 'Erro ao deletar tipo de animal';
    }
};

</script>

<template>
    <div>
        <!-- Input para consultar tipos de animais por ID -->
         <InputCustom label="ID do Tipo de Animal" v-model="idTipoAnimal" />
        <button @click="consultarTiposAnimaisPorId">Consultar Tipo de Animal por ID</button>

        <!-- Botão para selecionar todos os tipos de animais -->
        <button @click="selecionarTiposAnimais">Selecionar Tipo de Animal</button>

        <!-- Inputs para inserir novo tipo de animal -->
        <h3>Inserir Novo Tipo de Animal</h3>
        <InputCustom label="Animal" v-model="novoTipoAnimal.animal" />
        <InputCustom label="Especie" v-model="novoTipoAnimal.especie" />
        <button @click="inserirTiposAnimais">Inserir Tipo de Animal</button>

        <!-- Botão para atualizar um tipo de animal existente -->
        <button @click="atualizarTipoAnimal">Atualizar Tipo de Animal</button>

        <!-- Botão para deletar um tipo de animal -->
        <button @click="deletarTipoAnimal">Deletar Tipo de Animal</button>

        <!-- Exibição de mensagem -->
        <p>{{ mensagem }}</p>

        <!-- Exibição de dados do tipo de animal consultado --> 
        <div v-if="tipoAnimalData">
            <h4>Detalhes do Tipo de Animal:</h4>
            <pre>{{ tipoAnimalData }}</pre>
        </div>
    </div>
</template>