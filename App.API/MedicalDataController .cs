using App.Service.Dtos;
using App.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace App.API.Controllers
{
    [ApiController]
    [Route("api/medical-data")]
    [Authorize] // İsteğe bağlı: Token zorunlu olsun diye
    public class MedicalDataController : ControllerBase
    {
        private readonly MedicalDataService _medicalDataService;

        public MedicalDataController(MedicalDataService medicalDataService)
        {
            _medicalDataService = medicalDataService;
        }

        // Endpoint: api/medical-data/medicines
        [HttpGet("medicines")]
        public async Task<IActionResult> GetMedicines()
        {
            try
            {
                var result = await _medicalDataService.GetMedicinesAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Endpoint: api/medical-data/frequencies
        [HttpGet("frequencies")]
        public async Task<IActionResult> GetFrequencies()
        {
            try
            {
                var result = await _medicalDataService.GetFrequenciesAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Endpoint: api/medical-data/allergies
        [HttpGet("allergies")]
        public async Task<IActionResult> GetAllergies()
        {
            try
            {
                var result = await _medicalDataService.GetAllergiesAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Endpoint: api/medical-data/user-allergies
        [HttpGet("user-allergies")]
        public async Task<IActionResult> GetUserAllergies()
        {
            try
            {
                var result = await _medicalDataService.GetUserAllergiesAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}