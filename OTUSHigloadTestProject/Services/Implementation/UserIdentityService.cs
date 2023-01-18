using Microsoft.IdentityModel.Tokens;
using OTUSHigloadTestProject.Helpers;
using OTUSHigloadTestProject.Models;
using OTUSHigloadTestProject.Models.Requests;
using OTUSHigloadTestProject.Services.Abstract;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace OTUSHigloadTestProject.Services.Implementation
{
    public class UserIdentityService : IUserIdentityService
    {
        private List<UserIdentity> peoples = new List<UserIdentity>
        {
            new UserIdentity {Id="admin@gmail.com", Password="kcOk0oEftxdpPvXzIzJ4PMO0ogCWZ3vFijoDJ5wSXik=",Salt="C+d+Opq9bXRQc9Dy+aCe3g==" },
            new UserIdentity { Id="qwerty@gmail.com", Password="55555",Salt="123" }
        };

        private readonly IUserService _userService;

        public UserIdentityService(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<string> LoginAsync(LoginRequest loginRequest)
        {
            var identity = await GetIdentityAsync(loginRequest.Login, loginRequest.Password);

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
        private async Task<ClaimsIdentity?> GetIdentityAsync(string username, string password)
        {
            var user = await _userService.GetByLoginAsync(username);

            if (user == null) throw new Exception("Неверный логин пользователя или пароль");

            var passwordHash = PasswordHasher.ComputeHash(password, user.Salt);

            if (user.Password != passwordHash)
                throw new Exception("Неверный логин пользователя или пароль");

            var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login)
                };

            ClaimsIdentity claimsIdentity =
            new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            return claimsIdentity;


        }
    }
}
