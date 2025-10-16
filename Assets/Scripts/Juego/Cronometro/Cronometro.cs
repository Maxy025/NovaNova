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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        contador = tiempo;
        gameOver = GameObject.Find("GameOver");
        textoTiempo = gameOver.transform.Find("tempo").GetComponent<TMP_Text>();
        textoPuntos = gameOver.transform.Find("puntos").GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
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
        }
    }
}
