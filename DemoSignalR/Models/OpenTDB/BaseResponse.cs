using Newtonsoft.Json;

namespace DemoSignalR.Models.OpenTDB
{
    public class BaseResponse
    {
        [JsonProperty("response_code")]
        public int ResponseCode { get; set; }
    }
}
