using UnityEngine;

public class Figure : MonoBehaviour
{
    private FigureQuad[] _figureQuads;

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

            for (int i = 0; i < transform.childCount; i++)
                _figureQuads[i].transform.SetParent(null);

            Destroy(gameObject);
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
}

//private void DisplayArrayObjects(object[] array)
//{
//    for (int i = 0; i < array.Length; i++)
//        Debug.Log(array[i]);
//}