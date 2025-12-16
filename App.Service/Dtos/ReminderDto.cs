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
}
