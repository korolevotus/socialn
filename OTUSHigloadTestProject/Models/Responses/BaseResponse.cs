using Newtonsoft.Json;

namespace OTUSHigloadTestProject.Models.Responses
{
    public class BaseResponse<T>
    {
        /// <summary>
        /// Указание, был ли запрос выполнен успешно
        /// </summary>
        [JsonProperty(PropertyName = "success")]
        public bool Success { get; }

        /// <summary>
        /// Полезные данные
        /// </summary>
        [JsonProperty(PropertyName = "payload")]
        public T Payload { get; }

        public BaseResponse(bool success, T payload)
        {
            Success = success;
            Payload = payload;
        }
    }
}
