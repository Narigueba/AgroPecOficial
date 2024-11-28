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

onMounted(() => {
    selecionarRacoes();
    selecionarTipoAnimal();
});
</script>
<template>
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
</template>