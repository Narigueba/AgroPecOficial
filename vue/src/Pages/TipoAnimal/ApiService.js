export default class ApiService {
    constructor(baseUrl = 'https://localhost:7001/TipoAnimal') {
        this.baseUrl = baseUrl;
    }

    // Método GET para buscar dados
    async get(selecionarTiposAnimais) {
        try {
            const response = await fetch(`${this.baseUrl}/${selecionarTiposAnimais}`);
            if (!response.ok) {
                throw new Error(`Erro: ${response.statusText}`);
            }
            return await response.json();
        } catch (error) {   
            console.error('Erro ao fazer GET:', error);
            throw error;
        }
    }

    // Método GET para buscar dados pelo id
    async getById(consultarTiposAnimaisPorId, id) {
        try {
            const response = await fetch(`${this.baseUrl}/${consultarTiposAnimaisPorId}?id=${id}`);
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
    async post(inserirTiposAnimais, data) {
        try {
            const response = await fetch(`${this.baseUrl}/${inserirTiposAnimais}`, {
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
    async put(atualizarTipoAnimal, id, data) {
        try {
            const response = await fetch(`${this.baseUrl}/${atualizarTipoAnimal}?id=${id}`, {
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
    async delete(deletarTipoAnimal) {
        try {
            const response = await fetch(`${this.baseUrl}/${deletarTipoAnimal}`, {
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