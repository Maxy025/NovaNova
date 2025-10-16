using Assets.Scripts.Juego.Jugador;
using Assets.Scripts.Juego.Lista;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReiniciarJuego : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 1;
        DatosJugador.Puntos = 0;
        if (ListaCompras.listaCompras.Count > 0) ListaCompras.LimpiarListaCompras();
    }

    public void ReiniciarNivel()
    {  
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
