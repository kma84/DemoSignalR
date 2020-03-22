using DemoSignalR.Models.OpenTDB;
using DemoSignalR.Services;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace DemoSignalR.Hubs
{
    public class PreguntasHub : Hub
    {

        private readonly PreguntasService preguntasService;


        public PreguntasHub(PreguntasService preguntasService)
        {
            this.preguntasService = preguntasService;
        }


        public Task SiguientePregunta()
        {
            Pregunta siguientePregunta = preguntasService.SiguientePregunta().GetAwaiter().GetResult();
            return Clients.All.SendAsync("siguiente-pregunta", siguientePregunta);
        }

    }
}
