using Assets.Scripts.Juego.Canasta;
using Assets.Scripts.Juego.Lista;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class EntradaDiccionarioImagenesProductos
{
    public string nombreProducto;
    public Sprite imagenProducto;
}

public class Lista : MonoBehaviour
{
    public int cantidadProductos;
    public string textoLista;
    public int lista;


    public List<GameObject> listaVisual = new List<GameObject>();

    public List<EntradaDiccionarioImagenesProductos> DiccionarioImagenesProductos = new List<EntradaDiccionarioImagenesProductos>();
    public Dictionary<string, Sprite> imagenesProductos = new Dictionary<string, Sprite>();

    private void Awake()
    {
        foreach (var entrada in DiccionarioImagenesProductos)
        {
            imagenesProductos[entrada.nombreProducto] = entrada.imagenProducto;
        }
    }

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

            imageProducto.sprite = imagenesProductos[ListaCompras.listaCompras[i]];
        }
    }

    public void MarcarListaVisual(string nombre)
    {

        for (int i = 0; i < listaVisual.Count; i++)
        {
            Image imageProducto = listaVisual[i].GetComponent<Image>();

            if (imageProducto.sprite == imagenesProductos[nombre])
            {
                imageProducto.sprite = null;
                break;
            }
        }

    }
}
