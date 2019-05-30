using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_backend.Options
{
    public class AuthOptions
    {
        public const string Issuer = "TokenIssuer"; // издатель токена
        public const string Audience = "http://localhost:5000/"; // потребитель токена
        public const string Key = "fdkjfhkerjwoewkddkvbdfkw";
        public const int Lifetime = 60;

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
        }
    }
}
