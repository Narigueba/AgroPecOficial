﻿using AgroPec.DbContext;
using Microsoft.AspNetCore.Mvc;
using AgroPec.Model;

namespace AgroPec.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class RacaoController : Controller
    {
        private AppDbContext _context;

        public RacaoController(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpGet]
        [Route("consultarRacaoPorId")]
        public async Task<IActionResult> ConsultarPorId([FromQuery] int id)
        {
            var racao = new Racao();
            try
            {
                _context.OpenConnection();

                var command = _context.CreateCommand();
                command.CommandText = $"SELECT IdRacao, NomeRacao, Peso, UnidadeMedida FROM Racao WHERE 1 = 1 AND Racao.IdRacao = {id}";

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        racao = new Racao
                        {
                            IdRacao = reader.GetInt32("IdRacao"),
                            NomeRacao = reader.GetString("NomeRacao"),
                            Peso = reader.GetDecimal("Peso"),
                            UnidadeMedida = reader.GetString("UnidadeMedida"),
                        };
                    }
                }

                return Ok(racao);
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
        [Route("selecionarRacoes")]
        public async Task<IActionResult> Selecionar()
        {
            var racoes = new List<Racao>();
            try
            {
                _context.OpenConnection();

                var command = _context.CreateCommand();
                command.CommandText = "SELECT IdRacao, NomeRacao, Peso, UnidadeMedida FROM Racao";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        racoes.Add(new Racao
                        {
                            IdRacao = reader.GetInt32("IdRacao"),
                            NomeRacao = reader.GetString("NomeRacao"),
                            Peso = reader.GetDecimal("Peso"),
                            UnidadeMedida = reader.GetString("UnidadeMedida"),
                        });
                    }
                }

                return Ok(racoes);
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
        [Route("inserirRacao")]
        public async Task<IActionResult> Inserir([FromBody] Racao racao)
        {
            try
            {
                _context.OpenConnection();
                var command = _context.CreateCommand();

                command.CommandText = $"INSERT INTO Racao (NomeRacao, Peso, UnidadeMedida) VALUES ('{racao.NomeRacao}', {racao.Peso}, '{racao.UnidadeMedida}')";

                command.ExecuteNonQuery();

                _context.CloseConnection();

                return Ok(new { message = "Ração Inserida com Sucesso!!!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("atualizarRacao")]
        public async Task<IActionResult> Atualizar([FromQuery] int id, [FromBody] Racao racao)
        {
            try
            {
                _context.OpenConnection();

                var command = _context.CreateCommand();
                command.CommandText = "UPDATE Racao SET NomeRacao = @NomeRacao, Peso = @Peso, UnidadeMedida = @UnidadeMedida WHERE IdRacao = @IdRacao";
                command.Parameters.AddWithValue("@IdRacao", id);
                command.Parameters.AddWithValue("@NomeRacao", racao.NomeRacao);
                command.Parameters.AddWithValue("@Peso", racao.Peso);
                command.Parameters.AddWithValue("@UnidadeMedida", racao.UnidadeMedida);

                command.ExecuteNonQuery();

                return Ok( new { message = "Ração atualizada com Sucesso!!!" });
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

        [HttpDelete]
        [Route("deletarRacao")]
        public async Task<IActionResult> Deletar([FromQuery] int id)
        {
            try
            {
                _context.OpenConnection();

                var command = _context.CreateCommand();
                command.CommandText = "DELETE FROM Racao WHERE IdRacao = @IdRacao";
                command.Parameters.AddWithValue("@IdRacao", id);

                command.ExecuteNonQuery();

                _context.CloseConnection();

                return Ok(new { message = "Ração Deletada com Sucesso!!!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
