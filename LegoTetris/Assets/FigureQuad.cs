using UnityEngine;

public class FigureQuad : MonoBehaviour
{
    private Color _enableColor;
    private Color _disableColor;

    private bool _canPlaceOnTheCell = false;

    private SpriteRenderer _spriteRenderer;

    private Cell _chosenCell;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _disableColor = _spriteRenderer.color;
        _enableColor = new Color(1f, 1f, 1f, 1f);
    }

    public void SetCellPlacePossibility(bool canPlaceOnTheCell, Cell cell)
    {
        _canPlaceOnTheCell = canPlaceOnTheCell;
        _chosenCell = cell;

        if (_canPlaceOnTheCell)
            FigureQuadVisualDisplay(_enableColor, 1.1f);
        else
            FigureQuadVisualDisplay(_disableColor, 1f);
    }

    private void FigureQuadVisualDisplay(Color color, float quadSize)
    {
        _spriteRenderer.color = color;
        transform.localScale = new Vector3(quadSize, quadSize, 1f);
    }

    public bool CanPlaceOnTheCell { get { return _canPlaceOnTheCell; } }

    public void PlaceFigure()
    {
        _spriteRenderer.color = _enableColor;
        _chosenCell.PlaceFigureQuad(gameObject);
    }
}