using UnityEngine;

public class RotateObject : MonoBehaviour
{
    private bool _canRotate = false;

    private void Update()
    {
        if (_canRotate)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
                transform.Rotate(0f, 0f, 90f);

            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
                transform.Rotate(0f, 0f, -90f);
        }
    }

    public bool CanRotate { get { return _canRotate; } set { _canRotate = value; } }
}
