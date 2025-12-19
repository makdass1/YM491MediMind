using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace App.Service.Services
{
    public class KeycloakAdminService
    {
        private readonly HttpClient _http;
        private readonly IConfiguration _config;

        public KeycloakAdminService(HttpClient http, IConfiguration config)
        {
            _http = http;
            _config = config;
        }

        private async Task<string> GetAdminTokenAsync()
        {
            var form = new Dictionary<string, string>
            {
                ["client_id"] = _config["Keycloak:ClientId"],
                ["client_secret"] = _config["Keycloak:ClientSecret"],
                ["grant_type"] = "client_credentials"
            };

            var response = await _http.PostAsync(
                $"{_config["Keycloak:BaseUrl"]}/realms/{_config["Keycloak:Realm"]}/protocol/openid-connect/token",
                new FormUrlEncodedContent(form)
            );

            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                throw new Exception(content);

            return JsonDocument.Parse(content)
                .RootElement.GetProperty("access_token")
                .GetString()!;
        }


        public async Task RegisterAsync(Dtos.RegisterRequest request)
        {
            // 🔐 VALIDATION
            if (request.Role != "user" && request.Role != "doctor")
                throw new Exception("Role sadece user veya doctor olabilir");

            if (request.Role == "doctor" && string.IsNullOrWhiteSpace(request.RegistrationNumber))
                throw new Exception("Doctor için RegistrationNumber zorunludur");

            var token = await GetAdminTokenAsync();
            _http.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            // 👤 USER CREATE
            var userPayload = new
            {
                firstName=request.Name,
                lastName=request.Surname,
                username = request.Email,
                email = request.Email,
                enabled = true,
                attributes = request.Role == "doctor"
                    ? new Dictionary<string, string[]>
                    {
                        ["Registiration_number"] = new[] { request.RegistrationNumber! }
                    }
                    : null,
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

            var createResponse = await _http.PostAsync(
                $"{_config["Keycloak:BaseUrl"]}/admin/realms/{_config["Keycloak:Realm"]}/users",
                new StringContent(JsonSerializer.Serialize(userPayload), Encoding.UTF8, "application/json")
            );

            if (!createResponse.IsSuccessStatusCode)
            {
                var err = await createResponse.Content.ReadAsStringAsync();
                throw new Exception("User create failed: " + err);
            }

            // 🆔 USER ID AL (USERNAME = EMAIL → GARANTİLİ)
            var userSearch = await _http.GetStringAsync(
                $"{_config["Keycloak:BaseUrl"]}/admin/realms/{_config["Keycloak:Realm"]}/users?username={request.Email}"
            );

            var users = JsonDocument.Parse(userSearch).RootElement;

            if (users.GetArrayLength() == 0)
                throw new Exception("User bulunamadı");

            var userId = users[0].GetProperty("id").GetString();

            // 🎭 ROLE BUL
            var roleJson = await _http.GetStringAsync(
                $"{_config["Keycloak:BaseUrl"]}/admin/realms/{_config["Keycloak:Realm"]}/roles/{request.Role}"
            );

            var role = JsonDocument.Parse(roleJson).RootElement;

            // ➕ ROLE ATA
            var assignResponse = await _http.PostAsync(
                $"{_config["Keycloak:BaseUrl"]}/admin/realms/{_config["Keycloak:Realm"]}/users/{userId}/role-mappings/realm",
                new StringContent($"[{role}]", Encoding.UTF8, "application/json")
            );

            if (!assignResponse.IsSuccessStatusCode)
                throw new Exception("Role atama başarısız");
        }
    }
}
