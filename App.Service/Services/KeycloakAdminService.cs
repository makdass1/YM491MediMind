using Microsoft.Extensions.Configuration;
using System.Text.Json;
using System.Text;

namespace App.Service.Services
{
    public class KeycloakAdminService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public KeycloakAdminService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<string> GetAdminToken()
        {
            var data = new Dictionary<string, string>
            {
                ["client_id"] = "admin-api-client",
                ["client_secret"] = _configuration["Keycloak:ClientSecret"],
                ["grant_type"] = "client_credentials"
            };

            var response = await _httpClient.PostAsync(
                $"{_configuration["Keycloak:BaseUrl"]}/realms/{_configuration["Keycloak:Realm"]}/protocol/openid-connect/token",
                new FormUrlEncodedContent(data)
            );

            var json = await response.Content.ReadAsStringAsync();
            return JsonDocument.Parse(json).RootElement.GetProperty("access_token").GetString();
        }

        public async Task CreateUserAsync(object payload)
        {
            var token = await GetAdminToken();

            var request = new HttpRequestMessage(
                HttpMethod.Post,
                $"{_configuration["Keycloak:BaseUrl"]}/admin/realms/{_configuration["Keycloak:Realm"]}/users"
            );

            request.Headers.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            request.Content = new StringContent(
                JsonSerializer.Serialize(payload),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
                throw new Exception("Keycloak user creation failed");
        }
    }
}