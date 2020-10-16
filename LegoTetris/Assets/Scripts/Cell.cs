using UnityEngine;

public class Cell : MonoBehaviour
{
    private Collider2D _collider;

    private void Start()
    {
        _collider = GetComponent<Collider2D>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "FigureQuad")
            SetCellPlacePossibility(collision, true, this);

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "FigureQuad")
            SetCellPlacePossibility(collision, false, null);
    }

    private void SetCellPlacePossibility(Collider2D figure, bool isPossible, Cell cell)
    {
        if (figure.GetComponent<FigureQuad>() != null)
            figure.GetComponent<FigureQuad>().SetCellPlacePossibility(isPossible, cell);
    }

    public void PlaceFigureQuad(GameObject quad)
    {
        quad.transform.position = transform.position;
        _collider.enabled = false;
    }
}