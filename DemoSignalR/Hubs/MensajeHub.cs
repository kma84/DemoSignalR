using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoSignalR.Hubs
{
    public class MensajeHub : Hub
    {

        private static int usuariosConectados;

        public override Task OnConnectedAsync()
        {
            usuariosConectados++;
            return Clients.All.SendAsync("usuario-conectado", usuariosConectados);
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            usuariosConectados--;
            return Clients.All.SendAsync("usuario-desconectado", usuariosConectados);
        }

        public Task EnviarMensaje(string mensaje)
        {
            return Clients.All.SendAsync("nuevo-mensaje", mensaje);
        }

    }
}
