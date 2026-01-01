using App.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Service.Dtos
{
    public record ReminderCreateInputModel(bool IsTaked, string Dosage , DateTime Start_date, DateTime Finish_date, Medicine Medicine, Frequency_of_use Frequency_of_use, User User, string Note);
    public record ReminderCreateOutputModel(int Id, string Dosage);
    public record ReminderListOutputModel(int Id, string Dosage, DateTime Start_date, DateTime Finish_dateMedicine, Medicine Medicine, Frequency_of_use Frequency_of_use, User User, string Note);

    public class CreateReminderRequest
    {
              
              
        public string Dosage { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public int MedicineId { get; set; }
        public int FrequencyOfUseId { get; set; }
        public string? Note { get; set; }
    }
    public class ReminderDto
    {
        public int Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public bool IsTaked { get; set; }
        public string Dosage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public int MedicineId { get; set; }
        public int FrequencyOfUseId { get; set; }
        public string Note { get; set; }
    }
}
