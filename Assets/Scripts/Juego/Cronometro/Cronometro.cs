using UnityEngine;

public class Cronometro : MonoBehaviour
{
    public float tiempo;

    public float contador = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        contador = tiempo;
    }

    // Update is called once per frame
    void Update()
    {
        if (contador > 0)
        {
            contador -= 1 * Time.deltaTime;
        }
    }
}
