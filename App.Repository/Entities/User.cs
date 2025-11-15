using App.Repository.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Repository.Entities
{
    public class User: BaseEntity<int>
    {
        public string Name { get; set; } = default!;
        public string LastName{ get; set; }=default!;
        public string Mail { get; set; } = default!;
        public string Password { get; set; } = default!;
        public int Age { get; set; }
        public bool Gender { get; set; }
        public ICollection<ChronicDiseasessEnum>? chronicDiseasesses { get; set; }
        public ICollection<MedicineEnum>? medicines { get; set; }
        public ICollection<Reminder>? reminders { get; set; }
        public ICollection<AllergyEnum>? allergies { get; set; }


    }
}
