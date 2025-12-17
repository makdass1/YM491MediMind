using Microsoft.AspNetCore.Mvc;
using App.Service.Services;
using App.Service.Dtos;

namespace App.API.Controllers
{
    [ApiController]
    [Route("api/identity")]
    public class IdentityController : ControllerBase
    {
        private readonly KeycloakAdminService _service;

        public IdentityController(KeycloakAdminService service)
        {
            _service = service;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            await _service.RegisterAsync(request);
            return Ok("Registered & role assigned");
        }
    }
}
