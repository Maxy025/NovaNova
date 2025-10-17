using Assets.Scripts.Juego.Canasta;
using Assets.Scripts.Juego.Jugador;
using Assets.Scripts.Juego.Lista;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Canasta : MonoBehaviour
{
    public string etiqueta;
    public float bonificacionTiempo;
    public int bonificacionPuntos;
    public float penalizacionProductoEquivocado;
    public float penalizacionProductoProhibido;
    public float aumentoVelocidad;
    public float disminuirAparicion;


    DatosProducto datosProducto;
    GameObject gameManager;
    Cronometro cronometro;
    public TMP_Text textoPuntos;
    public List<GameObject> cintas;
    public Lista lista;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        cronometro = gameManager.GetComponent<Cronometro>();
        textoPuntos = GameObject.Find("Score").GetComponentInChildren<TMP_Text>();
        lista = gameManager.GetComponent<Lista>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == etiqueta)
        {
            datosProducto = other.GetComponent<DatosProducto>();

            if (!RevisarProducto.Revisar(datosProducto.nombre))
            {
                if (RevisarProducto.Prohibido(datosProducto.nombre))
                {
                    cronometro.contador -= penalizacionProductoProhibido;
                }
                else
                {
                    cronometro.contador -= penalizacionProductoEquivocado;
                }
                
            }

            if (RevisarProducto.Revisar(datosProducto.nombre))
            {
                lista.MarcarListaVisual();

                RevisarProducto.Eliminar();
            }

            if (ListaCompras.listaCompras.Count <= 0)
            {
                DatosJugador.Puntos += bonificacionPuntos;
                textoPuntos.text = DatosJugador.Puntos.ToString();

                cronometro.contador += bonificacionTiempo;

                for (int i = 0; i < cintas.Count; i++)
                {
                    AjusteCinta ajuste = cintas[i].GetComponent<AjusteCinta>();
                    ajuste.velocidad += aumentoVelocidad;

                    SpawProducto spaw = cintas[i].transform.Find("SpawProductos").GetComponent<SpawProducto>();
                    spaw.tiempoAparicion -= disminuirAparicion;
                }
            }

                Destroy(other.gameObject);
        }
    }
}
