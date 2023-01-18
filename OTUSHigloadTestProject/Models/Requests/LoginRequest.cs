using Newtonsoft.Json;

namespace OTUSHigloadTestProject.Models.Requests
{
    public class LoginRequest
    {
        [JsonProperty("login", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Login { get; set; }

        [JsonProperty("password", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Password { get; set; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }
    }
}
