<script setup>
import InputCustom from "../../components/InputCustom.vue";
import { ref } from 'vue';
import ApiService from './ApiService.js';

const api = new ApiService();
const produtoId = ref('');
const produtoData = ref(null);
const novoProduto = ref({ nome: '', preco: 0});
const mensagem = ref('');

// Função para consultar produtos por ID
const consultarProdutoPorId = async () => {
  try {
    produtoData.value = await api.get(`consultarProdutosPorId?id=${produtoId.value}`);
  } catch (error) {
    console.error(error);
    mensagem.value = 'Erro ao consultar produto por ID';
  }
};

// Função para selecionar todos os produtos
const selecionarProdutos = async () => {
  try {
    produtoData.value = await api.get('selecionarProdutos');
  } catch (error) {
    console.error(error);
    mensagem.value = 'Erro ao selecionar produtos';
  }
};

// Função para inserir um novo produto
const inserirProduto = async () => {
  try {
    const resposta = await api.post('inserirProduto', novoProduto.value);
    mensagem.value = 'Produto inserido com sucesso!';
    console.log(resposta);
  } catch (error) {
    console.error(error);
    mensagem.value = 'Erro ao inserir produto';
  }
};

// Função para atualizar um produto
const atualizarProduto = async () => {
  try {
    const resposta = await api.put('atualizarProduto', produtoData.value);
    mensagem.value = 'Produto atualizado com sucesso!';
    console.log(resposta);
  } catch (error) {
    console.error(error);
    mensagem.value = 'Erro ao atualizar produto';
  }
};

// Função para deletar um produto
const deletarProduto = async () => {
  try {
    const resposta = await api.delete(`atualizarProduto?id=${produtoId.value}`);
    mensagem.value = 'Produto deletado com sucesso!';
    console.log(resposta);
  } catch (error) {
    console.error(error);
    mensagem.value = 'Erro ao deletar produto';
  }
};
</script>

<template>
  <div>
    <!-- Input para consultar produto por ID -->
    <InputCustom label="ID do Produto" v-model="produtoId" />
    <button @click="consultarProdutoPorId">Consultar Produto por ID</button>
    
    <!-- Botão para selecionar todos os produtos -->
    <button @click="selecionarProdutos">Selecionar Produtos</button>
    
    <!-- Inputs para inserir novo produto -->
    <h3>Inserir Novo Produto</h3>
    <InputCustom label="Nome do Produto" v-model="novoProduto.nome" />
    <InputCustom label="Preço do Produto" v-model="novoProduto.preco" />
    <button @click="inserirProduto">Inserir Produto</button>
    
    <!-- Botão para atualizar um produto existente -->
    <button @click="atualizarProduto">Atualizar Produto</button>
    
    <!-- Botão para deletar um produto -->
    <button @click="deletarProduto">Deletar Produto</button>
    
    <!-- Exibição de mensagem -->
    <p>{{ mensagem }}</p>

    <!-- Exibição de dados do produto consultado -->
    <div v-if="produtoData">
      <h4>Detalhes do Produto:</h4>
      <pre>{{ produtoData }}</pre>
    </div>
  </div>
</template>
