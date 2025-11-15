using App.Repository.Enums;
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
        public MedicineEnum MedicineEnum { get; set; }= default!;
        public Frequency_of_useEnum Frequency_of_useEnum { get; set; } = default!;
        public string Note { get; set; } = default!;
    }
}
