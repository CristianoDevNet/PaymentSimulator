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
                return Ok("ok simulate...");
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

                    return Ok("Adicionado");
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