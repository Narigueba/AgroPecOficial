<script setup>
import InputCustom from "../../components/InputCustom.vue";
import { ref, onMounted } from "vue";
import ApiService from "./ApiService";

const api = new ApiService();
const idAnimal = ref("");
const animalData = ref([]);
const novoAnimal = ref({
    nomeAnimal: "",
    idade: 0,
    dataNascimento: null,
    sexo: "",
    cor: "",
    ninhada: 0,
    peso: 0,
    fotos: [],
    raca: "",
    racao: { idRacao: 0, nomeRacao: "", unidadeMedida: "" },
    tipoAnimal: { idTipoAnimal: 0, animal: "", especie: "" },
});
const mensagem = ref("");
const listaTipoAnimal = ref([]);
const listaRacao = ref([]);
novoAnimal.value.fotos = [];

const selecionarAnimais = async () => {
    try {
        animalData.value = await api.get("selecionarAnimais");
    } catch (error) {
        console.error(error);
        mensagem.value = "Erro ao selecionar animais" + error.message;
    }
};

const consultarAnimaisPorId = async () => {
    try {
        animalData.value = [];
        var animal = await api.get(
            `consultarAnimaisPorId?id=${idAnimal.value}`
        );
        animalData.value.push(animal);
    } catch (error) {
        console.error(error);
        mensagem.value = "Erro ao consultar animais por ID" + error.message;
    }
};

const inserirAnimais = async () => {
    try {
        if (!Array.isArray(novoAnimal.value.fotos)) {
            novoAnimal.value.fotos = [];
        }

        if (novoAnimal.value.fotos.length === 0) {
            delete novoAnimal.value.fotos; // Removendo campo fotos
        }

        // Garantir que o tipo de animal tenha o ID correto (caso a API espere um ID e não um nome)
        const tipoAnimalSelecionado = listaTipoAnimal.value.find(
            (item) => item.animal === novoAnimal.value.tipoAnimal.animal
        );
        if (tipoAnimalSelecionado) {
            novoAnimal.value.tipoAnimal.idTipoAnimal =
                tipoAnimalSelecionado.idTipoAnimal;
        }

        console.log(
            "Tipo de animal selecionado:",
            novoAnimal.value.tipoAnimal.idTipoAnimal
        );
        if (!novoAnimal.value.tipoAnimal.idTipoAnimal) {
            mensagem.value = "Por favor, selecione o tipo de animal.";
            return;
        }
        const resposta = await api.post("inserirAnimais", novoAnimal.value);
        mensagem.value = "Animal inserido com sucesso!";
        selecionarAnimais();
        console.log(resposta);
    } catch (error) {
        console.error(error);
        mensagem.value = "Erro ao inserir animal" + error.message;
    }
};

const atualizarAnimal = async () => {
    try {

        if(Array.isArray(novoAnimal.value.fotos)){
            novoAnimal.value.fotos = novoAnimal.value.fotos.join(',');
        }
        
        const resposta = await api.put(
            "atualizarAnimal",
            idAnimal.value,
            novoAnimal.value
        );
        mensagem.value = "Animal atualizado com sucesso!";
        console.log(resposta);
    } catch (error) {
        console.error(error);
        mensagem.value = "Erro ao atualizar animal" + error.message;
    }
};

const deletarAnimal = async () => {
    try {
        const resposta = await api.delete(`deletarAnimal?id=${idAnimal.value}`);
        mensagem.value = "Animal deletado com sucesso!";
        console.log(resposta);
    } catch (error) {
        console.error(error);
        mensagem.value = "Erro ao deletar animal" + error.message;
    }
};

// Tabelas relacionadas

const selecionarTipoAnimal = async () => {
    try {
        listaTipoAnimal.value = await api.getTipoAnimal(
            "selecionarTiposAnimais"
        );
        console.log(listaTipoAnimal.value);
    } catch (error) {
        console.error(error);
        mensagem.value = "Erro ao selecionar racao" + error.message;
    }
};

const selecionarRacoes = async () => {
    try {
        listaRacao.value = await api.getRacao("selecionarRacoes");
    } catch (error) {
        console.error(error);
        mensagem.value = "Erro ao selecionar racao" + error.message;
    }
};

// onMounted(() => {
//     selecionarRacoes();
//     selecionarTipoAnimal();
// });
</script>

