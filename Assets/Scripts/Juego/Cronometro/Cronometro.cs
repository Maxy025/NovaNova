using Assets.Scripts.Juego.Jugador;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Cronometro : MonoBehaviour
{
    public float tiempo;

    public float contador = 0;
    public float contadorTotal = 0;

    public GameObject gameOver;
    public TMP_Text textoTiempo;
    public TMP_Text textoPuntos;

    public TMP_Text textoCronometro;

    public GameObject gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("GameManager");

        contador = tiempo;
        gameOver = GameObject.Find("GameOver");
        textoTiempo = gameOver.transform.Find("tempo").GetComponent<TMP_Text>();
        textoPuntos = gameOver.transform.Find("puntos").GetComponent<TMP_Text>();

        textoCronometro = GameObject.Find("Cronometro").GetComponentInChildren<TMP_Text>();

        
        StartCoroutine(DesactivarGameOver());
    }

    private IEnumerator DesactivarGameOver()
    {
        yield return null;
        gameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        textoCronometro.text = Mathf.FloorToInt(contador).ToString();
        if (contador > 0)
        {
            contador -= 1 * Time.deltaTime;
            contadorTotal += 1 * Time.deltaTime;
        }
        else
        {
            gameOver.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            textoTiempo.text = contadorTotal.ToString();
            textoPuntos.text = DatosJugador.Puntos.ToString();
            Puntuaciones puntuaciones = gameManager.GetComponent<Puntuaciones>();
            puntuaciones.Estrellas();
        }
    }
}
