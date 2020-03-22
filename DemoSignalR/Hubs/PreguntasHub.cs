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


        public async Task SiguientePregunta()
        {
            await Clients.All.SendAsync("siguiente-pregunta", await preguntasService.SiguientePregunta());
        }

    }
}
