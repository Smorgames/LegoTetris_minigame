using UnityEngine;

public class FigureQuad : MonoBehaviour
{
    private Color _enableColor;
    private Color _disableColor;

    private bool _canPlaceOnTheCell = false;

    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _disableColor = _spriteRenderer.color;
        _enableColor = new Color(1f, 1f, 1f, 1f);
    }

    public void SetCellPlacePossibility(bool canPlaceOnTheCell)
    {
        _canPlaceOnTheCell = canPlaceOnTheCell;

        if (_canPlaceOnTheCell)
            SetColor(_enableColor);
        else
            SetColor(_disableColor);
    }

    private void SetColor(Color color)
    {
        _spriteRenderer.color = color;
    }
}
