namespace AgroPec.Model
{
    public class Animal
    {
        public int IdAnimal { get; set; }
        public string NomeAnimal { get; set; }
        public int Idade {  get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string Cor { get; set; }
        public int Ninhada { get; set; }
        public decimal Peso { get; set; }
        public string Fotos { get; set; }
        public string Raca { get; set; }

        //chaves estrangeiras

        public int IdRacao { get; set; }
        public Racao Racao { get; set; } = new Racao();
        public int IdTipoAnimal { get; set; }
        public TipoAnimal TipoAnimal { get; set; } = new TipoAnimal();

    }
}