<template>
    <div class="container-flex">
        <div class="grow padding">
            <div class="container-consultar_animal bottom">   
                <h4 class="container-title">Consultar Animal</h4>
                <InputCustom placeholder="Cod. do Animal" v-model="idAnimal" class="inserir-cod"/>
                <div class="consultar-animal-flex">
                    <RouterLink to="/consultarAnimal" class="btn consultar-btn">Consultar Animal</RouterLink>
                    <RouterLink to="/consultarAnimais" class="btn selecionar-btn">Selecionar Animais</RouterLink>
                </div>
            </div>
            <div class="container-inserir_animal">
                <h4 class="container-title">Inserir Novo Animal</h4>
                <div class="inserir-dados">
                    <InputCustom placeholder="Nome do Animal" v-model="novoAnimal.nomeAnimal" class="nome-animal inserir-cod"  />
                    <InputCustom placeholder="Idade do Animal" v-model="novoAnimal.idade" class="idade-animal inserir-cod" />
                    <InputCustom type="date" placeholder="Data de Nascimento do Animal" v-model="novoAnimal.dataNascimento" class="nascimento-animal inserir-cod"/>
                    <InputCustom placeholder="Sexo do Animal" v-model="novoAnimal.sexo" class="sexo-animal inserir-cod" />
                    <InputCustom placeholder="Cor do Animal" v-model="novoAnimal.cor" class="cor-animal inserir-cod" />
                    <InputCustom placeholder="Ninhada do Animal" v-model="novoAnimal.ninhada" class="ninhada-animal inserir-cod"/>
                    <InputCustom placeholder="Peso do Animal" v-model="novoAnimal.peso" class="peso-animal inserir-cod"/>
                    <InputCustom placeholder="Raca do Animal" v-model="novoAnimal.raca" class="raca-animal inserir-cod" />
                </div>
                <div class="container-tipo_animal">
                    <select v-model="novoAnimal.tipoAnimal.idTipoAnimal" @click="selecionarTipoAnimal" class="container-lista grow">
                        <option v-for="item in listaTipoAnimal" :key="item.idTipoAnimal" :value="item.idTipoAnimal">
                            {{ item.animal }}
                        </option>
                    </select>
                    <RouterLink to="/animal" class="link"><button  class="container-tipo_racao_btn btn grow">Inserir Animal</button></RouterLink>
                </div>
                <div class="container-tipo_racao">
                    <select v-model="novoAnimal.racao.idRacao" class="container-lista grow" @click="selecionarRacoes">
                        <option v-for="item in listaRacao" :key="item.idRacao" :value="item.racao">
                            {{ item.nomeRacao }}
                        </option>
                    </select>
                    <RouterLink to="/racao" class="link"><button  class="container-tipo_racao_btn btn grow">Inserir Ração</button></RouterLink>
                </div>
                <div class="inserir-animal-flex">
                    <button @click="inserirAnimais" class="btn inserir-cod-animal">Inserir Animal</button>
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
        <!-- <div>
            Input para consultar animais por ID
            
            <button @click="consultarAnimaisPorId">Consultar Animal por ID</button>
            
        Botão para selecionar todos os animais
        <button @click="selecionarAnimais">Selecionar Animais</button>

        Inputs para inserir novo animal






        Botão para atualizar um animal existente
        <button @click="atualizarAnimal">Atualizar Animal</button>

        Botão para deletar um animal existente
        <button @click="deletarAnimal">Deletar Animal</button>

        Exibição de mensagem
        <p>{{ mensagem }}</p>

        Exibição de dados do animal consultado
        <table>
            <thead>
                <tr>
                    <th>ID</th>
                    <th>Nome</th>
                    <th>Idade</th>
                    <th>Data de Nascimento</th>
                    <th>Sexo</th>
                    <th>Cor</th>
                    <th>Ninhada</th>
                    <th>Peso</th>
                    <th>Raça</th>
                    <th>Tipo Animal</th>
                    <th>Ração</th>
                </tr>
            </thead>
            <tbody>
                <tr v-if="!animalData.Array" :key="animalData.idAnimal">
                    <td>{{ animalData.idAnimal }}</td>
                    <td>{{ animalData.nomeAnimal }}</td>
                    <td>{{ animalData.idade }}</td>
                    <td>{{ animalData.dataNascimento }}</td>
                    <td>{{ animalData.sexo }}</td>
                    <td>{{ animalData.cor }}</td>
                    <td>{{ animalData.ninhada }}</td>
                    <td>{{ animalData.peso }}</td>
                    <td>{{ animalData.raca }}</td>
                    <td>{{ animalData.tipoAnimal }}</td>
                    <td>{{ animalData.racao }}</td>
                </tr>
                <tr v-for="animal in animalData" :key="animal.idAnimal">
                    <td>{{ animal.idAnimal }}</td>
                    <td>{{ animal.nomeAnimal }}</td>
                    <td>{{ animal.idade }}</td>
                    <td>{{ animal.dataNascimento }}</td>
                    <td>{{ animal.sexo }}</td>
                    <td>{{ animal.cor }}</td>
                    <td>{{ animal.ninhada }}</td>
                    <td>{{ animal.peso }}</td>
                    <td>{{ animal.raca }}</td>
                    <td>{{ animal.tipoAnimal }}</td>
                    <td>{{ animal.racao }}</td>
                </tr>
            </tbody>
        </table>
    </div> -->
</template>

<style scoped>

        .link{
            text-decoration: none;
        }

        .inserir-cod{
            margin: 1rem 0 1rem;
        }

        .consultar-animal-flex{
            display: flex;
            gap: .5rem;
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

        .container-tipo_racao{
            display: flex;
            gap: 1rem;
            margin-top: 1rem;
        }

        .container-tipo_animal{
            display: flex;
            gap: 1rem;
        }

        .grow{
            flex: 1 0 0;
        }

        .container-lista{
            border-radius: .5rem;
            border: 1px solid #ccc;       
        }

        .inserir-cod-animal{
            margin: 1rem 0 10rem;
        }


</style>
