using AgroPec.DbContext;
using Microsoft.AspNetCore.Mvc;
using AgroPec.Model;

namespace AgroPec.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class TipoAnimalController : Controller
    {
        private AppDbContext _context;

        public TipoAnimalController(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpGet]
        [Route("consultarTiposAnimaisPorId")]
        public async Task<IActionResult> ConsultarPorId([FromQuery] int id)
        {
            var tipoAnimal = new TipoAnimal();
            try
            {
                _context.OpenConnection();

                var command = _context.CreateCommand();
                command.CommandText = $"SELECT IdTipoAnimal, Animal, Especie FROM tipoanimal WHERE 1 = 1 AND tipoanimal.IdTipoAnimal = {id}";

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        tipoAnimal = new TipoAnimal
                        {
                            IdTipoAnimal = reader.GetInt32("IdTipoAnimal"),
                            Animal = reader.GetString("Animal"),
                            Especie = reader.GetString("Especie"),
                        };
                    }
                }

                return Ok(tipoAnimal);
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
        [Route("selecionarTiposAnimais")]
        public async Task<IActionResult> Selecionar()
        {
            var tiposAnimais = new List<TipoAnimal>();
            try
            {
                _context.OpenConnection();

                var command = _context.CreateCommand();
                command.CommandText = "SELECT IdTipoAnimal, Animal, Especie FROM tipoanimal";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tiposAnimais.Add(new TipoAnimal
                        {
                            IdTipoAnimal = reader.GetInt32("IdTipoAnimal"),
                            Animal = reader.GetString("Animal"),
                            Especie = reader.GetString("Especie"),
                        });
                    }
                }

                return Ok(tiposAnimais);
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
        [Route("inserirTiposAnimais")]
        public async Task<IActionResult> Inserir([FromBody] TipoAnimal tipoAnimal)
        {
            try
            {
                _context.OpenConnection();
                var command = _context.CreateCommand();

                command.CommandText = $"INSERT INTO tipoanimal (Animal, Especie) VALUES ('{tipoAnimal.Animal}','{tipoAnimal.Especie}')";
                //command.Parameters.AddWithValue("@Nome", produto.Nome);
                //command.Parameters.AddWithValue("@Preco", produto.Preco);

                command.ExecuteScalar();

                return Ok("Tipo de Animal inserido com sucesso!!!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("atualizarTipoAnimal")]
        public async Task<IActionResult> Atualizar([FromBody] TipoAnimal tipoAnimal)
        {
            try
            {
                _context.OpenConnection();

                var command = _context.CreateCommand();
                command.CommandText = "UPDATE tipoanimal SET Animal = @Animal, Especie = @Especie WHERE IdTipoAnimal = @IdTipoAnimal";
                command.Parameters.AddWithValue("@IdTipoAnimal", tipoAnimal.IdTipoAnimal);
                command.Parameters.AddWithValue("@Animal", tipoAnimal.Animal);
                command.Parameters.AddWithValue("@Especie", tipoAnimal.Especie);

                command.ExecuteNonQuery();

                return Ok("Tipo de animal atualizad0 com Sucesso!!!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
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
                command.CommandText = "DELETE FROM tipoanimal WHERE IdTipoAnimal = @IdTipoAnimal";
                command.Parameters.AddWithValue("@IdTipoAnimal", id);

                command.ExecuteNonQuery();

                return Ok("Tipo de animal excluido com sucesso!!!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
