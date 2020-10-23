using UnityEngine;

public class Figure : MonoBehaviour
{
    private FigureQuad[] _figureQuads; public FigureQuad[] FigureQuads { get; }

    public FigureSpawnPoint SpawnPoint { get; set; }

    private void Start()
    {
        _figureQuads = new FigureQuad[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
            _figureQuads[i] = transform.GetChild(i).GetComponent<FigureQuad>();
    }

    private void OnMouseUp()
    {
        if (CanPlaceFigure())
        {
            for (int i = 0; i < transform.childCount; i++)
                _figureQuads[i].PlaceFigure();

            GameMaster.instance.GameField.IsLineFull();

            SpawnPoint.SpawnRandomFigure();

            Destroy(gameObject, 1f);
        }
        else
            Debug.Log("You can't place figure");
    }

    private bool CanPlaceFigure()
    {
        int amountOfActiveFigureQuads = 0;

        foreach (FigureQuad figureQuad in _figureQuads)
            if (figureQuad.CanPlaceOnTheCell)
                amountOfActiveFigureQuads++;

        return amountOfActiveFigureQuads == _figureQuads.Length;
    }

    private void DisplayArrayObjects(object[] array)
    {
        for (int i = 0; i < array.Length; i++)
            Debug.Log(array[i]);
    }

    public void RotateAllFigureQuads(Vector3 rotatationAngle)
    {
        foreach (FigureQuad figureQuad in _figureQuads)
            figureQuad.transform.Rotate(rotatationAngle);
    }

    public void SetFigureQuadStartRotation(Vector3 startRotation)
    {
        foreach (FigureQuad figureQuad in _figureQuads)
            figureQuad.transform.rotation = Quaternion.Euler(startRotation);
    }

    public void ChangeOrderLayerOfFigure(int changeAmount)
    {
        foreach (FigureQuad figureQuad in _figureQuads)
            figureQuad.GetComponent<SpriteRenderer>().sortingOrder += changeAmount;
    }
}