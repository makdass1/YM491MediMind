using App.Service.Services;
using App.Repository.Entities;
using Microsoft.AspNetCore.Mvc;



[ApiController]
[Route("api/identity")]
public class IdentityController : ControllerBase
{
    private readonly KeycloakAdminService _keycloakService;

    public IdentityController(KeycloakAdminService keycloakService)
    {
        _keycloakService = keycloakService;
    }


    // 1️⃣ USER CREATE
    [HttpPost("user")]
    public async Task<IActionResult> CreateUser(User request)
    {
        var payload = new
        {
            
            email = request.Mail,
            firstName = request.Name,
            lastName = request.LastName,
            enabled = true,
            credentials = new[]
            {
                new
                {
                    type = "password",
                    value = request.Password,
                    temporary = false
                }
            }
        };

        await _keycloakService.CreateUserAsync(payload);

        return Ok("User created");
    }

    // 2️⃣ DOCTOR CREATE
    [HttpPost("doctor")]
    public async Task<IActionResult> CreateDoctor(Doctor request)
    {
        var payload = new
        {
            username = request.Registiration_number,
            enabled = true,
            attributes = new Dictionary<string, string[]>
            {
                ["registrationNumber"] = new[] { request.Registiration_number }
            },
            credentials = new[]
            {
                new
                {
                    type = "password",
                    value = request.Password,
                    temporary = false
                }
            }
        };

        await _keycloakService.CreateUserAsync(payload);

        return Ok("Doctor created");
    }
}
