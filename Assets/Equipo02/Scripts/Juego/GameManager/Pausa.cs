using System.Collections;
using UnityEngine;

public class Pausa : MonoBehaviour
{
    public GameObject pausa;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pausa = GameObject.Find("Pausa");
        pausa.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyUp(KeyCode.P) || Input.GetKeyUp(KeyCode.Escape)) && Time.timeScale == 1)
        {
            pausa.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
        }
        else if ((Input.GetKeyUp(KeyCode.P) || Input.GetKeyUp(KeyCode.Escape)) && Time.timeScale == 0)
        {
            Despausar();
        }
    }

    public void Despausar()
    {
        pausa.SetActive(false);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
    }

}
