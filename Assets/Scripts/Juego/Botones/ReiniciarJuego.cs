using Assets.Scripts.Juego.Jugador;
using Assets.Scripts.Juego.Lista;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReiniciarJuego : MonoBehaviour
{
    GameObject gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager");

        Time.timeScale = 1;
        DatosJugador.Puntos = 0;
    }

    public void ReiniciarNivel()
    {  
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
