using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Service.Dtos
{
    public record DoctorInputDto(string Name, string Surname, string Registiration_number, string Password);
    public record DoctorOutputDto( string Name, string Surname, string Registiration_number);


}
