using App.Service.Dtos;
using App.Service.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
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

        [HttpPost("login/user")]
        public async Task<IActionResult> UserLogin(
     [FromBody] UserLoginRequest request,
     [FromServices] ParalelDbService dbService)
        {
            var tokenJson = await _authService.LoginAsync(
                request.Email,
                request.Password
            );

            var token = JsonSerializer.Deserialize<TokenResponse>(tokenJson)!;

            var keycloakUserId = JwtHelper.GetUserIdFromToken(token.access_token);

            var userId = await dbService.GetUserIdByKeycloakIdAsync(keycloakUserId);

            return Ok(new
            {
                accessToken = token.access_token,
                userId = userId
            });
        }

        [HttpPost("login/doctor")]
        public async Task<IActionResult> DoctorLogin(
            [FromBody] DoctorLoginRequest request,
            [FromServices] ParalelDbService dbService)
        {
            var tokenJson = await _authService.DoctorLoginAsync(
                request.RegistrationNumber,
                request.Password
            );

            var token = JsonSerializer.Deserialize<TokenResponse>(tokenJson)!;

            var keycloakUserId = JwtHelper.GetUserIdFromToken(token.access_token);

            var doctorId = await dbService.GetDoctorIdByKeycloakIdAsync(keycloakUserId);

            return Ok(new
            {
                accessToken = token.access_token,
                doctorId = doctorId
            });
        }


    }
}