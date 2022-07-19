using DemoSignalR.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoSignalR.Services
{
    public class JugadoresService
    {

        private readonly List<Jugador> jugadores = new List<Jugador>();


        public bool TryAdd(string jugador)
        {
            if (jugadores.Any(j => j.Nombre == jugador))
                return false;

            jugadores.Add(new Jugador { Nombre = jugador });
            return true;
        }

        public Jugador[] ObtenerJugadores()
        {
            return jugadores.ToArray();
        }

        public void AñadirPuntuacion(string jugador, bool preguntaAcertada)
        {
            Jugador jugObj = jugadores.SingleOrDefault(j => j.Nombre == jugador);

            if (jugObj == null) 
                return;

            _ = preguntaAcertada ? jugObj.PreguntasAcertadas++ : jugObj.PreguntasFalladas++;
        }
    }
}
