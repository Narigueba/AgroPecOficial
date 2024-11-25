using AgroPec.DbContext;
using Microsoft.AspNetCore.Mvc;
using AgroPec.Model;

namespace AgroPec.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnimalController : Controller
    {
        private AppDbContext _context;

        public AnimalController(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpGet]
        [Route("selecionarAnimais")]
        public async Task<IActionResult> Selecionar()
        {
            var animais = new List<Animal>();
            try
            {
                _context.OpenConnection();

                var command = _context.CreateCommand();
                command.CommandText += "SELECT  ";
                command.CommandText += " agropec.animal.IdAnimal,";
                command.CommandText += " agropec.animal.NomeAnimal,";
                command.CommandText += " agropec.animal.Idade,";
                command.CommandText += " agropec.animal.IdTipoAnimal,";
                command.CommandText += " agropec.animal.IdRacao,";
                command.CommandText += " agropec.racao.NomeRacao,";
                command.CommandText += " agropec.racao.Peso AS PesoRacao,";
                command.CommandText += " agropec.racao.UnidadeMedida,";
                command.CommandText += " agropec.animal.DataNascimento,";
                command.CommandText += " agropec.animal.Sexo,";
                command.CommandText += " agropec.animal.Cor,";
                command.CommandText += " agropec.animal.Ninhada,";
                command.CommandText += " agropec.animal.Peso AS PesoAnimal,";
                command.CommandText += " agropec.animal.Raca,";
                command.CommandText += " agropec.tipoanimal.animal,";
                command.CommandText += " agropec.tipoanimal.Especie";
                command.CommandText += " FROM agropec.animal";
                command.CommandText += " JOIN agropec.tipoanimal";
                command.CommandText += " ON agropec.tipoanimal.IdTipoAnimal = agropec.animal.IdTipoAnimal";
                command.CommandText += " JOIN agropec.racao";
                command.CommandText += " ON agropec.racao.IdRacao = agropec.animal.IdRacao";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        animais.Add(new Animal
                        {
                            IdAnimal = reader.GetInt32("IdAnimal"),
                            NomeAnimal = reader.GetString("NomeAnimal"),
                            Idade = reader.GetInt32("Idade"),
                            DataNascimento = reader.GetDateTime("DataNascimento"),
                            Sexo = reader.GetString("Sexo"),
                            Cor = reader.GetString("Cor"),
                            Ninhada = reader.GetInt32("Ninhada"),
                            Peso = reader.GetDecimal("PesoAnimal"),
                            Raca = reader.GetString("Raca"),

                            Racao = 
                            { 
                                IdRacao = reader.GetInt32("IdRacao"), 
                                NomeRacao = reader.GetString("NomeRacao"),
                                Peso = reader.GetDecimal("PesoRacao"),
                                UnidadeMedida = reader.GetString("UnidadeMedida")
                            },

                            TipoAnimal = 
                            {
                                IdTipoAnimal = reader.GetInt32("IdTipoAnimal"),
                                Animal = reader.GetString("animal"),
                                Especie = reader.GetString("Especie"),
                            },

                        });
                    }
                }

                return Ok(animais);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            finally
            {
                _context.CloseConnection();
            }
        }
        [HttpGet]
        [Route ("consultarAnimaisPorId")]
        public async Task<IActionResult> ConsultarPorId([FromQuery] int id) 
        {
            var animal = new Animal();
            try
            {
                _context.OpenConnection();

                var command = _context.CreateCommand();
                command.CommandText += "SELECT  ";
                command.CommandText += " agropec.animal.IdAnimal,";
                command.CommandText += " agropec.animal.NomeAnimal,";
                command.CommandText += " agropec.animal.Idade,";
                command.CommandText += " agropec.animal.IdTipoAnimal,";
                command.CommandText += " agropec.animal.IdRacao,";
                command.CommandText += " agropec.racao.NomeRacao,";
                command.CommandText += " agropec.racao.Peso AS PesoRacao,";
                command.CommandText += " agropec.racao.UnidadeMedida,";
                command.CommandText += " agropec.animal.DataNascimento,";
                command.CommandText += " agropec.animal.Sexo,";
                command.CommandText += " agropec.animal.Cor,";
                command.CommandText += " agropec.animal.Ninhada,";
                command.CommandText += " agropec.animal.Peso AS PesoAnimal,";
                command.CommandText += " agropec.animal.Raca,";
                command.CommandText += " agropec.tipoanimal.animal,";
                command.CommandText += " agropec.tipoanimal.Especie";
                command.CommandText += " FROM agropec.animal";
                command.CommandText += " JOIN agropec.tipoanimal";
                command.CommandText += " ON agropec.tipoanimal.IdTipoAnimal = agropec.animal.IdTipoAnimal";
                command.CommandText += " JOIN agropec.racao";
                command.CommandText += " ON agropec.racao.IdRacao = agropec.animal.IdRacao";

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        animal = new Animal
                        {
                            IdAnimal = reader.GetInt32("IdAnimal"),
                            NomeAnimal = reader.GetString("NomeAnimal"),
                            Idade = reader.GetInt32("Idade"),
                            DataNascimento = reader.GetDateTime("DataNascimento"),
                            Sexo = reader.GetString("Sexo"),
                            Cor = reader.GetString("Cor"),
                            Ninhada = reader.GetInt32("Ninhada"),
                            Peso = reader.GetDecimal("PesoAnimal"),
                            Raca = reader.GetString("Raca"),

                            Racao =
                            {
                                IdRacao = reader.GetInt32("IdRacao"),
                                NomeRacao = reader.GetString("NomeRacao"),
                                Peso = reader.GetDecimal("PesoRacao"),
                                UnidadeMedida = reader.GetString("UnidadeMedida")
                            },

                            TipoAnimal =
                            {
                                IdTipoAnimal = reader.GetInt32("IdTipoAnimal"),
                                Animal = reader.GetString("animal"),
                                Especie = reader.GetString("Especie")
                            }
                        };
                    }
                }
                return Ok(animal);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            finally
            {
                _context.CloseConnection();
            }
        }

        [HttpPost]
        [Route("inserirAnimais")]
        public async Task<IActionResult> Inserir([FromBody] Animal animal)
        {
            try
            {
                _context.OpenConnection();
                var command = _context.CreateCommand();
                command.CommandText = @"INSERT INTO Animal (NomeAnimal, Idade, DataNascimento, Sexo, Cor, Ninhada, Peso, Fotos, 
                        IdRacao, IdTipoAnimal, Raca) 
                        VALUES (@NomeAnimal, @Idade, @DataNascimento, @Sexo, @Cor, @Ninhada, @Peso, @Fotos, @IdRacao, @IdTipoAnimal, @Raca)";

                command.Parameters.AddWithValue("@NomeAnimal", animal.NomeAnimal);
                command.Parameters.AddWithValue("@Idade", animal.Idade);
                command.Parameters.AddWithValue("@DataNascimento", animal.DataNascimento);
                command.Parameters.AddWithValue("@Sexo", animal.Sexo);
                command.Parameters.AddWithValue("@Cor", animal.Cor);
                command.Parameters.AddWithValue("@Ninhada", animal.Ninhada);
                command.Parameters.AddWithValue("@Peso", animal.Peso);
                command.Parameters.AddWithValue("@Fotos", animal.Fotos);
                command.Parameters.AddWithValue("@IdRacao", animal.IdRacao);
                command.Parameters.AddWithValue("@IdTipoAnimal", animal.IdTipoAnimal);
                command.Parameters.AddWithValue("@Raca", animal.Raca);

                command.ExecuteScalar();

                return Ok("Animal inserido com sucesso!!!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("atualizarAnimal")]
        public async Task<IActionResult> Atualizar([FromBody] Animal animal)
        {
            try
            {
                _context.OpenConnection();

                var command = _context.CreateCommand();
                command.CommandText = "UPDATE Animal SET NomeAnimal = @NomeAnimal, Idade = @Idade, DataNascimento = @DataNascimento, " +
                              "Sexo = @Sexo, Cor = @Cor, Ninhada = @Ninhada, Peso = @Peso, Fotos = @Fotos, " +
                              "IdRacao = @IdRacao, IdTipoAnimal = @IdTipoAnimal, Raca = @Raca WHERE IdAnimal = @IdAnimal";
                command.Parameters.AddWithValue("@IdAnimal", animal.IdAnimal);
                command.Parameters.AddWithValue("@NomeAnimal", animal.NomeAnimal);
                command.Parameters.AddWithValue("@Idade", animal.Idade);
                command.Parameters.AddWithValue("@DataNascimento", animal.DataNascimento);
                command.Parameters.AddWithValue("@Sexo", animal.Sexo);
                command.Parameters.AddWithValue("@Cor", animal.Cor);
                command.Parameters.AddWithValue("@Ninhada", animal.Ninhada);
                command.Parameters.AddWithValue("@Peso", animal.Peso);
                command.Parameters.AddWithValue("@Fotos", animal.Fotos);
                command.Parameters.AddWithValue("@IdRacao", animal.IdRacao);
                command.Parameters.AddWithValue("@IdTipoAnimal", animal.IdTipoAnimal);
                command.Parameters.AddWithValue("@Raca", animal.Raca);

                command.ExecuteNonQuery();

                return Ok("Animal atualizado com sucesso!!!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message} - Detalhes: {ex.InnerException?.Message}");
            }
        }

        [HttpDelete]
        [Route("deletarAnimal")]

        public async Task<IActionResult> Deletar([FromQuery] int id)
        {
            try
            {
                _context.OpenConnection();

                var command = _context.CreateCommand();
                command.CommandText = "DELETE FROM Animal WHERE IdAnimal = @IdAnimal";
                command.Parameters.AddWithValue("@IdAnimal", id);

                command.ExecuteNonQuery();

                return Ok("Animal deletado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message} - Detalhes: {ex.InnerException?.Message}");
            }
        }
    }
}
