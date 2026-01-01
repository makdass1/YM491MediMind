using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using App.Service.Dtos; // DTO'nun olduğu yeri ekle

namespace App.Service.Services
{
    public class ReminderNotificationWorker : BackgroundService
    {
        private readonly IConfiguration _config;

        public ReminderNotificationWorker(IConfiguration config)
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

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    await CheckAndSendNotifications();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Worker Error: {ex.Message}");
                }

                // 1 Dakika bekle
                await Task.Delay(60000, stoppingToken);
            }
        }

        private async Task CheckAndSendNotifications()
        {
            var tasks = new List<NotificationTaskDto>();
            DateTime currentTime = DateTime.Now;

            using (var conn = GetConnection())
            {
                await conn.OpenAsync();

                // Bildirim zamanı gelmiş (veya geçmiş) olanları al
                var cmd = new SqlCommand(@"
                    SELECT 
                        Id, 
                        UserId, 
                        Note, 
                        Frequency_of_useId, 
                        NextExecutionTime 
                    FROM Reminders
                    WHERE NextExecutionTime IS NOT NULL 
                      AND NextExecutionTime <= @CurrentTime 
                      AND Finish_date > @CurrentTime", conn);

                cmd.Parameters.AddWithValue("@CurrentTime", currentTime);

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        tasks.Add(new NotificationTaskDto
                        {
                            ReminderId = reader.GetInt32(0),
                            UserId = reader.GetInt32(1),
                            Note = reader.IsDBNull(2) ? "" : reader.GetString(2),
                            FrequencyId = reader.GetInt32(3),
                            ScheduledTime = reader.GetDateTime(4) // Veritabanındaki "Planlanan Saat"
                        });
                    }
                }
            }

            foreach (var task in tasks)
            {
                // 1. Bildirimi Gönder
                Console.WriteLine($"[BİLDİRİM] User: {task.UserId} - Vakit: {task.ScheduledTime}");

                // 2. Bir Sonraki Saati Hesapla
                // ÖNEMLİ: task.ScheduledTime'ı gönderiyoruz, DateTime.Now'ı DEĞİL.
                DateTime? nextTime = CalculateNextTime(task.ScheduledTime, task.FrequencyId);

                // 3. DB'yi Güncelle
                await UpdateNextTimeInDb(task.ReminderId, nextTime);
            }
        }

        // 🔥 SAAT KAYMASINI ENGELLEYEN VE ARALIKLARI AYARLAYAN MANTIK
        private DateTime? CalculateNextTime(DateTime lastScheduledTime, int frequencyId)
        {
            // Hesaplamayı en son PLANLANAN saat üzerinden yapıyoruz.
            // Böylece bildirim 5 dakika geç gitse bile, bir sonraki bildirim 
            // orijinal saatine sadık kalır.

            DateTime baseTime = lastScheduledTime;

            switch (frequencyId)
            {
                case 1: // Günde 1 kez -> Tam 24 saat sonra (Her gün aynı saat)
                    return baseTime.AddDays(1);

                case 2: // Günde 2 kez -> Tam 12 saat sonra
                    return baseTime.AddHours(12);

                case 3: // Günde 3 kez -> Tam 8 saat sonra
                    return baseTime.AddHours(8);

                case 4: // Haftada 1 kez -> Tam 7 gün sonra (Aynı gün aynı saat)
                    return baseTime.AddDays(7);

                case 5: // Haftada 2 kez -> (Örneğin Pzt ve Perşembe mantığı zordur, şimdilik 3.5 gün ekliyoruz)
                    return baseTime.AddHours(84);

                case 6: // Ayda 1 kez -> Tam 1 ay sonra (Ayın aynı günü)
                    return baseTime.AddMonths(1);

                case 7: // İhtiyaç halinde -> Tekrarlama yok
                    return null;

                default:
                    return baseTime.AddDays(1);
            }
        }

        private async Task UpdateNextTimeInDb(int reminderId, DateTime? nextTime)
        {
            using var conn = GetConnection();
            await conn.OpenAsync();

            string sql = "UPDATE Reminders SET NextExecutionTime = @NextTime WHERE Id = @Id";

            var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", reminderId);
            cmd.Parameters.AddWithValue("@NextTime", nextTime.HasValue ? (object)nextTime.Value : DBNull.Value);

            await cmd.ExecuteNonQueryAsync();
        }
    }


public class NotificationTaskDto
    {
        public int ReminderId { get; set; }
        public int UserId { get; set; }
        public string Note { get; set; }
        public int FrequencyId { get; set; }
        public DateTime ScheduledTime { get; set; }
    }
}