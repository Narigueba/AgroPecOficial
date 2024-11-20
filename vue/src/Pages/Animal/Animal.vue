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
    <div>
        <!-- Input para consultar animais por ID -->
        <InputCustom label="ID do Animal" v-model="idAnimal" />
        <button @click="consultarAnimaisPorId">Consultar Animal por ID</button>

        <!-- Botão para selecionar todos os animais -->
        <button @click="selecionarAnimais">Selecionar Animais</button>

        <!-- Inputs para inserir novo animal -->
        <InputCustom label="Nome do Animal" v-model="novoAnimal.nomeAnimal" />
        <InputCustom label="Idade do Animal" v-model="novoAnimal.idade" />
        <InputCustom
            type="date"
            label="Data de Nascimento do Animal"
            v-model="novoAnimal.dataNascimento"
        />
        <InputCustom label="Sexo do Animal" v-model="novoAnimal.sexo" />
        <InputCustom label="Cor do Animal" v-model="novoAnimal.cor" />
        <InputCustom label="Ninhada do Animal" v-model="novoAnimal.ninhada" />
        <InputCustom label="Peso do Animal" v-model="novoAnimal.peso" />
        <InputCustom label="Raca do Animal" v-model="novoAnimal.raca" />
        <div v-if="listaTipoAnimal.length > 0">
            <select v-model="novoAnimal.tipoAnimal.idTipoAnimal">
                <option
                    v-for="item in listaTipoAnimal"
                    :key="item.idTipoAnimal"
                    :value="item.idTipoAnimal"
                >
                    {{ item.animal }}
                </option>
            </select>
        </div>
        <div style="display: flex;">
            <div>
                <select v-model="novoAnimal.racao.idRacao">
                    <option
                        v-for="item in listaRacao"
                        :key="item.idRacao"
                        :value="item.idRacao"
                    >
                        {{ item.nomeRacao }}
                    </option>
                </select>
            </div>
            <div>
                <button>inserir Racao</button>
            </div>
        </div>
        <button @click="inserirAnimais">inserir Animal</button>

        <!-- Botão para atualizar um animal existente -->
        <button @click="atualizarAnimal">Atualizar Animal</button>

        <!-- Botão para deletar um animal existente -->
        <button @click="deletarAnimal">Deletar Animal</button>

        <!-- Exibição de mensagem -->
        <p>{{ mensagem }}</p>

        <!-- Exibição de dados do animal consultado -->
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
                <!-- <tr v-if="!animalData.Array" :key="animalData.idAnimal">
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
                </tr> -->
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
    </div>
</template>
