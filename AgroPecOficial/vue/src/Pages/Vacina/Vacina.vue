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

// onMounted(() => {
//     selecionarTipoAnimal();
// });
</script>

<template>

    <div class="container-flex">
        <div class="grow padding">
            <div class="container-consultar_vacina bottom">
                <h4 class="container-title">Consultar Vacina</h4>
                <!-- Input para consultar racao por ID -->
                <InputCustom  placeholder="Cod. da Vacina" v-model="vacinaId" class="inserir-cod"/>
                <div class="consultar-vacina-flex">
                    <RouterLink to="/consultarVacina" class="btn consultar-btn">Consultar Vacina</RouterLink>
                    <RouterLink to="/consultarVacinas" class="btn selecionar-btn">Selecionar Vacinas</RouterLink>
                </div>
            </div>
            <div class="container-inserir_vacina">
                <h4 class="container-title">Inserir Nova Vacina</h4>
                <!-- Inputs para inserir nova vacina -->
                <InputCustom placeholder="Nome da Vacina" v-model="novaVacina.tipoVacina" class="inserir-cod"/>
                <div class="inserir-vacina-flex">
                    <button @click="inserirVacina" class="btn inserir-btn">Inserir Vacina</button>
                </div>
                <!-- Botão para atualizar uma racao existente
                    <button @click="atualizarVacina">Atualizar Vacina</button>
                    Botão para deletar uma racao
                    <button @click="deletarVacina">Deletar Vacina</button> -->
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

            <!-- <div>
                <select>
                    <option v-for="item in listaTipoAnimal"  :key="item.idTipoAnimal">{{ item.animal }}</option>
                </select>
            </div> -->
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
</template>

<style scoped>

        .inserir-cod{
            margin: 1rem 0 1rem;
        }

        .consultar-vacina-flex{
            display: flex;
            gap: .5rem;
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

        .inserir-vacina-flex{
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
