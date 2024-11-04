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
        mensagem.value = 'Erro ao consultar racao por ID';
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
        mensagem.value = 'Erro ao selecionar racao' + error.message;
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
        mensagem.value = 'Racao atualizado com sucesso!';
        console.log(resposta);
    } catch (error) {
        console.error(error);
        mensagem.value = 'Erro ao atualizar racao';
    }
};

// Função para deletar uma racao
const deletarRacao = async () => {
    try {
        const resposta = await api.delete(`deletarRacao?id=${racaoId.value}`);
        mensagem.value = 'Racao deletado com sucesso!';
        console.log(resposta);
    } catch (error) {
        console.error(error);
        mensagem.value = 'Erro ao deletar racao';
    }
};

// onMounted(() => {
//     selecionarTipoAnimal();
// });
</script>

<template>
    <div>
        <!-- Input para consultar racao por ID -->
        <InputCustom label="ID da Racao" v-model="racaoId" />
        <button @click="consultarRacaoPorId">Consultar Racao por ID</button>
        
        <!-- Botão para selecionar todas as racoes -->
        <button @click="selecionarRacoes">Selecionar Racao</button>
        
        <!-- Inputs para inserir nova racao -->
        <h3>Inserir Nova Racao</h3>
        <InputCustom label="Nome da Racao" v-model="novaRacao.nomeRacao" />
        <InputCustom label="Peso da Racao" v-model="novaRacao.peso" />
        <InputCustom label="Unidade de Medida" v-model="novaRacao.unidadeMedida" />
        <button @click="inserirRacao">Inserir Racao</button>
        <!-- <div>
            <select>
                <option v-for="item in listaTipoAnimal"  :key="item.idTipoAnimal">{{ item.animal }}</option>
            </select>
        </div> -->

        <!-- Botão para atualizar uma racao existente -->
        <button @click="atualizarRacao">Atualizar Racao</button>
        
        <!-- Botão para deletar uma racao -->
        <button @click="deletarRacao">Deletar Racao</button>
        
        <!-- Exibição de mensagem -->
        <p>{{ mensagem }}</p>

        <!-- Exibição de dados da racao consultada -->
         <div v-if="racaoData"> 
             <h4>Detalhes da Racao:</h4> 
             <pre>{{ racaoData }}</pre> 
        </div>

        <!-- <table>
            <thead>
                <tr>
                    <th>ID</th>
                    <th>Nome</th>
                    <th>Peso</th>
                    <th>Unidade de Medida</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="racao in racaoData" :key="racao.idRacao">
                    <td>{{ racao.idRacao }}</td>
                    <td>{{ racao.nomeRacao }}</td>
                    <td>{{ racao.peso }}</td>
                    <td>{{ racao.unidadeMedida }}</td>
                </tr>
            </tbody>
        </table> -->
    </div>
</template>
