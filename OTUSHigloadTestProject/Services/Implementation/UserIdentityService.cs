using Microsoft.IdentityModel.Tokens;
using OTUSHigloadTestProject.Models;
using OTUSHigloadTestProject.Models.Requests;
using OTUSHigloadTestProject.Services.Abstract;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace OTUSHigloadTestProject.Services.Implementation
{
    public class UserIdentityService : IUserIdentityService
    {
        // тестовые данные вместо использования базы данных
        private List<UserIdentity> peoples = new List<UserIdentity>
        {
            new UserIdentity {Id="admin@gmail.com", Password="12345" },
            new UserIdentity { Id="qwerty@gmail.com", Password="55555" }
        };

        public async Task<string> LoginAsync(LoginRequest loginRequest)
        {
            var identity = GetIdentity(loginRequest.Id, loginRequest.Password);

            var now = DateTime.UtcNow;

            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return encodedJwt;
        }
        private ClaimsIdentity? GetIdentity(string username, string password)
        {
            var user = peoples.FirstOrDefault(x => x.Id == username && x.Password == password);

            if (user == null) throw new Exception("Неверный логин пользователя или пароль");

            var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Id)
                };

            ClaimsIdentity claimsIdentity =
            new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            return claimsIdentity;


        }
    }
}
