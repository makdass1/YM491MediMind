using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {

        [HttpGet("public")]
        public IActionResult PublicEndpoint()
        {
            return Ok("Merhaba! Burası halka açık alan, herkes girebilir.");
        }

      
        [Authorize]
        [HttpGet("private")]
        public IActionResult PrivateEndpoint()
        {
           
            var sicilNo = User.Claims.FirstOrDefault(c => c.Type == "Registiration_number")?.Value;
            return Ok($"Merhaba Doktor! İçeri girdiniz. Sicil Numaranız: {sicilNo}");
        }
    }
}