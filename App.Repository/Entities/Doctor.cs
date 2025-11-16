using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Repository.Entities
{
    public class Doctor : BaseEntity<int>
    {
        public string Name { get; set; } = default!;
        public string Surname { get; set; } = default!;
        public string Registiration_number{ get; set; } = default!;


    }
}
