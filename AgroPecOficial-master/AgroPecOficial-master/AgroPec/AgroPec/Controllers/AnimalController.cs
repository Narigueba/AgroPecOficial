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
                command.CommandText += @"SELECT  
                                         agropec.animal.IdAnimal,
                                         agropec.animal.NomeAnimal,
                                         agropec.animal.Idade,
                                         agropec.animal.IdTipoAnimal,
                                         agropec.animal.IdRacao,
                                         agropec.racao.NomeRacao,
                                         agropec.racao.Peso AS PesoRacao,
                                         agropec.racao.UnidadeMedida,
                                         agropec.animal.DataNascimento,
                                         agropec.animal.Sexo,
                                         agropec.animal.Cor,
                                         agropec.animal.Ninhada,
                                         agropec.animal.Peso AS PesoAnimal,
                                         agropec.animal.Raca,
                                         agropec.tipoanimal.animal,
                                         agropec.tipoanimal.Especie
                                         FROM agropec.animal
                                         LEFT JOIN agropec.tipoanimal
                                         ON agropec.tipoanimal.IdTipoAnimal = agropec.animal.IdTipoAnimal
                                         LEFT JOIN agropec.racao
                                         ON agropec.racao.IdRacao = agropec.animal.IdRacao ";

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

                            Racao = reader.IsDBNull(reader.GetOrdinal("IdRacao")) ? null : new Racao
                            {
                                IdRacao = reader.GetInt32("IdRacao"),
                                NomeRacao = reader.IsDBNull(reader.GetOrdinal("NomeRacao")) ? null : reader.GetString("NomeRacao"),
                                Peso = reader.IsDBNull(reader.GetOrdinal("PesoRacao")) ? (decimal?)null : reader.GetDecimal("PesoRacao"),
                                UnidadeMedida = reader.IsDBNull(reader.GetOrdinal("UnidadeMedida")) ? null : reader.GetString("UnidadeMedida")
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
                command.CommandText += " agropec.animal.idAnimal,";
                command.CommandText += " agropec.animal.nomeAnimal,";
                command.CommandText += " agropec.animal.idade,";
                command.CommandText += " agropec.animal.idTipoAnimal,";
                command.CommandText += " agropec.animal.idRacao,";
                command.CommandText += " agropec.racao.nomeRacao,";
                command.CommandText += " agropec.racao.peso AS PesoRacao,";
                command.CommandText += " agropec.racao.UnidadeMedida,";
                command.CommandText += " agropec.animal.dataNascimento,";
                command.CommandText += " agropec.animal.sexo,";
                command.CommandText += " agropec.animal.cor,";
                command.CommandText += " agropec.animal.ninhada,";
                command.CommandText += " agropec.animal.peso AS PesoAnimal,";
                command.CommandText += " agropec.animal.raca,";
                command.CommandText += " agropec.tipoanimal.animal,";
                command.CommandText += " agropec.tipoanimal.especie";
                command.CommandText += " FROM agropec.animal";
                command.CommandText += " JOIN agropec.tipoanimal";
                command.CommandText += " ON agropec.tipoanimal.idTipoAnimal = agropec.animal.idTipoAnimal";
                command.CommandText += " JOIN agropec.racao";
                command.CommandText += " ON agropec.racao.idRacao = agropec.animal.idRacao";

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
                command.Parameters.AddWithValue("@IdRacao", animal.Racao.IdRacao);
                command.Parameters.AddWithValue("@IdTipoAnimal", animal.TipoAnimal.IdTipoAnimal);
                command.Parameters.AddWithValue("@Raca", animal.Raca);

                command.ExecuteScalar();

                _context.CloseConnection();

                return Ok(new { message = "Animal inserido com sucesso!!!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("atualizarAnimal")]
        public async Task<IActionResult> Atualizar([FromQuery] int id, [FromBody] Animal animal)
        {
            try
            {
                _context.OpenConnection();

                var command = _context.CreateCommand();
                command.CommandText = "UPDATE Animal SET NomeAnimal = @NomeAnimal, Idade = @Idade, DataNascimento = @DataNascimento, " +
                              "Sexo = @Sexo, Cor = @Cor, Ninhada = @Ninhada, Peso = @Peso, Fotos = @Fotos, " +
                              "IdRacao = @IdRacao, IdTipoAnimal = @IdTipoAnimal, Raca = @Raca WHERE IdAnimal = @IdAnimal";
                command.Parameters.AddWithValue("@IdAnimal", id);
                command.Parameters.AddWithValue("@NomeAnimal", animal.NomeAnimal);
                command.Parameters.AddWithValue("@Idade", animal.Idade);
                command.Parameters.AddWithValue("@DataNascimento", animal.DataNascimento);
                command.Parameters.AddWithValue("@Sexo", animal.Sexo);
                command.Parameters.AddWithValue("@Cor", animal.Cor);
                command.Parameters.AddWithValue("@Ninhada", animal.Ninhada);
                command.Parameters.AddWithValue("@Peso", animal.Peso);
                command.Parameters.AddWithValue("@Fotos", animal.Fotos);
                command.Parameters.AddWithValue("@IdRacao", animal.Racao.IdRacao);
                command.Parameters.AddWithValue("@IdTipoAnimal", animal.TipoAnimal.IdTipoAnimal);
                command.Parameters.AddWithValue("@Raca", animal.Raca);

                command.ExecuteNonQuery();

                _context.CloseConnection();

                return Ok(new { message = "Animal atualizado com sucesso!!!" });
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

                _context.CloseConnection();

                return Ok(new { message = "Animal deletado com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message} - Detalhes: {ex.InnerException?.Message}");
            }
        }
    }
}
