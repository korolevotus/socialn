using OTUSHigloadTestProject.Models.Requests;

namespace OTUSHigloadTestProject.Services.Abstract
{
    public interface IUserIdentityService
    {
        /// <remarks>
        /// Процесс аутентификации путем передачи идентификатор пользователя и получения токена для дальнейшего прохождения авторизации
        /// </remarks>
        /// <returns>Успешная аутентификация</returns>
        Task<string> LoginAsync(LoginRequest loginRequest);
    }
}
