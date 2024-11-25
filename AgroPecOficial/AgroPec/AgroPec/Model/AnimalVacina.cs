namespace AgroPec.Model
{
    public class AnimalVacina
    {
        public int IdAnimalVacina { get; set; }
        public int IdAnimal { get; set; }
        public Animal Animal { get; set; } = new Animal();
        public int IdVacina { get; set; }
        public Vacina Vacina { get; set; } = new Vacina();
        public DateTime DataVacina { get; set; }
        
    }
}
