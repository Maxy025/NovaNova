using Assets.Scripts.Juego.Lista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Juego.Canasta
{
    internal static class RevisarProducto
    {
        public static bool cambio;
        public static bool siEs;

        public static bool Revisar(string nombreProducto)
        {
            for (int i = 0; i < ListaCompras.listaCompras.Count; i++)
            {
                if (nombreProducto == ListaCompras.listaCompras[i])
                {
                    ListaCompras.listaCompras.RemoveAt(i);
                    cambio = true;
                    siEs = true;
                    break;
                }
                siEs = false;
            }

            return siEs;
        }
    }
}
