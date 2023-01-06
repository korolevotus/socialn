
namespace OTUSControllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using OTUSHigloadTestProject.Services.Abstract;
    using System = global::System;

    public class UserController : ControllerBase
    {
        private IUserService _implementation;

        public UserController(IUserService implementation)
        {
            _implementation = implementation;
        }

        /// <remarks>
        /// Регистрация нового пользователя
        /// </remarks>
        /// <returns>Успешная регистрация</returns>
        [Authorize()]
        [HttpPost("user/register")]
        public async Task<Response2> Register([FromBody] Body2 body)
        {

            return await _implementation.RegisterAsync(body);
        }

        /// <remarks>
        /// Получение анкеты пользователя
        /// </remarks>
        /// <param name="id">Идентификатор пользователя</param>
        /// <returns>Успешное получение анкеты пользователя</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("user/get/{id}", Name = "get")]
        public System.Threading.Tasks.Task<User> Get(string id)
        {

            return _implementation.GetAsync(id);
        }

        /// <remarks>
        /// Поиск анкет
        /// </remarks>
        /// <param name="first_name">Условие поиска по имени</param>
        /// <param name="last_name">Условие поиска по фамилии</param>
        /// <returns>Успешные поиск пользователя</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("user/search", Name = "search")]
        public System.Threading.Tasks.Task<System.Collections.Generic.ICollection<User>> Search([Microsoft.AspNetCore.Mvc.FromQuery] string first_name, [Microsoft.AspNetCore.Mvc.FromQuery] string last_name)
        {

            return _implementation.SearchAsync(first_name, last_name);
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class User
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Id { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        [Newtonsoft.Json.JsonProperty("first_name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string First_name { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        [Newtonsoft.Json.JsonProperty("second_name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Second_name { get; set; }

        /// <summary>
        /// Возраст
        /// </summary>
        [Newtonsoft.Json.JsonProperty("age", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Age { get; set; }

        /// <summary>
        /// Интересы
        /// </summary>
        [Newtonsoft.Json.JsonProperty("biography", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Biography { get; set; }

        /// <summary>
        /// Город
        /// </summary>
        [Newtonsoft.Json.JsonProperty("city", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string City { get; set; }

        private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

        [Newtonsoft.Json.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }


    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Body2
    {
        [Newtonsoft.Json.JsonProperty("first_name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string First_name { get; set; }

        [Newtonsoft.Json.JsonProperty("second_name", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Second_name { get; set; }

        [Newtonsoft.Json.JsonProperty("age", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Age { get; set; }

        [Newtonsoft.Json.JsonProperty("biography", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Biography { get; set; }

        [Newtonsoft.Json.JsonProperty("city", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string City { get; set; }

        [Newtonsoft.Json.JsonProperty("password", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Password { get; set; }

        private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

        [Newtonsoft.Json.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
            set { _additionalProperties = value; }
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