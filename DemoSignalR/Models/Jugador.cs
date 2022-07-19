using Newtonsoft.Json;

namespace DemoSignalR.Models
{
    public class Jugador
    {
        [JsonProperty("nombre")]
        public string Nombre { get; set; }

        [JsonProperty("preguntasAcertadas")]
        public int PreguntasAcertadas { get; set; }

        [JsonProperty("preguntasFalladas")]
        public int PreguntasFalladas { get; set; }

    }
}
