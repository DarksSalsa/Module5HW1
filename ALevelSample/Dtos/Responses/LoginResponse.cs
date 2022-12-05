using Newtonsoft.Json;

namespace ALevelSample.Dtos.Responses
{
    public class LoginResponse
    {
        [JsonProperty(PropertyName = "token")]
        public string Token { get; set; }
        [JsonProperty(PropertyName = "error")]
        public string Error { get; set; }
    }
}
