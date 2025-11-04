using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincio : MonoBehaviour
{


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void IniciarJuego()
    {
        //audioManager.PlaySFX(audioManager.botones);
        SceneManager.LoadScene("Juego", LoadSceneMode.Single);//Metodo usado para cargar la escena del juego
                                                              //cuando el jugador presiona un boton
    }

    public void MenuPrincipal()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);//Carga la escena del menu principal 
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver", LoadSceneMode.Single);//Carga la escena del menu principal 
    }
    public void Salir()
    {
        Application.Quit();
    }

}
