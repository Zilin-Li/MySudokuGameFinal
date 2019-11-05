﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySudokuGame
{
    public partial class SudokuGame : IGet
    {
        //Realize interface IGet.
        //Get a value by Column
        public int GetByColumn(int columnIndex, int rowIndex)
        {
            cellIndex = columnIndex + rowIndex * maxValue;
            return sudokuArray[cellIndex + 3];
        }

        //Get a value by Row
        public int GetByRow(int rowIndex, int columnIndex)
        {
            cellIndex = columnIndex + rowIndex * maxValue;
            return sudokuArray[cellIndex + 3];
        }

        //Get a value by Square
        public int GetBySquare(int squareIndex, int positionIndex)
        {
            int colInd;
            int rowInd;
            colInd = (squareIndex % (maxValue / squareWidth)) * squareWidth + (positionIndex % squareWidth);
            rowInd = (squareIndex / (maxValue / squareWidth)) * squareHeight + (positionIndex / squareWidth);
            cellIndex = colInd + rowInd * maxValue;
            return sudokuArray[cellIndex + 3];
        }

    }
}
