
namespace OTUSControllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using OTUSHigloadTestProject.Controllers;
    using OTUSHigloadTestProject.Models.Database;
    using OTUSHigloadTestProject.Models.Requests;
    using OTUSHigloadTestProject.Services.Abstract;
    using System = global::System;

    public class UserController : ResultController
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <remarks>
        /// Регистрация нового пользователя
        /// </remarks>
        /// <returns>Успешная регистрация</returns>
        [HttpPost("user/register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterRequest body)
        {
            Guid newUserId;
            try
            {
                newUserId = await _userService.RegisterAsync(body);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message ?? "Неизвестная ошибка");
            }
            return Ok(new { Id = newUserId });
        }

        /// <remarks>
        /// Получение анкеты пользователя
        /// </remarks>
        /// <param name="id">Идентификатор пользователя</param>
        /// <returns>Успешное получение анкеты пользователя</returns>
        [Authorize]
        [HttpGet, Route("user/get/{id}", Name = "get")]
        public Task<User> Get(string id)
        {
            return _userService.GetByIdAsync(id);
        }

        /// <remarks>
        /// Поиск анкет
        /// </remarks>
        /// <param name="first_name">Условие поиска по имени</param>
        /// <param name="last_name">Условие поиска по фамилии</param>
        /// <returns>Успешные поиск пользователя</returns>
        [HttpGet, Route("user/search", Name = "search")]
        public Task<System.Collections.Generic.ICollection<User>> Search([Microsoft.AspNetCore.Mvc.FromQuery] string first_name, [Microsoft.AspNetCore.Mvc.FromQuery] string last_name)
        {

            return _userService.SearchAsync(first_name, last_name);
        }

    }


    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Response2
    {
        [Newtonsoft.Json.JsonProperty("user_id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string User_id { get; set; }

        private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

        [Newtonsoft.Json.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }


}

#pragma warning restore 1591
#pragma warning restore 1573
#pragma warning restore 472
#pragma warning restore 114
#pragma warning restore 108
#pragma warning restore 3016
#pragma warning restore 8603