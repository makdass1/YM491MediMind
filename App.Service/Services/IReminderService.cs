using App.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Service.Services
{
    public interface IReminderService
    {
        Task<ServiceResult<ReminderCreateOutputModel>> GetCurrencyByIdAsync(int id);
        Task<ServiceResult<List<ReminderListOutputModel>>> GetAllCurrenciesAsync();
        Task<ServiceResult<ReminderCreateOutputModel>> CreateCurrencyAsync(ReminderCreateInputModel dto);
        Task<ServiceResult<string>> UpdateCurrencyRatesFromApiAsync();
    }
}
