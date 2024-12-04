<script setup>
import { ref, onMounted } from 'vue';
import { useRoute } from 'vue-router';
import ApiService from './ApiService';

const props = defineProps({
    id: {
        type: String,
        required: true,
    },
})
const route = useRoute();
const api = new ApiService();
const racaoData = ref(null);
const mensagem = ref('');

const consultarRacaoPorId = async () => {
    try {
        const id = route.params.id; // Obtém o ID da URL
        if (!id) {
            mensagem.value = 'ID não fornecido pela URL';
            return;
        }
        racaoData.value = await api.get(`consultarRacaoPorId?id=${id}`);
    } catch (error) {
        console.error(error);
        mensagem.value = 'Erro ao consultar ração por ID' + error.message;
    }
};

// Consulta automaticamente ao montar o componente
onMounted(() => {
    consultarRacaoPorId();
});
</script>

<template>
    <div>
        <div class="router-link-back">
            <RouterLink to="/racao"><i class="pi pi-angle-left back"></i></RouterLink>  
        </div> 

        <p class="mensagem">{{ mensagem }}</p>


        <div v-if="racaoData"> 
            <h4>Detalhes da Ração:</h4> 
            <pre>{{ racaoData.nomeRacao }}</pre>
            <pre>{{ racaoData.peso }}</pre>
            <pre>{{ racaoData.unidadeMedida }}</pre>
        </div>
        
    </div>
</template>
<style scoped>
pre{
    color: black;
}

</style>
