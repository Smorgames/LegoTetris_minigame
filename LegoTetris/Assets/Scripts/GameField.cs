using UnityEngine;

public class GameField
{
    private int _horizontalSize;
    private int _verticalSize;

    private Cell[,] _gameField;

    public GameField(int horizontalSize, int verticalSize)
    {
        _horizontalSize = horizontalSize;
        _verticalSize = verticalSize;

        _gameField = new Cell[_horizontalSize, _verticalSize];
    }

    public void AddCell(int x, int y, Cell cell)
    {
        _gameField[x, y] = cell;
    }

    //public bool IsLineFull()
    //{
    //    for (int i = 0; i < _gameField.GetLength(0); i++)
    //    {
    //        for (int j = 0; j < _gameField.GetLength(1); j++)
    //        {
    //            _gameField.
    //        }
    //    }
    //}
}