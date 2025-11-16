using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Repository.Entities
{
    public class Frequency_of_use:BaseEntity<int>
    {
        public string Name { get; set; } = default!;
    }
}
