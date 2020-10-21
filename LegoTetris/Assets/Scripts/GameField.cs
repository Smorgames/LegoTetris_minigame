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

        for (int i = 0; i < _gameField.GetLength(1); i++)
        {
            int horizontalCompletedLines = 0;

            for (int j = 0; j < _gameField.GetLength(0); j++)
            {
                horizontalCompletedLines += _gameField[j, i].CellPlacedIndex;

                if (horizontalCompletedLines == _gameField.GetLength(0))
                {
                    completeLineCount++;

                    for (int k = 0; k < _gameField.GetLength(0); k++)
                        cells.Add(_gameField[k, i]);
                }
            }
        }

        for (int i = 0; i < _gameField.GetLength(0); i++)
        {
            int verticalCompletedLines = 0;

            for (int j = 0; j < _gameField.GetLength(1); j++)
            {
                verticalCompletedLines += _gameField[i, j].CellPlacedIndex;

                if (verticalCompletedLines == _gameField.GetLength(1))
                {
                    completeLineCount++;

                    for (int k = 0; k < _gameField.GetLength(1); k++)
                        cells.Add(_gameField[i, k]);
                }
            }
        }


        foreach (Cell cell in cells)
            cell.CleanCell();

        //Debug.Log("Total completed lines: " + completeLineCount + "; Cells in cell container = " + cells.Count);

        return completeLineCount;
    }

    public void DisplayGameFieldWidthAndHeight() // for testing
    {
        Debug.Log("Game field width = " + _gameField.GetLength(0));
        Debug.Log("Game field height = " + _gameField.GetLength(1));
    }
}