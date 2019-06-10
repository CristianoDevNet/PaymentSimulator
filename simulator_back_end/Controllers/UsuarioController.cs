using Microsoft.AspNetCore.Mvc;

namespace simulator_back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        public UsuarioController() { }

        //[HttpGet]
        // public IActionResult Get()
        // {
        //     return Ok();
        // }

        [HttpGet("{usuarioId}")]
        public IActionResult Get(int usuarioId)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
        }

        // [HttpPut("{userId}")]
        // public IActionResult Put(int id, [FromBody] string value){
        //     return Ok();
        // }

        // [HttpDelete("{userId}")]
        // public IActionResult Delete(int id)
        // {
        //     return Ok();    
        // }
    }
}