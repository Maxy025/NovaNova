using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    public float velocidad;

    CharacterController controlador;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controlador = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 mover = transform.right * x + transform.forward * z;

        controlador.Move(mover * velocidad * Time.deltaTime);
    }
}
