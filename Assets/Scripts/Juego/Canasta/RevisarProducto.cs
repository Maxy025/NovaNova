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
        public static bool siEs;
        public static bool siProhibido;
        public static int indice;

        public static bool Revisar(string nombreProducto)
        {
            for (int i = 0; i < ListaCompras.listaCompras.Count; i++)
            {
                if (nombreProducto == ListaCompras.listaCompras[i])
                {
                    indice = i;
                    siEs = true;
                    break;
                }
                siEs = false;
            }

            return siEs;
        }

        public static bool Prohibido(string nombreProducto)
        {
            for (int i = 0; i < ListaProductos.productosProhibidos.Length; i++)
            {
                if (nombreProducto == ListaProductos.productosProhibidos[i])
                {
                    siProhibido = true;
                    break;
                }
                siProhibido = false;
            }

            return siProhibido;
        }

        public static void Eliminar()
        {
            ListaCompras.listaCompras.RemoveAt(indice);
        }
    }
}
