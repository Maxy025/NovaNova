using Assets.Scripts.Juego.Jugador;
using UnityEngine;

public class Puntuaciones : MonoBehaviour
{
    public int unaEstrella, dosEstrellas, tresEstrellas;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Estrellas()
    {
        if (DatosJugador.Puntos >= tresEstrellas)
        {

        }
        else if (DatosJugador.Puntos >= dosEstrellas)
        {

        }
        else if (DatosJugador.Puntos >= unaEstrella)
        {

        }
        else
        {

        }
    }
}
