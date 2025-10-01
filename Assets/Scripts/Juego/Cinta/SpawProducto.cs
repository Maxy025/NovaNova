using UnityEngine;

public class SpawProducto : MonoBehaviour
{
    public float tiempoAparicion;
    public float contador = 0;

    public GameObject[] productos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (contador >= tiempoAparicion)
        {
            var producto = Instantiate(productos[UnityEngine.Random.Range(0, productos.Length)], transform.position, transform.rotation);
            contador = 0;
        }

        contador += 1 * Time.deltaTime;
    }
}
