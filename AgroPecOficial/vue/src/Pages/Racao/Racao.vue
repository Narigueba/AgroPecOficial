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

// onMounted(() => {
//     selecionarTipoAnimal();
// });
</script>

<template>
    <div>
        <!-- <h1 class="router-title">Ração</h1> -->
        <div class="container-consultar_racao">
            <h4 class="container-title">Consultar Ração</h4>
            <InputCustom v-model="racaoId" placeholder="Cod. da Ração" class="inserir-cod" />
            <div class="consultar-racao-flex">
                <!-- passando id por parametro URL -->
                <RouterLink to="/consultarRacao/id" class="btn consultar-btn">Consultar Ração</RouterLink>
                <RouterLink to="/consultarRacoes" class="btn selecionar-btn">Selecionar Rações</RouterLink>
            </div>
        </div>
        <div class="container-inserir_racao">
            <h4 class="container-title">Inserir Nova Ração</h4>
            <div class="inserir-dados">
                <!-- Inputs para inserir nova racao -->
                <InputCustom v-model="novaRacao.nomeRacao" placeholder="Nome da Ração" class="nome-racao" />
                <InputCustom v-model="novaRacao.peso" placeholder="Peso da Ração" class="peso-racao" />
                <InputCustom v-model="novaRacao.unidadeMedida" placeholder="Unidade de Medida" class="medida-racao" />
            </div>
            <div class="inserir-racao-flex">
                <button @click="inserirRacao" class="btn inserir-btn">Inserir Ração</button>
                <!-- <button @click="atualizarRacao" class="btn atualizar-btn">Atualizar Ração</button>
                <button @click="deletarRacao" class="btn deletar-btn">Deletar Ração</button> -->
            </div>


        </div>
        <!-- <div>
            <select>
                <option v-for="item in listaTipoAnimal"  :key="item.idTipoAnimal">{{ item.animal }}</option>
            </select>
        </div> -->
        
        <!-- Exibição de mensagem -->
        <p class="mensagem">{{ mensagem }}</p>

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

<style scoped>

        .container-consultar_racao{
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

        .consultar-racao-flex{
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

        .nome-racao{
            margin-top: 1rem;
        }

        .peso-racao{
            margin: .5rem 0;
        }

        .medida-racao{
            margin-bottom: 1rem;
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
