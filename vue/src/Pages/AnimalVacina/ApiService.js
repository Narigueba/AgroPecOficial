export default class ApiService{
    constructor(baseUrl = 'https://localhost:7001/AnimalVacina', baseUrlAnimal = 'https://localhost:7001/Animal', baseUrlVacina = 'https://localhost:7001/Vacina') {
        this.baseUrl = baseUrl;
        this.baseUrlAnimal = baseUrlAnimal;
        this.baseUrlVacina = baseUrlVacina;
    }

    async get(selecionarAnimaisEVacinas) {
        try {
            const response = await fetch(`${this.baseUrl}/${selecionarAnimaisEVacinas}`); 
            if (!response.ok) {
                throw new Error(`Erro: ${response.statusText}`);
            }
            return await response.json();
        } catch (error) {
            console.error('Erro ao fazer GET:', error);
            throw error;
        }
    }

    async getById(consultarAnimaisVacinasPorId, id) {
        try {
            const response = await fetch(`${this.baseUrl}/${consultarAnimaisVacinasPorId}?id=${id}`);
            if (!response.ok) {
                throw new Error(`Erro: ${response.statusText}`);
            }
            return await response.json();
        } catch (error) {
            console.error('Erro ao fazer GET:', error);
            throw error;
        }
    }

    async post(inserirAnimalVacina, data) {
        try {
            const response = await fetch(`${this.baseUrl}/${inserirAnimalVacina}`, {
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

    async put(atualizarAnimalVacina, id, data) {
        try {
            const response = await fetch(`${this.baseUrl}/${atualizarAnimalVacina}?id=${id}`, {
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

    async delete(deletarAnimalEVacina, id) {
        try {
            const response = await fetch(`${this.baseUrl}/${deletarAnimalEVacina}?id=${id}`, {
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
    async getAnimal(selecionarAnimais) {
        try {
            const response = await fetch(`${this.baseUrlAnimal}/${selecionarAnimais}`); 
            if (!response.ok) {
                throw new Error(`Erro: ${response.statusText}`);
            }
            return await response.json();
        } catch (error) {
            console.error('Erro ao fazer GET:', error);
            throw error;
        }
    }

    async getVacina(selecionarVacinas) {
        try {
            const response = await fetch(`${this.baseUrlVacina}/${selecionarVacinas}`); 
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