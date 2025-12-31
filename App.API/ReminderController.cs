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
    }
}
