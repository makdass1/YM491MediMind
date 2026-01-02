using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
namespace App.Service.Services
{
   

    public static class JwtHelper
    {
        public static Guid GetUserIdFromToken(string accessToken)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(accessToken);

            var sub = jwt.Claims.First(c => c.Type == "sub").Value;

            return Guid.Parse(sub);
        }
    }

}
