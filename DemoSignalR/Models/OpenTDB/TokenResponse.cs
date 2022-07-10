using Newtonsoft.Json;

namespace DemoSignalR.Models.OpenTDB
{
    public class TokenResponse : BaseResponse
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("response_message")]
        public string ResponseMessage { get; set; }
    }
}
