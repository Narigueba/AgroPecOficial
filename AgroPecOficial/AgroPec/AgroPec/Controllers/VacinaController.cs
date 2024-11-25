using AgroPec.DbContext;
using Microsoft.AspNetCore.Mvc;
using AgroPec.Model;

namespace AgroPec.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class VacinaController : Controller
    {
        private AppDbContext _context;

        public VacinaController(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpGet]
        [Route("consultarVacinasPorId")]
        public async Task<IActionResult> ConsultarPorId([FromQuery] int id)
        {
            var vacina = new Vacina();
            try
            {
                _context.OpenConnection();

                var command = _context.CreateCommand();
                command.CommandText = $"SELECT IdVacina, TipoVacina FROM vacina WHERE 1 = 1 AND vacina.IdVacina = {id}";

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        vacina = new Vacina
                        {
                            IdVacina = reader.GetInt32("IdVacina"),
                            TipoVacina = reader.GetString("TipoVacina"),
                        };
                    }
                }

                return Ok(vacina);
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
        [Route("selecionarVacinas")]
        public async Task<IActionResult> Selecionar()
        {
            var vacinas = new List<Vacina>();
            try
            {
                _context.OpenConnection();

                var command = _context.CreateCommand();
                command.CommandText = "SELECT IdVacina, TipoVacina FROM vacina";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        vacinas.Add(new Vacina
                        {
                            IdVacina = reader.GetInt32("IdVacina"),
                            TipoVacina = reader.GetString("TipoVacina"),
                        });
                    }
                }

                return Ok(vacinas);
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
        [Route("inserirVacina")]
        public async Task<IActionResult> Inserir([FromBody] Vacina vacina)
        {
            try
            {
                _context.OpenConnection();
                var command = _context.CreateCommand();

                command.CommandText = $"INSERT INTO vacina (TipoVacina) VALUES ('{vacina.TipoVacina}')";
                //command.Parameters.AddWithValue("@Nome", produto.Nome);
                //command.Parameters.AddWithValue("@Preco", produto.Preco);

                command.ExecuteScalar();

                return Ok("Vacina inserida com sucesso!!!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("atualizarVacina")]
        public async Task<IActionResult> Atualizar([FromBody] Vacina vacina)
        {
            try
            {
                _context.OpenConnection();

                var command = _context.CreateCommand();
                command.CommandText = "UPDATE vacina SET TipoVacina = @TipoVacina WHERE IdVacina = @IdVacina";
                command.Parameters.AddWithValue("@IdVacina", vacina.IdVacina);
                command.Parameters.AddWithValue("@TipoVacina", vacina.TipoVacina);

                command.ExecuteNonQuery();

                return Ok("Vacina atualizada com Sucesso!!!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("deletarVacina")]
        public async Task<IActionResult> Deletar([FromQuery] int id)
        {
            try
            {
                _context.OpenConnection();

                var command = _context.CreateCommand();
                command.CommandText = "DELETE FROM vacina WHERE IdVacina = @IdVacina";
                command.Parameters.AddWithValue("@IdVacina", id);

                command.ExecuteNonQuery();

                return Ok("Vacina excluida com sucesso!!!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
