using UnityEngine;

public class DragAndDropObject : MonoBehaviour
{
    private Vector3 _startPosition;
    private Vector3 _mouseOffset;

    private void Start()
    {
        _startPosition = transform.position;
        _mouseOffset = new Vector3(0f, 0f, 10f);
    }
    private void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + _mouseOffset;
    }

    private void OnMouseUp()
    {
        transform.position = _startPosition;
    }
}
