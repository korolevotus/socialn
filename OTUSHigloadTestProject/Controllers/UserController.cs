
namespace OTUSControllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using OTUSHigloadTestProject.Controllers;
    using OTUSHigloadTestProject.Models.Database;
    using OTUSHigloadTestProject.Models.Requests;
    using OTUSHigloadTestProject.Services.Abstract;
    using System = global::System;
    using OTUSHigloadTestProject.DTO;

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
        public async Task<IActionResult> RegisterAsync([FromBody] UserRegisterRequest body)
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
        //[Authorize]
        [HttpGet("user/get/{id}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            UserFormDto? userForm;
            try
            {
                userForm = await _userService.GetByIdAsync(id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message ?? "Неизвестная ошибка");
            }
            return Ok(new { userForm });

        }

        /// <remarks>
        /// Поиск анкет
        /// </remarks>
        /// <param name="first_name">Условие поиска по имени</param>
        /// <param name="last_name">Условие поиска по фамилии</param>
        /// <returns>Успешные поиск пользователя</returns>
        [HttpGet, Route("user/search", Name = "search")]
        public async Task<IActionResult> SearchAsync([FromQuery] string firstName, [FromQuery] string lastName)
        {
            IEnumerable<UserFormDto> userForms;
            try
            {
                userForms = await _userService.SearchAsync(firstName, lastName);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message ?? "Неизвестная ошибка");
            }
            return Ok(new { total = userForms.Count(), users = userForms });
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
