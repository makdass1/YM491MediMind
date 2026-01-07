using App.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{
    [Route("api/reminderselectbyId")]
    [ApiController]
    public class ReminderSelectByUserId(ReminderService reminderService) : ControllerBase
    {
        private readonly ReminderService _reminderService = reminderService;

        [HttpGet("{userId}")]
    public async Task<IActionResult> GetRemindersBySpecificUserId(int userId)
    {
        try
        {

            var reminders = await _reminderService.GetRemindersByUserIdAsync(userId);


            return Ok(reminders);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}
}