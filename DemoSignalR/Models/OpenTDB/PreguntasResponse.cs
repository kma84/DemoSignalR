using Newtonsoft.Json;
using System.Collections.Generic;

namespace DemoSignalR.Models.OpenTDB
{
    public class PreguntasResponse : BaseResponse
    {
        [JsonProperty("results")]
        public List<Pregunta> Results { get; set; }
    }
}
