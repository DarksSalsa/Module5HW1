using Newtonsoft.Json;

namespace ALevelSample.Dtos.Responses
{
    public class RegisterResponse
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "token")]
        public string Token { get; set; }
        [JsonProperty(PropertyName = "error")]
        public string Error { get; set; }
    }
}
