using Assets.Scripts.Juego.Canasta;
using UnityEngine;

public class Canasta : MonoBehaviour
{
    public string etiqueta;

    DatosProducto datosProducto;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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

            RevisarProducto.Revisar(datosProducto.nombre);
            Destroy(other.gameObject);
        }
    }
}
