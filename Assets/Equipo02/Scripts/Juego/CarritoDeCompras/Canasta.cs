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

    public float anCinta1, anCinta2;
    float velCinta1, velCinta2;

    public float tiempoAvisos, contadorAvisoP, contadorAvisoT;

    public float disminuirAparicion;
    public int disminuirBonificacionTiempo;


    DatosProducto datosProducto;


    GameObject gameManager;

    public GameObject textoPuntosExtras, textoTiempoExtra, textoTiempoMenos;

    Cronometro cronometro;
    public TMP_Text textoPuntos;
    public List<GameObject> cintas;
    public Lista lista;
    public SpawnConfetti confetti;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        cronometro = gameManager.GetComponent<Cronometro>();
        textoPuntos = GameObject.Find("Score").GetComponentInChildren<TMP_Text>();
        lista = gameManager.GetComponent<Lista>();
        confetti = GameObject.FindGameObjectWithTag("SpawnConfetti").GetComponent<SpawnConfetti>();

        textoPuntosExtras = GameObject.Find("Puntos Extras");
        textoTiempoExtra = GameObject.Find("Tiempo Extra");
        textoTiempoMenos = GameObject.Find("Tiempo Menos");

        textoPuntosExtras.SetActive(false);
        textoTiempoExtra.SetActive(false);
        textoTiempoMenos.SetActive(false);

        contadorAvisoT = tiempoAvisos;
        contadorAvisoP = tiempoAvisos;

        velCinta1 = anCinta1;
        velCinta2 = anCinta2;
    }

    // Update is called once per frame
    void Update()
    {
        if (textoPuntosExtras.activeSelf) contadorAvisoP -= 1 * Time.deltaTime;
        if (contadorAvisoP <= 0)
        {
            textoPuntosExtras.SetActive(false);
            
        }

        if (textoTiempoExtra.activeSelf && textoTiempoMenos.activeSelf) textoTiempoExtra.SetActive(false);
        if (textoTiempoExtra.activeSelf || textoTiempoMenos.activeSelf) contadorAvisoT -= 1 * Time.deltaTime;
        if (contadorAvisoT <= 0)
        {
            textoTiempoExtra.SetActive(false);
            textoTiempoMenos.SetActive(false);
        }
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
                    textoTiempoMenos.SetActive(true);
                    TMP_Text texto = textoTiempoMenos.GetComponent<TMP_Text>();
                    texto.text = $"-{penalizacionProductoProhibido}";
                    cronometro.contador -= penalizacionProductoProhibido;
                    contadorAvisoT = tiempoAvisos;
                }
                else
                {
                    textoTiempoMenos.SetActive(true);
                    TMP_Text texto = textoTiempoMenos.GetComponent<TMP_Text>();
                    texto.text = $"-{penalizacionProductoEquivocado}";
                    cronometro.contador -= penalizacionProductoEquivocado;
                    contadorAvisoT = tiempoAvisos;
                }
                
            }

            if (RevisarProducto.Revisar(datosProducto.nombre))
            {
                lista.MarcarListaVisual(datosProducto.nombre);
                confetti.ActivarConfetti();
                RevisarProducto.Eliminar();
            }

            if (ListaCompras.listaCompras.Count <= 0)
            {
                float copia1 = anCinta1;
                float copia2 = anCinta2;

                textoPuntosExtras.SetActive(true);
                TMP_Text texto = textoPuntosExtras.GetComponent<TMP_Text>();
                texto.text = $"+{bonificacionPuntos}";
                contadorAvisoP = tiempoAvisos;

                DatosJugador.Puntos += bonificacionPuntos;
                textoPuntos.text = DatosJugador.Puntos.ToString();

                Puntuaciones puntuacion = gameManager.GetComponent<Puntuaciones>();

                
                cronometro.contador += bonificacionTiempo;

                if (DatosJugador.Puntos == puntuacion.unaEstrella)
                {
                    bonificacionTiempo -= disminuirBonificacionTiempo;
                }
                else if (DatosJugador.Puntos == puntuacion.dosEstrellas)
                {
                    bonificacionTiempo -= disminuirBonificacionTiempo;
                }
                else if (DatosJugador.Puntos == puntuacion.tresEstrellas)
                {
                    bonificacionTiempo -= disminuirBonificacionTiempo / 2;
                }

                textoTiempoExtra.SetActive(true);
                texto = textoTiempoExtra.GetComponent<TMP_Text>();
                texto.text = $"+{bonificacionTiempo}";
                contadorAvisoT = tiempoAvisos;

                for (int i = 0; i < cintas.Count; i++)
                {
                    
                    AjusteCinta ajuste = cintas[i].GetComponent<AjusteCinta>();
                    CintaAlembicLoop cintaAnimacion = cintas[i].GetComponentInChildren<CintaAlembicLoop>();
                    ajuste.velocidad += aumentoVelocidad;
                    if (cintaAnimacion.speed == copia1)
                    {
                        cintaAnimacion.speed += (aumentoVelocidad * velCinta1) / 1;
                        anCinta1 = cintaAnimacion.speed;
                    }
                    else if (cintaAnimacion.speed == copia2)
                    {
                        cintaAnimacion.speed += (aumentoVelocidad * velCinta2) / 1;
                        anCinta2 = cintaAnimacion.speed;
                    }

                    SpawProducto spaw = cintas[i].transform.Find("SpawProductos").GetComponent<SpawProducto>();
                    spaw.tiempoAparicion -= disminuirAparicion;
                }

            }

                Destroy(other.gameObject);
        }
    }
}
