using Microsoft.AspNetCore.Mvc;
using AgroPec.DbContext;
using AgroPec.Model;

namespace AgroPec.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnimalVacinaController : Controller
    {
        private AppDbContext _context;

        public AnimalVacinaController(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpGet]
        [Route("selecionarAnimaisEVacinas")]

        public async Task<IActionResult> Selecionar()
        {
            var animalVacina = new List<AnimalVacina>();
            try
            {
                _context.OpenConnection();

                var command = _context.CreateCommand();
                command.CommandText += "SELECT   ";
                command.CommandText += " agropec.animalvacina.IdAnimalVacina,";
                command.CommandText += " agropec.animal.IdAnimal,";
                command.CommandText += " agropec.animal.NomeAnimal,";
                command.CommandText += " agropec.vacina.IdVacina,";
                command.CommandText += " agropec.vacina.TipoVacina,";
                command.CommandText += " agropec.animalvacina.DataVacina";
                command.CommandText += " FROM agropec.animalvacina";
                command.CommandText += " JOIN agropec.animal";
                command.CommandText += " ON agropec.animal.IdAnimal = agropec.animalvacina.IdVacina";
                command.CommandText += " JOIN agropec.vacina";
                command.CommandText += " ON agropec.vacina.IdVacina = agropec.animalvacina.IdVacina";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        animalVacina.Add(new AnimalVacina
                        {

                            IdAnimalVacina = reader.GetInt32("IdAnimalVacina"),

                            Animal =
                            {
                                IdAnimal = reader.GetInt32("IdAnimal"),
                                NomeAnimal = reader.GetString("NomeAnimal")
                            },

                            Vacina =
                            {
                                IdVacina = reader.GetInt32("IdVacina"),
                                TipoVacina = reader.GetString("TipoVacina")
                            },

                            DataVacina = reader.GetDateTime("DataVacina")

                        });
                    }
                }

                return Ok(animalVacina);
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
        [Route("consultarAnimaisVacinasPorId")]
        public async Task<IActionResult> ConsultarPorId([FromQuery] int id)
        {
            var animalVacina = new AnimalVacina();
            try
            {
                _context.OpenConnection();

                var command = _context.CreateCommand();
                command.CommandText += $"SELECT   ";
                command.CommandText += " agropec.animalvacina.IdAnimalVacina,";
                command.CommandText += " agropec.animal.IdAnimal,";
                command.CommandText += " agropec.animal.NomeAnimal,";
                command.CommandText += " agropec.vacina.IdVacina,";
                command.CommandText += " agropec.vacina.TipoVacina,";
                command.CommandText += " agropec.animalvacina.DataVacina";
                command.CommandText += " FROM agropec.animalvacina";
                command.CommandText += " JOIN agropec.animal";
                command.CommandText += " ON agropec.animal.IdAnimal = agropec.animalvacina.IdVacina";
                command.CommandText += " JOIN agropec.vacina";
                command.CommandText += " ON agropec.vacina.IdVacina = agropec.animalvacina.IdVacina";
                command.CommandText += $" WHERE 1 = 1 AND animalvacina.IdAnimalVacina = {id}";

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        animalVacina = new AnimalVacina
                        {
                            IdAnimalVacina = reader.GetInt32("IdAnimalVacina"),

                            Animal =
                            {
                                IdAnimal = reader.GetInt32("IdAnimal"),
                                NomeAnimal = reader.GetString("NomeAnimal")
                            },

                            Vacina =
                            {
                                IdVacina = reader.GetInt32("IdVacina"),
                                TipoVacina = reader.GetString("TipoVacina")
                            },

                            DataVacina = reader.GetDateTime("DataVacina")

                        };
                    }
                }

                return Ok(animalVacina);
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
        [Route("inserirAnimalVacina")]
        public async Task<IActionResult> Inserir([FromBody] AnimalVacina animalVacina)
        {
            try
            {
                _context.OpenConnection();
                var command = _context.CreateCommand();
                command.CommandText = @"INSERT INTO animalvacina (IdAnimal, IdVacina, DataVacina)
                        VALUES (@IdAnimal, @IdVacina, @DataVacina)";

                command.Parameters.AddWithValue("@IdAnimal", animalVacina.IdAnimal);
                command.Parameters.AddWithValue("@IdVacina", animalVacina.IdVacina);
                command.Parameters.AddWithValue("@DataVacina", animalVacina.DataVacina);

                command.ExecuteScalar();

                return Ok("Animal e Vacina inserido com sucesso!!!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("atualizarAnimalVacina")]
        public async Task<IActionResult> Atualizar([FromQuery] AnimalVacina animalVacina)
        {
            try
            {
                _context.OpenConnection();

                var command = _context.CreateCommand();
                command.CommandText = "UPDATE animalvacina SET IdAnimal = @IdAnimal, IdVacina = @IdVacina, DataVacina = @DataVacina " +
                    "WHERE IdAnimalVacina = @IdAnimalVacina";
                command.Parameters.AddWithValue("@IdAnimalVacina", animalVacina.IdAnimalVacina);
                command.Parameters.AddWithValue("@IdAnimal", animalVacina.IdAnimal);
                command.Parameters.AddWithValue("@IdVacina", animalVacina.IdVacina);
                command.Parameters.AddWithValue("@DataVacina", animalVacina.DataVacina);

                command.ExecuteNonQuery();

                return Ok("Animal e Vacina atualizado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message} - Detalhes: {ex.InnerException?.Message}");
            }
        }
        [HttpDelete]
        [Route("deletarAnimalEVacina")]
        public async Task<IActionResult> Deletar([FromQuery] int id)
        {
            try
            {

                _context.OpenConnection();

                var command = _context.CreateCommand();
                command.CommandText = "DELETE FROM animalvacina WHERE IdAnimalVacina = @IdAnimalVacina";
                command.Parameters.AddWithValue("@IdAnimalVacina", id);

                command.ExecuteNonQuery();

                return Ok("Animal e Vacina deletado com sucesso!!!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
