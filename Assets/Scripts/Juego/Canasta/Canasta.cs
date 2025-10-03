using Assets.Scripts.Juego.Canasta;
using Unity.VisualScripting;
using UnityEngine;

public class Canasta : MonoBehaviour
{
    public string etiqueta;
    public float penalizacion;

    DatosProducto datosProducto;
    GameObject gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == etiqueta)
        {
            datosProducto = other.GetComponent<DatosProducto>();

            if (!RevisarProducto.Revisar(datosProducto.nombre))
            {
                Cronometro cronometro = gameManager.GetComponent<Cronometro>();
                cronometro.contador -= penalizacion;
            }
            
            Destroy(other.gameObject);
        }
    }
}
