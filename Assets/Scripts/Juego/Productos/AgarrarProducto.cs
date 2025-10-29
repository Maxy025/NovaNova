using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AgarrarProducto : MonoBehaviour
{
    public Vector3 mousePositionOffset;
    public string etiqueta = "Agarrar";
    public bool tomar;

    public GameObject apuntador;
    public GameObject gameManager;

    public Image imagenApuntador;
    public ImagenCursor imagenCursor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        apuntador = GameObject.Find("CrossHairHand");
        gameManager = GameObject.Find("GameManager");
        imagenApuntador = apuntador.GetComponent<Image>();
        imagenCursor = gameManager.GetComponent<ImagenCursor>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
            
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePositionOffset);
        }
        
    }

    private void OnMouseOver()
    {
        if (tomar) apuntador.transform.localScale = Vector3.one*1.5f;
    }

    private void OnMouseExit()
    {
        apuntador.transform.localScale = Vector3.one;
    }

    private void OnMouseUp()
    {
        imagenApuntador.sprite = imagenCursor.spritesCursor[0];
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == etiqueta)
        {
            tomar = true;
        }
    }
}
