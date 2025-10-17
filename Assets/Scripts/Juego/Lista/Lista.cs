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
        lista = ListaCompras.listaCompras.Count;
    }

    // Update is called once per frame
    void Update()
    {
        if (lista != ListaCompras.listaCompras.Count)
        {
            textoLista = "";
            for (int i = 0; i < ListaCompras.listaCompras.Count; i++) textoLista += $"{ListaCompras.listaCompras[i]}.\n";
            lista = ListaCompras.listaCompras.Count;
        }
        if (ListaCompras.listaCompras.Count <= 0)
        {
            ListaCompras.CrearListaCompras(cantidadProductos);
            for (int i = 0; i < ListaCompras.listaCompras.Count; i++) textoLista += $"{ListaCompras.listaCompras[i]}.\n";
        }
    }
}
