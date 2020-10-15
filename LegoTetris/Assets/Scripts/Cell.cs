using UnityEngine;

public class Cell : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "FigureQuad")
            collision.GetComponent<FigureQuad>().SetCellPlacePossibility(true);

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "FigureQuad")
            collision.GetComponent<FigureQuad>().SetCellPlacePossibility(false);
    }
}
