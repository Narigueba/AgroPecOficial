export default class ApiService {
    constructor(baseUrl = 'https://localhost:7001/Animal', baseUrlTipoAnimal = 'https://localhost:7001/TipoAnimal', baseUrlRacao = 'https://localhost:7001/Racao') {
        this.baseUrl = baseUrl;
        this.baseUrlTipoAnimal = baseUrlTipoAnimal;
        this.baseUrlRacao = baseUrlRacao;
    }

    // Método GET para buscar dados
    async get(selecionarAnimais) {
        try {
            const response = await fetch(`${this.baseUrl}/${selecionarAnimais}`);
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
    async getById(consultarAnimaisPorId, id) {
        try {
            const response = await fetch(`${this.baseUrl}/${consultarAnimaisPorId}?id=${id}`);
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
    async post(inserirAnimais, data) {
        try {
            const response = await fetch(`${this.baseUrl}/${inserirAnimais}`, {
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
    async put(atualizarAnimal, id, data) {
        try {
            const response = await fetch(`${this.baseUrl}/${atualizarAnimal}?id=${id}`, {
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
    async delete(deletarAnimal) {
        try {
            const response = await fetch(`${this.baseUrl}/${deletarAnimal}`, {
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

    // Tabelas relacionadas
    async getTipoAnimal(selecionarTipoAnimal) {
        try {
            const response = await fetch(`${this.baseUrlTipoAnimal}/${selecionarTipoAnimal}`);
            if (!response.ok) {
                throw new Error(`Erro: ${response.statusText}`);
            }
            return await response.json();
        } catch (error) {
            console.error('Erro ao fazer GET:', error);
            throw error;
        }
    }

    async getRacao(selecionarRacoes) {
        try {
            const response = await fetch(`${this.baseUrlRacao}/${selecionarRacoes}`);
            if (!response.ok) {
                throw new Error(`Erro: ${response.statusText}`);
            }
            return await response.json();
        } catch (error) {
            console.error('Erro ao fazer GET:', error);
            throw error;
        }
    }
}