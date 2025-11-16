using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Repository.Entities
{
    public class Medicine:BaseEntity<int>
    {   
        public string Name { get; set; } = default!;
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
