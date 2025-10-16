using Assets.Scripts.Juego.Canasta;
using Assets.Scripts.Juego.Lista;
using UnityEngine;

public class Lista : MonoBehaviour
{
    public int cantidadProductos;
    public string textoLista;
    public int lista;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ListaCompras.CrearListaCompras(cantidadProductos);
        for (int i = 0; i < cantidadProductos; i++) textoLista += $"{ListaCompras.listaCompras[i]}.\n";
    }

    // Update is called once per frame
    void Update()
    {
        lista = ListaCompras.listaCompras.Count;
        if (RevisarProducto.cambio)
        {
            textoLista = "";
            for (int i = 0; i < ListaCompras.listaCompras.Count; i++) textoLista += $"{ListaCompras.listaCompras[i]}.\n";
            RevisarProducto.cambio = false;
        }
        if (ListaCompras.listaCompras.Count <= 0)
        {
            ListaCompras.CrearListaCompras(cantidadProductos);
            for (int i = 0; i < ListaCompras.listaCompras.Count; i++) textoLista += $"{ListaCompras.listaCompras[i]}.\n";
        }
    }
}
