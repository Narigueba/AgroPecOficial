export default class ApiService {
    constructor(baseUrl = 'https://localhost:7001/Vacina') {
        this.baseUrl = baseUrl;
    }

    // Método GET para buscar dados
    async get(selecionarVacinas) {
        try {
            const response = await fetch(`${this.baseUrl}/${selecionarVacinas}`);
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
    async getById(consultarVacinasPorId, id) {
        try {
            const response = await fetch(`${this.baseUrl}/${consultarVacinasPorId}?id=${id}`);
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
    async post(inserirVacina, data) {
        try {
            const response = await fetch(`${this.baseUrl}/${inserirVacina}`, {
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
    async put(atualizarVacina, id, data) {
        try {
            const response = await fetch(`${this.baseUrl}/${atualizarVacina}?id=${id}`, {
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
    async delete(deletarVacina) {
        try {
            const response = await fetch(`${this.baseUrl}/${deletarVacina}`, {
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