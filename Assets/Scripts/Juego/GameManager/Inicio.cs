using UnityEngine;

public class Inicio : MonoBehaviour
{
    public bool esElIncio = true;

    public GameObject inicio;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inicio = GameObject.Find("InterfaziIntroducción");
    }

    void Update()
    {
        if (esElIncio) Time.timeScale = 0;
    }

    public void Iniciar()
    {
        Time.timeScale = 1;
        inicio.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        esElIncio = false;
    }
}
