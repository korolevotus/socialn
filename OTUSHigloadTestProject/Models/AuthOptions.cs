using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace OTUSHigloadTestProject.Models
{
    public class AuthOptions
    {
        public const string ISSUER = "MyAuthServer"; // издатель токена
        public const string AUDIENCE = "MyAuthClient"; // потребитель токена
        const string KEY = "5b165a1205b165a1205b165a12-1";   // ключ для шифрации
        public const int LIFETIME = 90; // время жизни токена - 1 минута
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
