using App.API.Extensions;
using App.Service.Dtos;
using App.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace App.API.Controllers
{
    [ApiController]
    [Route("api/reminders")]
    [Authorize] // JWT ZORUNLU
    public class ReminderController : ControllerBase
    {
        private readonly ReminderService _reminderService;

        public ReminderController(ReminderService reminderService)
        {
            _reminderService = reminderService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateReminder([FromBody] CreateReminderRequest request)
        {
            // 🔥 Keycloak JWT'den GUID al
            var keycloakUserId = User.GetKeycloakUserId();

            // 🔥 DB'deki int UserId'yi bul
            int userId;
            try
            {
                userId = await _reminderService.GetUserIdFromKeycloakIdAsync(keycloakUserId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            // 🔥 Reminder oluştur
            var reminderId = await _reminderService.CreateReminderAsync(request, userId);

            // 🔥 Response
            return Ok(new
            {
                ReminderId = reminderId,
                UserId = userId
            });
        }



        // ... (CreateReminder metodu yukarıda) ...

        [HttpGet]
        public async Task<IActionResult> GetMyReminders()
        {
            // 1. Token'dan Keycloak ID'yi al
            var keycloakUserId = User.GetKeycloakUserId();

            try
            {
                // 2. DB'deki gerçek User ID'yi bul
                int userId = await _reminderService.GetUserIdFromKeycloakIdAsync(keycloakUserId);

                // 3. Kullanıcıya ait hatırlatıcıları getir
                var reminders = await _reminderService.GetRemindersByUserIdAsync(userId);

                return Ok(reminders);
            }
            catch (Exception ex)
            {
                // Kullanıcı bulunamazsa veya SQL hatası olursa 400 dön
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
