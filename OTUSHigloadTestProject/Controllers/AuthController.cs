using Microsoft.AspNetCore.Mvc;
using OTUSHigloadTestProject.Models.Requests;
using OTUSHigloadTestProject.Models.Responses;
using OTUSHigloadTestProject.Services.Abstract;

namespace OTUSHigloadTestProject.Controllers
{
    public class AuthController : ResultController
    {
        private readonly IUserIdentityService _userIdentityService;
        public AuthController(IUserIdentityService userIdentityService)
        {
            _userIdentityService = userIdentityService;
        }
        /// <remarks>
        /// Упрощенный процесс аутентификации путем передачи идентификатор пользователя и получения токена для дальнейшего прохождения авторизации
        /// </remarks>
        /// <returns>Успешная аутентификация</returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            string token;
            try
            {
                token = await _userIdentityService.LoginAsync(loginRequest);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message ?? "Неизвестная ошибка");
            }
            return Ok(new LoginResponse() { Token = token });
        }
    }
}
