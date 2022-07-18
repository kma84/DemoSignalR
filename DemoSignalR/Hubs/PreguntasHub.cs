using DemoSignalR.Services;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoSignalR.Hubs
{
    public class PreguntasHub : Hub
    {

        private readonly PreguntasService preguntasService;
        private readonly JugadoresService jugadoresService;


        //public override Task OnConnectedAsync()
        //{
        //    usuariosConectados++;
        //    return Clients.All.SendAsync("usuario-conectado", usuariosConectados);
        //}

        //public override Task OnDisconnectedAsync(Exception exception)
        //{
        //    usuariosConectados--;
        //    return Clients.All.SendAsync("usuario-desconectado", usuariosConectados);
        //}

        public PreguntasHub(PreguntasService preguntasService, JugadoresService jugadoresService)
        {
            this.preguntasService = preguntasService;
            this.jugadoresService = jugadoresService;
        }


        public async Task SiguientePregunta()
        {
            await Clients.Caller.SendAsync("siguiente-pregunta", await preguntasService.SiguientePregunta(Context.ConnectionId));
        }


        public async Task JugadorNuevo(string jugador)
        {
            if (jugadoresService.TryAdd(jugador))
            {
                await Clients.All.SendAsync("jugador-nuevo", jugador);
            }
        }


        public async Task ObtenerJugadores()
        {
            await Clients.Caller.SendAsync("jugadores", jugadoresService.ObtenerJugadores());
        }

    }
}
