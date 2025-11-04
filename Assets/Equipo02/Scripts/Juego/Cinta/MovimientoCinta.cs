using UnityEngine;

public class MovimientoCinta : MonoBehaviour
{
    public string direccion;
    public bool sobreCinta;
    public string etiqueta;

    AjusteCinta ajustes;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (sobreCinta)
        {
            switch (direccion)
            {
                case "Xderecha":
                    transform.position += new Vector3(ajustes.velocidad * Time.deltaTime, 0, 0);
                    break;
                case "Xizquierda":
                    transform.position -= new Vector3(ajustes.velocidad * Time.deltaTime, 0, 0);
                    break;
                case "Zderecha":
                    transform.position += new Vector3(0, 0, ajustes.velocidad * Time.deltaTime);
                    break;
                case "Zizquierda":
                    transform.position -= new Vector3(0, 0, ajustes.velocidad * Time.deltaTime);
                    break;
                default:
                    break;
            }
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == etiqueta)
        {
            sobreCinta = true;
            ajustes = other.GetComponentInParent<AjusteCinta>();
            direccion = ajustes.direccion;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == etiqueta)
        {
            sobreCinta = false;
            direccion = "";
        }
    }
}
