using UnityEngine;

public class RotateObject : MonoBehaviour
{
    private bool _canRotate = false; public bool CanRotate { get { return _canRotate; } set { _canRotate = value; } }

    private Vector3 startRotation = new Vector3(0f, 0f, 0f);
    private Vector3 rightNinetyDegree = new Vector3(0f, 0f, 90f);
    private Vector3 leftNinetyDegree = new Vector3(0f, 0f, -90f);

    private Figure figureComponent;

    private void Start()
    {
        figureComponent = GetComponent<Figure>();
    }

    private void Update()
    {
        if (_canRotate)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
                RotateFigure(rightNinetyDegree, leftNinetyDegree);

            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
                RotateFigure(leftNinetyDegree, rightNinetyDegree);
        }
    }

    public void SetStartRotation()
    {
        transform.rotation = Quaternion.Euler(startRotation);
        figureComponent.SetFigureQuadStartRotation(startRotation);
    }

    private void RotateFigure(Vector3 figureRotateAngle, Vector3 figureQuadRotateAngle)
    {
        transform.Rotate(figureRotateAngle);
        figureComponent.RotateAllFigureQuads(figureQuadRotateAngle);
    }
}