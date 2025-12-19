using App.Service.Dtos;
using System.Net.Http.Headers;
using System.Text.Json;
namespace App.Service.Services
{
    public class KeycloakAuthService
    {
        private readonly HttpClient _http;

        private const string Realm = "MediMind";
        private const string ClientId = "medimind-app";
        private const string ClientSecret = "SPwvSyGyncJUEfl47GyLMNtw2iEuu563";

        public KeycloakAuthService(HttpClient http)
        {
            _http = http;
        }

        public async Task<string> LoginAsync(string email, string password)
        {
            var form = new Dictionary<string, string>
            {
                ["grant_type"] = "password",
                ["client_id"] = ClientId,
                ["client_secret"] = ClientSecret, // client confidential ise KALACAK
                ["username"] = email,
                ["password"] = password
            };

            var response = await _http.PostAsync(
                $"http://localhost:8080/realms/{Realm}/protocol/openid-connect/token",
                new FormUrlEncodedContent(form)
            );

            var content = await response.Content.ReadAsStringAsync();

            // ❌ Başarısızsa GERÇEK KEYCLOAK HATASINI GÖSTER
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Login failed ({response.StatusCode}): {content}");
            }

            // ✅ Başarılıysa TOKEN JSON DÖNER
            return content;
        }




        public async Task<string> DoctorLoginAsync(string RegistrationNumber, string Password)
        {
            var form = new Dictionary<string, string>
            {
                ["grant_type"] = "password",
                ["client_id"] = ClientId,
                ["client_secret"] = ClientSecret, // client confidential ise KALACAK
                ["username"] = RegistrationNumber,
                ["password"] = Password
            };

            var response = await _http.PostAsync(
                $"http://localhost:8080/realms/{Realm}/protocol/openid-connect/token",
                new FormUrlEncodedContent(form)
            );

            var content = await response.Content.ReadAsStringAsync();

            // ❌ Başarısızsa GERÇEK KEYCLOAK HATASINI GÖSTER
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Login failed ({response.StatusCode}): {content}");
            }

            // ✅ Başarılıysa TOKEN JSON DÖNER
            return content;
        }

    }
}