using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cerrar : MonoBehaviour
{
    public AudioManager audio;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audio = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IrPantallaInicio()
    {
        SceneManager.LoadScene("GamesE_E02_NovaNova_MenuPrincipal", LoadSceneMode.Single);
        audio.StopMusic();
    }
}
