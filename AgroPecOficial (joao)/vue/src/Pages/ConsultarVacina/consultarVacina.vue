<script setup>
import { ref, onMounted } from 'vue';
import { useRoute } from 'vue-router';
import ApiService from './ApiService';

const props = defineProps({
    id: {
        type: String,
        required: true
    }
});

const route = useRoute();
const api = new ApiService();
const vacinaData = ref(null);
const mensagem = ref('');

const consultarVacinaPorId = async () => {
    try {
        const id = route.params.id;
        if (!id) {
            mensagem.value = 'ID da vacina não fornecido';
            return;
        }
        vacinaData.value = await api.get(`consultarVacinaPorId?id=${id}`);
        console.log(vacinaData.value);
    } catch (error) {
        console.error(error);
        mensagem.value = 'Erro ao consultar vacina por ID';
    }
};

// Consulta automaticamente ao montar o componente
onMounted(() => {
    consultarVacinaPorId();
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
            <pre>{{ vacinaData.tipoVacina }}</pre>
        </div>
    </div>
    
</template>
<style scoped>
pre{
    color: black;
}
</style>