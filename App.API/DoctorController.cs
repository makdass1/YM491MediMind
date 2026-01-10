using App.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly ParalelDbService _dbService;

        public DoctorsController(ParalelDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet("getDoctor/{id}")]
        public async Task<IActionResult> GetDoctor(int id)
        {
            var doctor = await _dbService.GetDoctorByIdAsync(id);
            return Ok(doctor);
        }
    }

}
