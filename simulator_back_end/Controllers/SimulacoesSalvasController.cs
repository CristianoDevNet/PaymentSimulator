using Microsoft.AspNetCore.Mvc;

namespace simulator_back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SimulacoesSalvasController : ControllerBase
    {
        public SimulacoesSalvasController() {  }

        // [HttpGet]
        // public IActionResult Get(){
        //     return Ok();
        // }

        [HttpGet("{simulacaoId}")]
        public IActionResult Get(int simulacaoId){
            return Ok();
        }

        // [HttpPost]
        // public IActionResult Post([FromBody] string value){
        //     return Ok();
        // }

        // [HttpPut("{simulacaoId}")]
        // public IActionResult Put(int simulacaoId, [FromBody] string value){
        //     return Ok();
        // }

        // [HttpDelete("{simulacaoId}")]
        // public IActionResult Delete(int simulacaoId)
        // {
        //     return Ok();
        // }
    }
}