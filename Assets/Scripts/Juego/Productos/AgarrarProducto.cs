using Unity.VisualScripting;
using UnityEngine;

public class AgarrarProducto : MonoBehaviour
{
    public Vector3 mousePositionOffset;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePositionOffset);
    }
}
