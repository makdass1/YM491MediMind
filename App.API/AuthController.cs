using App.Service.Dtos;
using App.Service.Services;
using Microsoft.AspNetCore.Mvc;
namespace App.API
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly KeycloakAuthService _authService;

        public AuthController(KeycloakAuthService authService)
        {
            _authService = authService;
        }

        // 1️⃣ USER LOGIN (email + password)
        [HttpPost("login/user")]
        public async Task<IActionResult> UserLogin([FromBody] UserLoginRequest request)
        {
            var token = await _authService.LoginAsync(
                request.Email,
                request.Password
            );

            return Ok(token);
        }

        // 2️⃣ DOCTOR LOGIN (registrationNumber + password)
        [HttpPost("login/doctor")]
        public async Task<IActionResult> DoctorLogin(DoctorLoginRequest request)
        {
            var token = await _authService.DoctorLoginAsync(
                request.RegistrationNumber,
                request.Password
            );

            return Ok(token);
        }
    }
}