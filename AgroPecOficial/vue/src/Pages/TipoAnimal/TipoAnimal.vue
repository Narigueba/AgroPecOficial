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
        <div class="container-consultar_animal">
            <h4 class="container-title">Consultar Animal</h4>
            <!-- Input para consultar tipos de animais por ID -->
            <InputCustom placeholder="Cod. do Animal" v-model="idTipoAnimal" class="inserir-cod" />
            <div class="consultar-animal-flex">
                <RouterLink to="/consultarAnimal" class="btn consultar-btn">Consultar Animal</RouterLink>
                <RouterLink to="/consultarAnimais" class="btn selecionar-btn">Selecionar Animais</RouterLink>

            </div>
        </div>
        <div class="container-inserir_animal">
            <h4 class="container-title">Inserir Novo Animal</h4>
            <div class="inserir-dados">
                <!-- Inputs para inserir novo tipo de animal -->
                <InputCustom placeholder="Nome do Animal" v-model="novoTipoAnimal.animal" class="inserir-cod"/>
                <InputCustom placeholder="Nome da Espécie" v-model="novoTipoAnimal.especie" class="inserir-cod"/>
            </div>
            <div class="inserir-animal-flex">
                <button @click="inserirTiposAnimais" class="btn inserir-btn">Inserir Animal</button>
            </div>
    
            <!-- Botão para atualizar um tipo de animal existente
            <button @click="atualizarTipoAnimal">Atualizar Animal</button>
            Botão para deletar um tipo de animal
            <button @click="deletarTipoAnimal">Deletar Animal</button>  -->
        </div>
        <div class="mensagem">
            <!-- Exibição de mensagem -->
            <p>{{ mensagem }}</p>
            <!-- Exibição de dados do tipo de animal consultado --> 
            <div v-if="tipoAnimalData">
                <h4>Detalhes do Tipo de Animal:</h4>
                <pre>{{ tipoAnimalData }}</pre>
            </div>
        </div>
</div>
</template>

<style scoped>
        .container-consultar_animal{
            margin: 0 0 2.5rem;
        }

        .container-title{
            font-size: 1.25rem;
            text-transform: capitalize;
            border-bottom: 2px solid #2C5C18;
            max-width: max-content;
            color: #2C5C18;
            font-weight: 400;
        }

        .inserir-cod{
            margin: 1rem 0 1rem;
        }

        .consultar-animal-flex{
            display: flex;
            gap: .5rem;
        }

        .btn{
            font-size: .8rem;
            flex: 1 0 0;
            padding: .6rem 1rem;
            background-image: linear-gradient( 109.6deg,  rgba(61,131,97,1) 11.2%, rgba(28,103,88,1) 91.1% );
            color: white;
            border: none;
            border-radius: .5rem;   
            box-shadow: 5px 5px 10px rgba(105, 105, 105, 0.308);
            text-decoration: none;
            display: flex;
            align-items: center;
            justify-content: center;
            text-align: center;
        }

        .nome-animal{
            margin-top: 1rem;
        }

        .peso-animal{
            margin: .5rem 0;
        }

        .medida-animal{
            margin-bottom: 1rem;
        }

        .inserir-animal-flex{
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