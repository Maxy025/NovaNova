using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AgarrarProducto : MonoBehaviour
{
    public Vector3 mousePositionOffset;
    public string etiqueta = "Agarrar";
    public bool tomar;
    public bool agarrando;

    public GameObject apuntador;
    public GameObject flecha;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        apuntador = GameObject.Find("CrossHairHand");
    }

    // Update is called once per frame
    void Update()
    {
        if (agarrando)
        {

        }
    }

    private Vector3 GetMouseWorldPos()
    {
        return Camera.main.WorldToScreenPoint(transform.position); 
    }
    private void OnMouseDown()
    {
        mousePositionOffset = Input.mousePosition - GetMouseWorldPos();
        
    }

    private void OnMouseDrag()
    {
        if (tomar)
        {
            apuntador.transform.localScale = Vector3.one * 1.5f;
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePositionOffset);
            agarrando = true;
        }
        else agarrando = false;
        
    }

    private void OnMouseOver()
    {
        if (tomar) apuntador.transform.localScale = Vector3.one*1.5f;
    }

    private void OnMouseExit()
    {
        if (!agarrando) apuntador.transform.localScale = Vector3.one;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == etiqueta)
        {
            tomar = true;
        }
    }
}
