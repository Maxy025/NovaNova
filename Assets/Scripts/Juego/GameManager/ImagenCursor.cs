using UnityEngine;
using UnityEngine.UI;

public class ImagenCursor : MonoBehaviour
{
    public Sprite[] spritesCursor;

    public GameObject apuntador;

    public Image imagenApuntador;

    private void Start()
    {

        apuntador = GameObject.Find("CrossHairHand");
        imagenApuntador = apuntador.GetComponent<Image>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0)) imagenApuntador.sprite = spritesCursor[1];
        else if (Input.GetMouseButtonUp(0))
        {
            imagenApuntador.sprite = spritesCursor[0];
            apuntador.transform.localScale = Vector3.one;
        }
    }

}
