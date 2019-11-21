using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySudokuGame
{
    public partial class SudokuGame : ISet
    {
        public int rowIndex, colIndex, cellIndex;

        // Set a value by column.
        public void SetByColumn(int value, int columnIndex, int rowIndex)
        {

            if (value >= 0 && value <= maxValue && rowIndex >= 0 && rowIndex < maxValue && columnIndex >= 0 && columnIndex < maxValue)
            {
               cellIndex = columnIndex + rowIndex * maxValue;
                sudokuArray[cellIndex + 3] = value;
            }
            else
            {
                Console.WriteLine("Out of range!");
            }

        }

        // Set a value by row.
        public void SetByRow(int value, int rowIndex, int columnIndex)
        {

            if (value >= 0 && value <= maxValue && rowIndex >= 0 && rowIndex < maxValue && columnIndex >= 0 && columnIndex < maxValue)
            {
                cellIndex = columnIndex + rowIndex * maxValue;
                sudokuArray[cellIndex +3] = value;
            }
            else
            {
                Console.WriteLine("Out of range!");
            }
        }

        // Set a value by square.
        public void SetBySquare(int value, int squareIndex, int positionIndex)
        {
            int colInd;
            int rowInd;
            if (value >= 0 && value <= maxValue && squareIndex >= 0 && squareIndex < maxValue && positionIndex >= 0 && positionIndex < maxValue)
            {
                // Use squareIndex and positionIndex to find out the colindex and rowindex
                // use colindex and rowindex to set the value
                colInd = (squareIndex % (maxValue / squareWidth)) * squareWidth + (positionIndex % squareWidth);
                rowInd = (squareIndex / (maxValue / squareWidth)) * squareHeight + (positionIndex / squareWidth);
                cellIndex = colInd + rowInd * maxValue;
                sudokuArray[cellIndex + 3] = value;
            }
            else
            {
                Console.WriteLine("Out of range!");
            }
        }
    }
}
