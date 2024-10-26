// ApiService.js
export default class ApiService {
    constructor(baseUrl = 'https://localhost:7288') {
      this.baseUrl = baseUrl;
    }
  
    // Método GET para buscar dados
    async get(endpoint) {
      try {
        const response = await fetch(`${this.baseUrl}/${endpoint}`);
        if (!response.ok) {
          throw new Error(`Erro: ${response.statusText}`);
        }
        return await response.json();
      } catch (error) {
        console.error('Erro ao fazer GET:', error);
        throw error;
      }
    }
  
    // Método POST para enviar dados
    async post(endpoint, data) {
      try {
        const response = await fetch(`${this.baseUrl}/${endpoint}`, {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json',
          },
          body: JSON.stringify(data),
        });
        if (!response.ok) {
          throw new Error(`Erro: ${response.statusText}`);
        }
        return await response.json();
      } catch (error) {
        console.error('Erro ao fazer POST:', error);
        throw error;
      }
    }
  
    // Método PUT para atualizar dados
    async put(endpoint, data) {
      try {
        const response = await fetch(`${this.baseUrl}/${endpoint}`, {
          method: 'PUT',
          headers: {
            'Content-Type': 'application/json',
          },
          body: JSON.stringify(data),
        });
        if (!response.ok) {
          throw new Error(`Erro: ${response.statusText}`);
        }
        return await response.json();
      } catch (error) {
        console.error('Erro ao fazer PUT:', error);
        throw error;
      }
    }
  
    // Método DELETE para excluir dados
    async delete(endpoint) {
      try {
        const response = await fetch(`${this.baseUrl}/${endpoint}`, {
          method: 'DELETE',
        });
        if (!response.ok) {
          throw new Error(`Erro: ${response.statusText}`);
        }
        return await response.json();
      } catch (error) {
        console.error('Erro ao fazer DELETE:', error);
        throw error;
      }
    }
  }
  