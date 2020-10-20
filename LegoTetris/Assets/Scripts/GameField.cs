using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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

    public void DeactivateCell(int x, int y)
    {
        _gameField[x, y].gameObject.SetActive(false);
    }

    public int IsLineFull()
    {
        int completeLineCount = 0;
        List<Cell> cells = new List<Cell>();

        for (int i = 0; i < _gameField.GetLength(0); i++)
        {
            int firstLenghtCount = 0;

            for (int j = 0; j < _gameField.GetLength(1); j++)
            {
                firstLenghtCount += _gameField[i, j].CellPlacedIndex;

                if (firstLenghtCount == _gameField.GetLength(1))
                {
                    completeLineCount++;

                    for (int k = 0; k < _gameField.GetLength(1); k++)
                        cells.Add(_gameField[i, k]);
                }
            }
        }

        return completeLineCount;
    }
}