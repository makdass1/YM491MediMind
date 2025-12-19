using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Service.Dtos
{
    public class RegisterRequest
    {
        public string Role { get; set; } = default!; // "doctor" | "user"

        // Ortak
        public string Password { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Surname { get; set; } = default!;

        // USER için
        public string Email { get; set; } 

        // DOCTOR için
        public string RegistrationNumber { get; set; } 
    }

    public class UserLoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class DoctorLoginRequest
    {
        public string RegistrationNumber { get; set; }
        public string Password { get; set; }
    }


}
