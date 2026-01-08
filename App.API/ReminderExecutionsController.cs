using App.Service.Dtos;
using App.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace App.API.Controllers
{
    [ApiController]
    [Route("api/reminder-executions")]
   
    public class ReminderExecutionsController : ControllerBase
    {
        private readonly ReminderExecutionService _service;

        public ReminderExecutionsController(ReminderExecutionService service)
        {
            _service = service;
        }

        [HttpPost("respond")]
        public async Task<IActionResult> Respond(
            [FromBody] ReminderExecutionResponseRequest request)
        {
            try
            {
                await _service.RespondAsync(request.ExecutionId, request.IsTaken);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpGet("report/{userId}")]
        public async Task<IActionResult> GetReport(int userId)
        {
            try
            {
                var result = await _service.GetReportByUserIdAsync(userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

    }
}
