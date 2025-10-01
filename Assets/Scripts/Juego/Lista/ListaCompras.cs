using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;

namespace Assets.Scripts.Juego.Lista
{
    internal static class ListaCompras
    {
        public static List<string> listaCompras = new List<string>();

        static Random rand = new Random();

        public static void CrearListaCompras(int cantidadProductos)
        {
            for (int i = 0; i < cantidadProductos; i++)
            {
                listaCompras.Add(ListaProductos.productos[rand.Next(0, ListaProductos.productos.Length)]);
            }
        }
    }
}
