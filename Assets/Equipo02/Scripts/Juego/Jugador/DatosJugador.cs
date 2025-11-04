using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Juego.Jugador
{
    internal static class DatosJugador
    {
        public static int Puntos { get; set; } = 0;

        public static void RecetiarPuntos()
        {
            Puntos = 0;
        }
    }
}
