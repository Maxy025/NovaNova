using UnityEngine;

public class MovimientoCamara : MonoBehaviour
{
    public float velocidad;
    float rotacionX = 0;

    public Transform jugador;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        jugador = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * velocidad * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * velocidad * Time.deltaTime;

        rotacionX -= mouseY;
        rotacionX = Mathf.Clamp(rotacionX, -90f, 90f);

        transform.localRotation = Quaternion.Euler(rotacionX, 0, 0);
        jugador.Rotate(Vector3.up * mouseX);
    }
}
