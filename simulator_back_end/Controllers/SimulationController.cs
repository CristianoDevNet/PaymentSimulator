using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using simulator_back_end.Data;
using simulator_back_end.Models;

namespace simulator_back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SimulationController : ControllerBase
    {
        private readonly IRepository _repo;
        public SimulationController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> Get(int userId)
        {
            try
            {
                var result = await _repo.GetSimulationsByUserIdAsync(userId);

                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados falhou");
            }
        }

        private List<Parcela> calcularParcelas(Simulacao simulacao){

            List<Parcela> parcelas = new List<Parcela>();
                
                decimal valorDaParcelaSemJuros = simulacao.ValorDaCompra / simulacao.QuantidadeDeParcelas;

                decimal valorDaParcelaComJuros = valorDaParcelaSemJuros * (1 + ((Math.Round(simulacao.Juros, 4) / 100)));
                
                for (int i = 1; i <= simulacao.QuantidadeDeParcelas; i++)
                {
                    parcelas.Add(new Parcela{
                        NumeroDaParcela = i,
                        Vencimento = simulacao.DataDaCompra.AddMonths(i).ToShortDateString(),
                        Valor = Math.Round(valorDaParcelaComJuros, 2)
                    });
                }
            
            return parcelas;
        }

        [HttpPost("simulate/")]
        public IActionResult Post(Simulacao novaSimulacao)
        {
            try
            {
                return Ok(calcularParcelas(novaSimulacao));
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados falhou");
            }
        }

        [HttpPost("save/")]
        public async Task<IActionResult> SavePost(Simulacao simulation)
        {
            simulation.ValorDaCompra = Math.Round(simulation.ValorDaCompra, 2);
            
            simulation.Juros = Math.Round(simulation.Juros, 4);

            try
            {
                _repo.Add(simulation);

                if(await _repo.SaveChangesAsync()){

                    return Ok("Simulação salva com sucesso!");
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados falhou");
            }

            return BadRequest("deu merda...");
        }
    }
}