using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Service.Dtos
{
    public class TokenResponse
    {
        public string access_token { get; set; } = null!;
        public int expires_in { get; set; }
        public string token_type { get; set; } = null!;
    }

}
