<script setup>
import InputCustom from "../../components/InputCustom.vue";
import { ref, onMounted } from "vue";
import ApiService from "./ApiService";

const api = new ApiService();
const idAnimal = ref("");
const animalData = ref(null);
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
        listaTipoAnimal.value = await api.getTipoAnimal("selecionarTipoAnimal");
        console.log(listaTipoAnimal.value);
    } catch (error) {
        console.error(error);
        mensagem.value = "Erro ao selecionar tipo animal" + error.message;
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

onMounted(() => {
    selecionarAnimais();
    // selecionarRacoes();
    // selecionarTipoAnimal();
});
</script>
<template>
        <div>
            <div class="router-link-back">
                <RouterLink to="/animal"><i class="pi pi-angle-left back"></i></RouterLink>
            </div>
            <div class="animal-container">
                <ul>
                    <li  v-for="animal in animalData" :key="animal.id" class="item-vacina">
                        <img src="" alt="">
                        <div class="animal-container-value">
                                <div class="flex">
                                    <p class="w-700">Nome: </p>
                                    <p class="w-200">{{ animal.nomeAnimal }}</p>
                                </div>
                                <div class="flex">
                                    <p  class="w-700">Idade: </p>
                                    <p class="w-200">{{ animal.idade }}</p>
                                </div>
                                <div class="flex">
                                    <p  class="w-700">Ninhada: </p>
                                    <p class="w-200">{{ animal.ninhada }}</p>
                                </div>
                                <div class="flex">
                                    <p  class="w-700">Peso: </p>
                                    <p class="w-200">{{ animal.peso }}</p>
                                </div>
                                <div class="flex">
                                    <p  class="w-700">Raça: </p>
                                    <p class="w-200">{{ animal.raca }}</p>
                                </div>
                                <div class="flex">
                                    <p  class="w-700">Racao: </p>
                                    <p class="w-200">{{ animal.racao.nomeRacao }}</p>
                                </div>
                                <div class="flex">
                                    <p  class="w-700">Animal: </p>
                                    <p class="w-200">{{ animal.tipoAnimal.animal }}</p>
                                </div>
                                <div class="flex">
                                    <p  class="w-700">Especie: </p>
                                    <p class="w-200">{{ animal.tipoAnimal.especie }}</p>
                                </div>
                                <div class="flex">
                                    <p  class="w-700">Data de Nascimento: </p>
                                    <p class="w-200">{{ animal.dataNascimento }}</p>
                                </div>
                                <div class="flex">
                                    <p  class="w-700">Sexo: </p>
                                    <p class="w-200">{{ animal.sexo }}</p>
                                </div>
                                <div class="flex">
                                    <p  class="w-700">Cor: </p>
                                    <p class="w-200">{{ animal.cor }}</p>
                                </div>
                                <div class="racao-atualizar-deletar">
                                    <button @click="atualizarRacao" class="btn atualizar-btn">Atualizar</button>
                                    <button @click="deletarRacao" class="btn deletar-btn">Deletar</button>
                                </div>
                        </div>
                    </li>
                </ul>
            </div>
        </div>
</template>
<style scoped>
    .flex{
        display: flex;
        gap: .5rem;
    }
    .animal-container ul{
        padding: 0 5rem;
        display: flex;
        justify-content: center;
        flex-wrap: wrap;
        gap: 2rem;
        margin-bottom: 4rem;
    }
    .animal-container-value{
        background-image: linear-gradient( 109.6deg,  rgba(61,131,97,1) 11.2%, rgba(28,103,88,1) 91.1% );
        color: white;
        padding: 1rem 1.5rem;
        border-radius: 0 0 10px 10px ;
    }
    .racao-atualizar-deletar{
        display: flex;
        flex-direction: column;
        gap: .5rem;
        margin-top: 2rem;
    }

    @media (min-width: 37.56rem) {
        .animal-container-value{
            padding: 2rem 2.5rem;

        }
    }

</style>