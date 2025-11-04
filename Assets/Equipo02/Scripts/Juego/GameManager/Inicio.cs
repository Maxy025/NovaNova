using UnityEngine;

public class Inicio : MonoBehaviour
{
    public bool esElIncio = true;

    public GameObject inicio;
    public GameObject interfaz;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inicio = GameObject.Find("InterfaziIntroducción");
        interfaz = GameObject.Find("Interfaz");
    }

    void Update()
    {
        if (esElIncio)
        {
            Time.timeScale = 0;
            interfaz.SetActive(false);
        }
    }

    public void Iniciar()
    {
        Time.timeScale = 1;
        inicio.SetActive(false);
        interfaz.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        esElIncio = false;
    }
}
