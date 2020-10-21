using UnityEngine;

public class CellSpriteController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;

    [SerializeField] private Sprite[] _cellSprites;

    public void ChangeCellSprite(int number)
    {
        _spriteRenderer.sprite = _cellSprites[number];
    }
}
