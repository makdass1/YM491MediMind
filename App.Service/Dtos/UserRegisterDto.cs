using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Service.Dtos
{
    public class UserRegisterRequest
    {
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Mail { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
