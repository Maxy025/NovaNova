using Assets.Scripts.Juego.Lista;
using Unity.VisualScripting;
using UnityEngine;

public class SpawProducto : MonoBehaviour
{
    public float tiempoAparicion;
    public float contador = 0;
    public int comodin = 10;

    public GameObject[] productos;
    public GameObject gameManager;
    public Lista lista;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        lista = gameManager.GetComponent<Lista>();
    }

    // Update is called once per frame
    void Update()
    {
        if (contador >= tiempoAparicion && comodin > 0)
        {
            var producto = Instantiate(productos[UnityEngine.Random.Range(0, productos.Length)], transform.position, transform.rotation);

            if (ListaCompras.listaCompras.Count == 1)
            {
                comodin--;
            }

            contador = 0;
        }
        else if (contador >= tiempoAparicion && comodin <= 0)
        {
            for (int i = 0; i < productos.Length; i++)
            {
                DatosProducto datoP = productos[i].GetComponent<DatosProducto>();
                if (datoP.nombre == ListaCompras.listaCompras[0])
                {
                    var producto = Instantiate(productos[i], transform.position, transform.rotation);
                    break;
                }
            }
            comodin = 10;
            contador = 0;
        }

        contador += 1 * Time.deltaTime;
    }
}
