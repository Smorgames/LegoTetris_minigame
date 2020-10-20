using UnityEngine;

public class Cell : MonoBehaviour
{
    private Collider2D _collider;

    int x = 0;
    int y = 0;
    private FigureQuad _figureQuadPlaced; public FigureQuad FigureQuadPlaced { get { return _figureQuadPlaced; } set { _figureQuadPlaced = value; } }

    private int cellPlacedIndex = 0; public int CellPlacedIndex { get { return cellPlacedIndex } }

    private void Start()
    {
        _collider = GetComponent<Collider2D>();
        ColliderEnabled(true);
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

    public void ColliderEnabled(bool boolean)
    {
        _collider.enabled = boolean;

        if (boolean)
            cellPlacedIndex = 0;
        else
            cellPlacedIndex = 1;
    }

    public void SetXYCoordinates(int xCoordinate, int yCoordinate)
    {
        x = xCoordinate;
        y = yCoordinate;
    }
}