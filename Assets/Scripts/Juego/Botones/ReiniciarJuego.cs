using Assets.Scripts.Juego.Jugador;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReiniciarJuego : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 1;
        DatosJugador.Puntos = 0;
    }

    public void ReiniciarNivel()
    {  
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }
}
