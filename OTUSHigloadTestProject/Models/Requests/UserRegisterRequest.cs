using Newtonsoft.Json;

namespace OTUSHigloadTestProject.Models.Requests
{
    public partial class UserRegisterRequest
    {
        [JsonProperty("first_name", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string First_name { get; set; }

        [JsonProperty("second_name", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Second_name { get; set; }

        [JsonProperty("age", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public int Age { get; set; }

        [JsonProperty("biography", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Biography { get; set; }

        [JsonProperty("city", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string City { get; set; }

        [JsonProperty("password", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Password { get; set; }

        [JsonProperty("login", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Login { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }
}
