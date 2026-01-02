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
        // App.Service.Services -> ReminderService.cs içi

        // App.Service.Services -> ReminderService.cs

        public async Task<int> CreateReminderAsync(CreateReminderRequest request, int userId)
        {
            using var conn = GetConnection();
            await conn.OpenAsync();

            DateTime now = DateTime.Now;
            DateTime firstNotificationTime;

            // KURAL: İlk bildirim StartDate'den 1 dakika sonra olsun.
            // Ancak eğer kullanıcı StartDate'i geçmiş bir tarih seçtiyse (örn: sabah seçti, akşam ekliyor),
            // bildirimi kaçırmasın diye "Şu an + 1 dk" yapıyoruz.
            if (request.StartDate > now)
            {
                firstNotificationTime = request.StartDate.AddMinutes(1);
            }
            else
            {
                firstNotificationTime = now.AddMinutes(1);
            }

            var cmd = new SqlCommand(@"
        INSERT INTO Reminders 
        (CreatedTime, IsTaked, Dosage, Start_date, Finish_date, MedicineId, Frequency_of_useId, UserId, Note, NextExecutionTime)
        VALUES 
        (@CreatedTime, @IsTaked, @Dosage, @StartDate, @FinishDate, @MedicineId, @FrequencyId, @UserId, @Note, @NextExecTime);
        SELECT CAST(SCOPE_IDENTITY() AS INT);
    ", conn);

            cmd.Parameters.AddWithValue("@CreatedTime", now);
            cmd.Parameters.AddWithValue("@IsTaked", false);
            cmd.Parameters.AddWithValue("@Dosage", request.Dosage);
            cmd.Parameters.AddWithValue("@StartDate", request.StartDate);
            cmd.Parameters.AddWithValue("@FinishDate", request.FinishDate);
            cmd.Parameters.AddWithValue("@MedicineId", request.MedicineId);
            cmd.Parameters.AddWithValue("@FrequencyId", request.FrequencyOfUseId);
            cmd.Parameters.AddWithValue("@UserId", userId);
            cmd.Parameters.AddWithValue("@Note", request.Note ?? (object)DBNull.Value);

            // 🔥 İlk tetikleyici zamanı burası
            cmd.Parameters.AddWithValue("@NextExecTime", firstNotificationTime);

            var reminderId = (int)await cmd.ExecuteScalarAsync();
            return reminderId;
        }


        public async Task<List<ReminderDto>> GetRemindersByUserIdAsync(int userId)
        {
            var list = new List<ReminderDto>();
            using var conn = GetConnection();
            await conn.OpenAsync();

            // Sadece o user'a ait verileri çekiyoruz (WHERE UserId = @UserId)
            var cmd = new SqlCommand(@"
                SELECT 
                    Id, 
                    CreatedTime, 
                    IsTaked, 
                    Dosage, 
                    Start_date, 
                    Finish_date, 
                    MedicineId, 
                    Frequency_of_useId, 
                    Note
                FROM Reminders
                WHERE UserId = @UserId
                ORDER BY CreatedTime DESC", conn); // En yeni eklenen en üstte gelsin

            cmd.Parameters.AddWithValue("@UserId", userId);

            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                list.Add(new ReminderDto
                {
                    Id = reader.GetInt32(0),
                    CreatedTime = reader.GetDateTime(1),
                    IsTaked = reader.GetBoolean(2),
                    Dosage = reader.GetString(3),
                    StartDate = reader.GetDateTime(4),
                    FinishDate = reader.GetDateTime(5),
                    MedicineId = reader.GetInt32(6),
                    FrequencyOfUseId = reader.GetInt32(7),
                    // Note kolonu NULL gelebilir, kontrol ediyoruz:
                    Note = reader.IsDBNull(8) ? null : reader.GetString(8)
                });
            }

            return list;
        }
    }
}
