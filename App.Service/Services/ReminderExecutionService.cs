using App.Service.Dtos;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace App.Service.Services
{
    public class ReminderExecutionService
    {
        private readonly IConfiguration _config;

        public ReminderExecutionService(IConfiguration config)
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

        public async Task RespondAsync(int executionId, bool isTaken)
        {
            using var conn = GetConnection();
            await conn.OpenAsync();

            var cmd = new SqlCommand(@"
                UPDATE ReminderExecutions
                SET 
                    IsTaken = @IsTaken,
                    TakenTime = @TakenTime,
                    ResponseTimeMinute = DATEDIFF(MINUTE, ScheduledTime, @TakenTime)
                WHERE Id = @Id
                  AND IsTaken IS NULL
            ", conn);

            DateTime now = DateTime.Now;

            cmd.Parameters.AddWithValue("@Id", executionId);
            cmd.Parameters.AddWithValue("@IsTaken", isTaken);
            cmd.Parameters.AddWithValue("@TakenTime", now);

            int affected = await cmd.ExecuteNonQueryAsync();

            if (affected == 0)
                throw new Exception("Bu bildirim zaten cevaplanmış veya bulunamadı.");
        }

        public async Task<List<ReminderExecutionReportDto>> GetReportByUserIdAsync(int userId)
        {
            var list = new List<ReminderExecutionReportDto>();

            using var conn = GetConnection();
            await conn.OpenAsync();

            var cmd = new SqlCommand(@"
        SELECT 
            re.Id,
            r.Id AS ReminderId,
            m.Name AS MedicineName,
            re.ScheduledTime,
            re.IsTaken
        FROM ReminderExecutions re
        INNER JOIN Reminders r ON r.Id = re.ReminderId
        INNER JOIN Medicines m ON m.Id = r.MedicineId
        WHERE r.UserId = @UserId
        ORDER BY re.ScheduledTime DESC
    ", conn);

            cmd.Parameters.AddWithValue("@UserId", userId);

            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                bool? isTaken = reader.IsDBNull(4)
                    ? (bool?)null
                    : reader.GetBoolean(4);

                list.Add(new ReminderExecutionReportDto
                {
                    ExecutionId = reader.GetInt32(0),
                    ReminderId = reader.GetInt32(1),
                    MedicineName = reader.GetString(2),
                    ScheduledTime = reader.GetDateTime(3),
                    IsTaken = isTaken,
                    StatusText = isTaken == null
                        ? "Cevap Yok"
                        : isTaken.Value
                            ? "İçti"
                            : "İçmedi"
                });
            }

            return list;
        }
    }
}
