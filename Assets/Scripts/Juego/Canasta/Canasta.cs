using Assets.Scripts.Juego.Canasta;
using Assets.Scripts.Juego.Lista;
using Unity.VisualScripting;
using UnityEngine;

public class Canasta : MonoBehaviour
{
    public string etiqueta;
    public float bonificacion;
    public float penalizacionProductoEquivocado;
    public float penalizacionProductoProhibido;

    DatosProducto datosProducto;
    GameObject gameManager;
    Cronometro cronometro;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        cronometro = gameManager.GetComponent<Cronometro>();
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
                if (RevisarProducto.Prohibido(datosProducto.nombre))
                {
                    cronometro.contador -= penalizacionProductoProhibido;
                }
                else
                {
                    cronometro.contador -= penalizacionProductoEquivocado;
                }
                
            }
            else if (ListaCompras.listaCompras.Count <= 0)
            {
                cronometro.contador += bonificacion;
            }

                Destroy(other.gameObject);
        }
    }
}
