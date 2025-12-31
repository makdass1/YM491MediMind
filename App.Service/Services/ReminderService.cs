using App.Service.Dtos;
using App.Repository.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace App.Service.Services
{
    public class ReminderService
    {
        private readonly IConfiguration _config;

        public ReminderService(IConfiguration config)
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

        /// <summary>
        /// Keycloak GUID -> DB'deki int UserId
        /// </summary>
        public async Task<int> GetUserIdFromKeycloakIdAsync(Guid keycloakUserId)
        {
            using var conn = GetConnection();
            await conn.OpenAsync();

            var cmd = new SqlCommand(@"
                SELECT Id FROM Users WHERE KeycloakUserId = @KeycloakId
            ", conn);
            cmd.Parameters.AddWithValue("@KeycloakId", keycloakUserId);

            var result = await cmd.ExecuteScalarAsync();
            if (result == null)
                throw new Exception("Keycloak kullanıcısına karşılık gelen User bulunamadı");

            return Convert.ToInt32(result);
        }

        /// <summary>
        /// Yeni bir reminder oluşturur ve Id döner
        /// </summary>
        public async Task<int> CreateReminderAsync(CreateReminderRequest request, int userId)
        {
            using var conn = GetConnection();
            await conn.OpenAsync();

            var cmd = new SqlCommand(@"
                INSERT INTO Reminders 
                (CreatedTime, IsTaked, Dosage, Start_date, Finish_date, MedicineId, Frequency_of_useId, UserId, Note)
                VALUES 
                (@CreatedTime, @IsTaked, @Dosage, @StartDate, @FinishDate, @MedicineId, @FrequencyId, @UserId, @Note);
                SELECT CAST(SCOPE_IDENTITY() AS INT);
            ", conn);

            cmd.Parameters.AddWithValue("@CreatedTime", DateTime.UtcNow);
            cmd.Parameters.AddWithValue("@IsTaked", false);
            cmd.Parameters.AddWithValue("@Dosage", request.Dosage);
            cmd.Parameters.AddWithValue("@StartDate", request.StartDate);
            cmd.Parameters.AddWithValue("@FinishDate", request.FinishDate);
            cmd.Parameters.AddWithValue("@MedicineId", request.MedicineId);
            cmd.Parameters.AddWithValue("@FrequencyId", request.FrequencyOfUseId);
            cmd.Parameters.AddWithValue("@UserId", userId);
            cmd.Parameters.AddWithValue("@Note", request.Note ?? (object)DBNull.Value);

            var reminderId = (int)await cmd.ExecuteScalarAsync();
            return reminderId;
        }
    }
}
