using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Prt.Graphit.Identity.Common
{
    public class AuthorizationOptions
    {
        public const string ISSUER = "Prt.Graphit.IdentityServer.V1"; // издатель токена
        public const string AUDIENCE = "http://localhost:4200/"; // потребитель токена
        public const string KEY = "Graphit!_777@Prt.Graphit.KEY2020";   // ключ для шифрации
        public const int LIFETIME = 1140; // время жизни токена =  1140 минут

        public static SymmetricSecurityKey Create(string secret)
            => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
    }
}