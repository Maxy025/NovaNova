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
    public List<GameObject> cintas;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        cronometro = gameManager.GetComponent<Cronometro>();
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
            else if (ListaCompras.listaCompras.Count <= 0)
            {
                cronometro.contador += bonificacionTiempo;
                for (int i = 0; i < cintas.Count; i++)
                {
                    AjusteCinta ajuste = cintas[i].GetComponent<AjusteCinta>();
                    ajuste.velocidad += aumentoVelocidad;

                    SpawProducto spaw = cintas[i].transform.Find("SpawProductos").GetComponent<SpawProducto>();
                    spaw.tiempoAparicion -= disminuirAparicion;
                }
                DatosJugador.Puntos += bonificacionPuntos;
            }

                Destroy(other.gameObject);
        }
    }
}
