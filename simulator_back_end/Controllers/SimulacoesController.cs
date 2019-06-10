using Microsoft.AspNetCore.Mvc;

namespace simulator_back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SimCabController : ControllerBase
    {
        public SimCabController() { }

        // [HttpGet]
        // public IActionResult Get(){
        //     return Ok();
        // }

        // [HttpGet("{simulacaoId}")]
        // public IActionResult Get(int simulacaoId){
        //     return Ok();
        // }

        [HttpPost]
        public IActionResult Post([FromBody] string value){
            return Ok("caiu no post");
        }

        // [HttpPut("{simulacaoId}")]
        // public IActionResult Put(int id, [FromBody] string value){
        //     return Ok();
        // }

        // [HttpDelete("{simulacaoId}")]
        // public IActionResult Delete(int id)
        // {
        //     return Ok();    
        // }
    }
}