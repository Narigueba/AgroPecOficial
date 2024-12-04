<script setup>
import InputCustom from "../../components/InputCustom.vue";
import { ref, onMounted } from "vue";
import ApiService from "./ApiService";

const api = new ApiService();
const idAnimalVacina = ref("");
const animalVacinaData = ref(null);
const novoAnimalVacina = ref({
    animal: { idAnimal: 0 },
    vacina: { idVacina: 0 },
    dataVacina: null,
});
const mensagem = ref("");
const listaAnimal = ref([]);
const listaVacina = ref([]);

const selecionarAnimaisEVacinas = async () => {
    try {
        animalVacinaData.value = await api.get("selecionarAnimaisEVacinas");
    } catch (error) {
        console.error(error);
        mensagem.value = "Erro ao selecionar animais e vacinas";
    }
};

const consultarAnimaisVacinasPorId = async () => {
    try {
        animalVacinaData.value = [];
        var animalVacina = await api.get(
            `consultarAnimaisVacinasPorId?id=${idAnimalVacina.value}`
        );
        animalVacinaData.value.push(animalVacina);
    } catch (error) {
        console.error(error);
        mensagem.value = "Erro ao consultar animais e vacinas por ID";
    }
};

const inserirAnimalVacina = async () => {
    const animalSelecionado = listaAnimal.value.find(
        (item) => item.idAnimal === novoAnimalVacina.value.animal.idAnimal
    );
    if (animalSelecionado) {
        novoAnimalVacina.value.animal = animalSelecionado;
    }
    const vacinaSelecionada = listaVacina.value.find(
        (item) => item.idVacina === novoAnimalVacina.value.vacina.idVacina
    );
    if (vacinaSelecionada) {
        novoAnimalVacina.value.vacina = vacinaSelecionada;
    }
    if (!novoAnimalVacina.value.animal.idAnimal) {
        mensagem.value = "Selecione um animal";
        return;
    }
    if (!novoAnimalVacina.value.vacina.idVacina) {
        mensagem.value = "Selecione uma vacina";
        return;
    }
    try {
        const resposta = await api.post(
            "inserirAnimalVacina",
            novoAnimalVacina.value
        );
        mensagem.value = "Animal e Vacina inserido com sucesso!";
        selecionarAnimaisEVacinas();
    } catch (error) {
        console.error(error.response?.data || error.message);
        mensagem.value = "Erro ao inserir AnimalVacina";
    }
};

const atualizarAnimalVacina = async () => {
    try {
        const resposta = await api.put(
            "atualizarAnimalVacina",
            idAnimalVacina.value,
            novoAnimalVacina.value
        );
        mensagem.value = "Animal e Vacina atualizado com sucesso!";
        console.log(resposta);
    } catch (error) {
        console.error(error);
        mensagem.value = "Erro ao atualizar AnimalVacina";
    }
};

const deletarAnimalEVacina = async () => {
    try {
        const resposta = await api.delete(
            `deletarAnimalEVacina?id=${idAnimalVacina.value}`
        );
        mensagem.value = "Animal e Vacina deletado com sucesso!";
        console.log(resposta);
    } catch (error) {
        console.error(error);
        mensagem.value = "Erro ao deletar AnimalVacina";
    }
};

const selecionarAnimal = async () => {
    try {
        listaAnimal.value = await api.getAnimal("selecionarAnimais");
        console.log(listaAnimal.value);
    } catch (error) {
        console.error(error);
        mensagem.value = "Erro ao selecionar animais";
    }
};

const selecionarVacinas = async () => {
    try {
        listaVacina.value = await api.getVacina("selecionarVacinas");
        console.log(listaVacina.value);
    } catch (error) {
        console.error(error);
        mensagem.value = "Erro ao selecionar vacinas";
    }
};

onMounted(() => {
    selecionarAnimal();
    selecionarVacinas();
});
</script>

<template>
    <div>
        <!-- Input para consultar animal e Vacina por ID -->
        <InputCustom label="ID do Animal e Vacina" v-model="idAnimalVacina" />
        <button @click="consultarAnimaisVacinasPorId">
            Consultar Animal e Vacina por ID
        </button>

        <!-- Botão para selecionar todos os animais e vacinas -->
        <button @click="selecionarAnimaisEVacinas">
            Selecionar Animal e Vacina
        </button>

        <!-- Inputs para inserir novo animal e vacina -->
        <h3>Inserir Novo Animal e Vacina</h3>
        <div v-if="listaAnimal.length > 0">
            <select v-model="novoAnimalVacina.animal.idAnimal">
                <option
                    v-for="item in listaAnimal"
                    :key="item.idAnimal"
                    :value="item.idAnimal"
                >
                    {{ item.nomeAnimal }}
                </option>
            </select>
        </div>
        <div v-if="listaVacina.length > 0">
            <select v-model="novoAnimalVacina.vacina.idVacina">
                <option
                    v-for="item in listaVacina"
                    :key="item.idVacina"
                    :value="item.idVacina"
                >
                    {{ item.tipoVacina }}
                </option>
            </select>
        </div>
        <InputCustom
            type="date"
            label="Data da Vacina"
            v-model="novoAnimalVacina.dataVacina"
        />
        
        
        <button @click="inserirAnimalVacina">Inserir Animal e Vacina</button>

        <!-- Botão para atualizar um animal e vacina existente -->
        <button @click="atualizarAnimalVacina">
            Atualizar Animal e Vacina
        </button>

        <!-- Botão para deletar um animal e vacina -->
        <button @click="deletarAnimalEVacina">Deletar Animal e Vacina</button>

        <!-- Exibição de mensagem -->
        <p>{{ mensagem }}</p>

        <!-- Exibição de dados do animal e vacina consultado -->
        <table>
            <thead>
                <tr>
                    <th>ID do registro</th>
                    <th>ID do Animal</th>
                    <th>ID da Vacina</th>
                    <th>Data da Vacina</th>
                </tr>
            </thead>
            <tbody>
                <tr
                    v-for="animalVacina in animalVacinaData"
                    :key="animalVacina.idAnimalVacina"
                >
                    <td>{{ animalVacina.idAnimalVacina }}</td>
                    <td>{{ animalVacina.animal.nomeAnimal }}</td>
                    <td>{{ animalVacina.vacina.tipoVacina }}</td>
                    <td>{{ animalVacina.dataVacina }}</td>
                </tr>
            </tbody>
        </table>
    </div>
</template>
