using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Repository.Entities
{
    public class Reminder: BaseEntity<int>
    {
        public DateTime CreatedTime { get; set; }
        public bool IsTaked { get; set; }
        public string Dosage { get; set; } = default!;
        public DateTime Start_date { get; set; }
        public DateTime Finish_date { get; set; }
        public Medicine Medicine { get; set; }= default!;
        public int MedicineId { get; set; }
        public Frequency_of_use Frequency_of_use { get; set; } = default!;
        public int Frequency_of_useId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = default!;
        public string Note { get; set; } = default!;
    }
}
