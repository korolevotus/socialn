using OTUSControllers;
using OTUSHigloadTestProject.Models.Requests;

namespace OTUSHigloadTestProject.Services.Abstract
{
    public interface IUserService
    {

        /// <remarks>
        /// Регистрация нового пользователя
        /// </remarks>

        /// <returns>Успешная регистрация</returns>

        Task<Response2> RegisterAsync(Body2 body);

        /// <remarks>
        /// Получение анкеты пользователя
        /// </remarks>

        /// <param name="id">Идентификатор пользователя</param>

        /// <returns>Успешное получение анкеты пользователя</returns>

        Task<User> GetAsync(string id);

        /// <remarks>
        /// Поиск анкет
        /// </remarks>

        /// <param name="first_name">Условие поиска по имени</param>

        /// <param name="last_name">Условие поиска по фамилии</param>

        /// <returns>Успешные поиск пользователя</returns>

        Task<ICollection<User>> SearchAsync(string first_name, string last_name);

    }
}
