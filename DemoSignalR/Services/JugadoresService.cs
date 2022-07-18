using System;
using System.Collections.Generic;

namespace DemoSignalR.Services
{
    public class JugadoresService
    {

        private readonly List<string> jugadores = new List<string>();


        public bool TryAdd(string jugador)
        {
            if (jugadores.Contains(jugador))
                return false;

            jugadores.Add(jugador);
            return true;
        }

        public string[] ObtenerJugadores()
        {
            return jugadores.ToArray();
        }
    }
}
