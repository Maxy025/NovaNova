using UnityEngine;
using UnityEngine.UI;

public class ImagenCursor : MonoBehaviour
{
    public Sprite[] spritesCursor;

    public GameObject apuntador;

    public Image imagenApuntador;

    private void OnMouseDown()
    {
        imagenApuntador.sprite = spritesCursor[1];
    }

    private void OnMouseUp()
    {
        
    }
}
