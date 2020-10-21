using UnityEngine;
using System.Collections;

public class FigureQuad : MonoBehaviour
{
    private Color _enableColor;
    private Color _disableColor;

    [SerializeField] GameObject disappearEffect;
    private bool _canPlaceOnTheCell = false; public bool CanPlaceOnTheCell { get { return _canPlaceOnTheCell; } }

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
            FigureQuadVisualDisplay(_enableColor);
        else
            FigureQuadVisualDisplay(_disableColor);
    }

    private void FigureQuadVisualDisplay(Color _color)
    {
        _spriteRenderer.color = _color;
    }

    public void PlaceFigure()
    {
        StartCoroutine(PlaceFigureCoroutine());
    }

    private IEnumerator PlaceFigureCoroutine()
    {
        transform.position = _chosenCell.transform.position;

        _chosenCell.FigureQuadPlaced = this;

        _chosenCell.ColliderEnabled(false);

        yield return new WaitForSeconds(Time.deltaTime);

        transform.SetParent(null);
        FigureQuadVisualDisplay(_enableColor);
    }

    public void DestroyFigureQuad()
    {
        GameObject effect = Instantiate(disappearEffect, transform.position, Quaternion.identity);
        effect.GetComponent<ParticleSystem>().textureSheetAnimation.SetSprite(0, _spriteRenderer.sprite);

        Destroy(effect, 2f);
        Destroy(gameObject);
    }
}