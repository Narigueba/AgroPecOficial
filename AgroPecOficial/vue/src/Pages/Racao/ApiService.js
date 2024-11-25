export default class ApiService {
    constructor(baseUrl = 'https://localhost:7001/Racao', baseUrlTipoAnimal = 'https://localhost:7001/TipoAnimal') {
        this.baseUrl = baseUrl;
        this.baseUrlTipoAnimal = baseUrlTipoAnimal;
    }

    // async getTipoAnimal(selecionarTipoAnimal) {
    //     try {
    //         const response = await fetch(`${this.baseUrlTipoAnimal}/${selecionarTipoAnimal}`);
    //         if (!response.ok) {
    //             throw new Error(`Erro: ${response.statusText}`);
    //         }
    //         return await response.json();
    //     } catch (error) {
    //         console.error('Erro ao fazer GET:', error);
    //         throw error;
    //     }
    // }


    // Método GET para buscar dados
    async get(selecionarRacoes) {
        try {
            const response = await fetch(`${this.baseUrl}/${selecionarRacoes}`);
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
    async getById(consultarRacaoPorId, id) {
        try {
            const response = await fetch(`${this.baseUrl}/${consultarRacaoPorId}?id=${id}`);
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
    async post(inserirRacao, data) {
        try {
            const response = await fetch(`${this.baseUrl}/${inserirRacao}`, {
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
    async put(atualizarRacao, id, data) {
        try {
            console.log(data)
            const response = await fetch(`${this.baseUrl}/${atualizarRacao}?id=${id}`, {
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

    async delete(deletarRacao) {
        try {
            const response = await fetch(`${this.baseUrl}/${deletarRacao}`, {
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