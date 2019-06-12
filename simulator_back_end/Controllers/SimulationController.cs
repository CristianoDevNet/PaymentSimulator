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

        [HttpGet("{simulationId}")]
        public async Task<IActionResult> Get(int simulationId)
        {
            try
            {
                var result = await _repo.GetSimulationByIdAsync(simulationId);

                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados falhou");
            }
        }

        [HttpPost("simulate/")]
        public IActionResult Post(Simulado simul)
        {
            try
            {
                List<Parcela> parcelas = new List<Parcela>();
                
                decimal valorDaParcelaSemJuros = simul.Valor / simul.QtdParcelas;

                decimal valorDaParcelaComJuros = valorDaParcelaSemJuros * (1 + ((Math.Round(simul.Juros, 4) / 100)));
                
                for (int i = 1; i <= simul.QtdParcelas; i++)
                {
                    parcelas.Add(new Parcela{
                        NumeroDaParcela = i,
                        Vencimento = simul.DataDaCompra.AddMonths(i).ToShortDateString(),
                        Valor = Math.Round(valorDaParcelaComJuros, 2)
                    });
                }

                return Ok(parcelas);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados falhou");
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post(SimCab simulation)
        {
            try
            {
                _repo.Add(simulation);

                if(await _repo.SaveChangesAsync()){

                    return Ok(simulation);
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