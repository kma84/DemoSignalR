﻿using DemoSignalR.Models;
using DemoSignalR.Services;
using Microsoft.AspNetCore.SignalR;
using System;
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

        public override Task OnDisconnectedAsync(Exception exception)
        {
            Jugador jugador = jugadoresService.GetByConnectionId(Context.ConnectionId);
            jugadoresService.EliminarJugador(jugador);

            return Clients.All.SendAsync("jugador-desconectado", jugador.Nombre);
        }

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
            if (jugadoresService.TryAdd(jugador, Context.ConnectionId))
            {
                await Clients.All.SendAsync("jugador-nuevo", jugador);
            }
        }


        public async Task ObtenerJugadores()
        {
            await Clients.Caller.SendAsync("jugadores", jugadoresService.ObtenerJugadores());
        }


        public async Task AñadirPuntuacion(string jugador, bool preguntaAcertada)
        {
            jugadoresService.AñadirPuntuacion(jugador, preguntaAcertada);
            await Clients.All.SendAsync("añadir-puntuacion", jugador, preguntaAcertada);
        }

    }
}
