using UnityEngine;

public class MovimientoFlecha : MonoBehaviour
{
    public float velocidad;
    public float distancia;
    float contador = 0;
    bool arriba = true;

    public MeshRenderer flecha;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        flecha = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (contador > distancia)
        {
            arriba = false;
        }
        if (contador < -distancia)
        {
            arriba = true;
        }


        if (arriba)
        {
            transform.position += new Vector3(0, velocidad, 0) * Time.deltaTime;
            contador += velocidad * Time.deltaTime;
        }
        if (!arriba)
        {
            transform.position -= new Vector3(0, velocidad, 0) * Time.deltaTime;
            contador -= velocidad * Time.deltaTime;
        }


            
    }
}
