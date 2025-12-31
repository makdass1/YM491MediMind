using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using App.Service.Dtos;

namespace App.Service.Services
{
    public class ParalelDbService
    {
        private readonly IConfiguration _config;

        public ParalelDbService(IConfiguration config)
        {
            _config = config;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(
                _config.GetConnectionString("DefaultConnection")
                ?? _config.GetConnectionString("SqlServer")
            );
        }

        public async Task SaveUserAsync(Guid keycloakUserId, RegisterRequest request)
        {
            using var conn = GetConnection();
            await conn.OpenAsync();

            var cmd = new SqlCommand(@"
        INSERT INTO Users (KeycloakUserId, Name, LastName, Mail)
        VALUES (@KeycloakUserId, @Name, @LastName, @Mail)
    ", conn);

            cmd.Parameters.Add("@KeycloakUserId", System.Data.SqlDbType.UniqueIdentifier)
                          .Value = keycloakUserId;

            cmd.Parameters.AddWithValue("@Name", request.Name);
            cmd.Parameters.AddWithValue("@LastName", request.Surname);
            cmd.Parameters.AddWithValue("@Mail", request.Email);

            await cmd.ExecuteNonQueryAsync();
        }



        public async Task SaveDoctorAsync(Guid keycloakUserId, RegisterRequest request)
        {
            using var conn = GetConnection();
            await conn.OpenAsync();

            var cmd = new SqlCommand(@"
        INSERT INTO Doctors (KeycloakUserId, Name, Surname, Registiration_number)
        VALUES (@KeycloakUserId, @Name, @Surname, @RegNo)
    ", conn);

            cmd.Parameters.Add("@KeycloakUserId", System.Data.SqlDbType.UniqueIdentifier)
                          .Value = keycloakUserId;

            cmd.Parameters.AddWithValue("@Name", request.Name);
            cmd.Parameters.AddWithValue("@Surname", request.Surname);
            cmd.Parameters.AddWithValue("@RegNo", request.RegistrationNumber!);

            await cmd.ExecuteNonQueryAsync();
        }

        public async Task<int> GetUserIdByKeycloakIdAsync(Guid keycloakUserId)
        {
            using var conn = GetConnection();
            await conn.OpenAsync();

            var cmd = new SqlCommand(@"
        SELECT Id 
        FROM Users 
        WHERE KeycloakUserId = @KeycloakId
    ", conn);

            cmd.Parameters.AddWithValue("@KeycloakId", keycloakUserId);

            var result = await cmd.ExecuteScalarAsync();

            if (result == null)
                throw new Exception("User not found in local DB");

            return (int)result;
        }

    }
}
