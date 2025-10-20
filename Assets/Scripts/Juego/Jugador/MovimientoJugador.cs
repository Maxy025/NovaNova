using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    public float velocidadCaminata;
    public float velocidadCorrer;

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
        float y = 1.08f;

        Vector3 mover = transform.right * x + transform.forward * z;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            controlador.Move(mover * velocidadCorrer * Time.deltaTime);
        }
        else controlador.Move(mover * velocidadCaminata * Time.deltaTime);

        if (transform.position.y != 1.08) transform.position = new Vector3(transform.position.x, 1.08f, transform.position.z);
    }
}
