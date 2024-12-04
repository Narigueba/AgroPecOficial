<script setup>
import { ref, onMounted } from 'vue';
import { useRoute } from 'vue-router';
import ApiService from './ApiService';

const route = useRoute();
const api = new ApiService();
const vacinaData = ref(null);
const mensagem = ref('');

const consultarVacinasPorId = async () => {
    try {
        const id = route.params.id; // Obtém o ID da URL
        vacinaData.value = await api.get(`consultarVacinasPorId?id=${id}`);
    } catch (error) {
        console.error(error);
        mensagem.value = 'Erro ao consultar vacina por ID';
    }
};

// Consulta automaticamente ao montar o componente
onMounted(() => {
    consultarVacinasPorId();
});
</script>
<template>
    <div>
        <div class="router-link-back">
            <RouterLink to="/vacina"><i class="pi pi-angle-left back"></i></RouterLink>
        </div>
        <p class="mensagem">{{ mensagem }}</p>

        <div v-if="vacinaData"> 
            <h4>Detalhes da Vacina:</h4> 
            <pre>{{ vacinaData }}</pre> 
        </div>
    </div>
    
</template>
<style scoped>

</style>