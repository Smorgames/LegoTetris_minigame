using UnityEngine;

public class DragAndDropObject : MonoBehaviour
{
    private Vector3 _startPosition;
    private Vector3 _mouseOffset;

    private RotateObject _rotateObject;

    private Figure figureComponent;

    private void Start()
    {
        _rotateObject = GetComponent<RotateObject>();

        _startPosition = transform.position;
        _mouseOffset = new Vector3(0f, 0f, 10f);

        figureComponent = GetComponent<Figure>();
    }

    private void OnMouseDown()
    {
        figureComponent.ChangeOrderLayerOfFigure(1);
    }

    private void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + _mouseOffset;

        _rotateObject.CanRotate = true;
    }

    private void OnMouseUp()
    {
        transform.position = _startPosition;

        _rotateObject.CanRotate = false;

        _rotateObject.SetStartRotation();

        figureComponent.ChangeOrderLayerOfFigure(-1);
    }
}
