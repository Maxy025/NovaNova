using Assets.Scripts.Juego.Canasta;
using Assets.Scripts.Juego.Lista;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lista : MonoBehaviour
{
    public int cantidadProductos;
    public string textoLista;
    public int lista;


    public List<GameObject> listaVisual = new List<GameObject>();
    public List<Sprite> imagenesProductos = new List<Sprite>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ListaCompras.CrearListaCompras(cantidadProductos);
        for (int i = 0; i < cantidadProductos; i++) textoLista += $"{ListaCompras.listaCompras[i]}.\n";
        lista = ListaCompras.listaCompras.Count;
        LlenarListaVisual();
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
            LlenarListaVisual();
            for (int i = 0; i < ListaCompras.listaCompras.Count; i++) textoLista += $"{ListaCompras.listaCompras[i]}.\n";
        }
    }

    public void LlenarListaVisual()
    {
        for (int i = 0; i < listaVisual.Count; i++)
        {
            Image imageProducto = listaVisual[i].GetComponent<Image>();
            for (int j = 0; j < ListaProductos.productosPermitidos.Length; j++)
            {
                if (ListaProductos.productosPermitidos[j] == ListaCompras.listaCompras[i])
                {
                    imageProducto.sprite = imagenesProductos[j];
                    break;
                }
            }
        }
    }

    public void MarcarListaVisual()
    {

        for (int i = 0; i < ListaProductos.productosPermitidos.Length; i++)
        {
            if (ListaProductos.productosPermitidos[i] == ListaCompras.listaCompras[RevisarProducto.indice])
            {
                for (int j = 0; j < listaVisual.Count; j++)
                {
                    Image imageProducto = listaVisual[j].GetComponent<Image>();
                    if (imageProducto.sprite == imagenesProductos[i])
                    {
                        imageProducto.sprite = null;
                        break;
                    }
                }

            }
        }

    }
}
