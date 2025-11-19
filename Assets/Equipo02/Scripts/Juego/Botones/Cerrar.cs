using UnityEngine;

public class Cerrar : MonoBehaviour
{
    public GameObject creditos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        creditos = GameObject.Find("Creditos");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CerraCredutos()
    {
        creditos.SetActive(false);
    }
}
