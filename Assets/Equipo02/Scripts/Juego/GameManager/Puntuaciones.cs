using Assets.Scripts.Juego.Jugador;
using UnityEngine;
using UnityEngine.UI;

public class Puntuaciones : MonoBehaviour
{
    public int unaEstrella, dosEstrellas, tresEstrellas;

    public GameObject estrella1, estrella2, estrella3;
    public Image imagenEstrella1, imagenEstrella2, imagenEstrella3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        estrella1 = GameObject.Find("Estrella 1");
        imagenEstrella1 = estrella1.GetComponent<Image>();
        imagenEstrella1.enabled = false;

        estrella2 = GameObject.Find("Estrella 2");
        imagenEstrella2 = estrella2.GetComponent<Image>();
        imagenEstrella2.enabled = false;

        estrella3 = GameObject.Find("Estrella 3");
        imagenEstrella3 = estrella3.GetComponent<Image>();
        imagenEstrella3.enabled = false;
    }

    public void Estrellas()
    {
        if (DatosJugador.Puntos >= tresEstrellas)
        {
            imagenEstrella1.enabled = true;
            imagenEstrella2.enabled = true;
            imagenEstrella3.enabled = true;
        }
        else if (DatosJugador.Puntos >= dosEstrellas)
        {
            imagenEstrella1.enabled = true;
            imagenEstrella2.enabled = true;
        }
        else if (DatosJugador.Puntos >= unaEstrella)
        {
            imagenEstrella1.enabled = true;
        }
    }
}
