using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using simulator_back_end.Data;
using simulator_back_end.Models;

namespace simulator_back_end.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IRepository _repo { get; }
        public UserController(IRepository repo)
        {
            _repo = repo;
        }

        // [HttpGet("{email}/{pass}")]
        // public async Task<IActionResult> Get(string email, string pass)
        // {
        //     try
        //     {
        //         var result = await _repo.GetUserAsync(email, pass);

        //         return Ok(result);
        //     }
        //     catch (System.Exception)
        //     {
        //         return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados falhou");
        //     }
        // }

        [HttpPost]
        public async Task<IActionResult> Post(Usuario user)
        {
            try
            {
                var result = await _repo.GetUserAsync(user.Email, user.Senha);

                if (await _repo.SaveChangesAsync())
                {
                    //return Created($"/api/")
                    return Ok(result);
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados falhou");
            }

            return BadRequest();
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