//using App.Service.Dtos;
//using MediatR;
//using Newtonsoft.Json;
//using System.Net.Http.Headers;
//using System.Text;

//public class DoctorRegisterCommandHandler
//    : IRequestHandler<DoctorRegisterCommand, DoctorOutputDto>
//{
//    private readonly HttpClient _http;

//    public DoctorRegisterCommandHandler(IHttpClientFactory factory)
//    {
//        _http = factory.CreateClient();
//    }

//    public async Task<DoctorOutputDto> Handle(DoctorRegisterCommand request,
//        CancellationToken cancellationToken)
//    {
//        // 1) Admin Token al
//        var tokenRequest = new HttpRequestMessage(HttpMethod.Post,
//            "http://localhost:8080/realms/master/protocol/openid-connect/token");

//        tokenRequest.Content = new FormUrlEncodedContent(new Dictionary<string, string>
//        {
//            {"client_id", "admin-cli"},
//            {"grant_type", "password"},
//            {"username", "admin"},
//            {"password", "admin"}
//        });

//        var tokenResponse = await _http.SendAsync(tokenRequest, cancellationToken);
//        var tokenResult = JsonConvert.DeserializeObject<dynamic>(await tokenResponse.Content.ReadAsStringAsync());
//        string accessToken = tokenResult.access_token;

//        // Token header
//        _http.DefaultRequestHeaders.Authorization =
//            new AuthenticationHeaderValue("Bearer", accessToken);

//        // 2) Keycloak user oluştur
//        var keycloakUserBody = new
//        {
//            username = request.Registration_number,
//            firstName = request.Name,
//            lastName = request.Surname,
//            enabled = true,
//            credentials = new[]
//            {
//                new {
//                    type = "password",
//                    value = request.Password,
//                    temporary = false
//                }
//            }
//        };

//        var createUserResponse = await _http.PostAsync(
//            "http://localhost:8080/admin/realms/your_realm/users",
//            new StringContent(JsonConvert.SerializeObject(keycloakUserBody), Encoding.UTF8, "application/json"));

//        if (!createUserResponse.IsSuccessStatusCode)
//            throw new Exception("Keycloak user create failed");

//        // Keycloak kullanıcı ID çekme
//        string location = createUserResponse.Headers.Location.ToString();
//        string userId = location.Split('/').Last();

//        // 3) Rol ID’yi çek
//        var roleResponse = await _http.GetAsync(
//            "http://localhost:8080/admin/realms/your_realm/roles/doctor");
//        var roleData = JsonConvert.DeserializeObject<dynamic>(
//            await roleResponse.Content.ReadAsStringAsync());

//        // 4) Kullanıcıya rol atama
//        await _http.PostAsync(
//            $"http://localhost:8080/admin/realms/your_realm/users/{userId}/role-mappings/realm",
//            new StringContent(JsonConvert.SerializeObject(new[]
//            {
//                new {
//                    id = roleData.id.ToString(),
//                    name = "doctor"
//                }
//            }), Encoding.UTF8, "application/json"));

//        // 5) API Output
//        //return new DoctorOutputModel
//        //{
//        //    Name = request.Name,
//        //    Surname = request.Surname,
//        //    RegistrationNumber = request.Registration_number
//        //};
//    }
//}
