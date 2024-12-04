<script setup>
import { ref, onMounted } from 'vue';
import { useRoute } from 'vue-router';
import ApiService from './ApiService';

const route = useRoute();
const api = new ApiService();
const animalData = ref(null);
const mensagem = ref('');

const consultarAnimalPorId = async () => {
    try {
        const id = route.params.id; // Obtém o ID da URL
        animalData.value = await api.get(`consultarAnimalPorId?id=${id}`);
    } catch (error) {
        console.error(error);
        mensagem.value = 'Erro ao consultar animal por ID';
    }
};

// Consulta automaticamente ao montar o componente
onMounted(() => {
    consultarAnimalPorId();
});
</script>
<template>
        <div>
                <div class="router-link-back">
                        <RouterLink to="/animal"><i class="pi pi-angle-left back"></i></RouterLink>
                </div>
                <p class="mensagem">{{ mensagem }}</p>

                <div v-if="animalData"> 
                        <h4>Detalhes do Animal:</h4> 
                        <pre>{{ animalData }}</pre> 
                </div>
        </div>

</template>