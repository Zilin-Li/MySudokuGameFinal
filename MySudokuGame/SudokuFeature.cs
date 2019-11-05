using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySudokuGame
{
   
    public partial class SudokuGame
    {
        public int rowIndex, colIndex, cellIndex;
        public void GetButtonInfo(string buttonName)
        {
            string buttonValue = "";
            for (int i = 0; i < buttonName.Length; i++)
            {
                if (Char.IsNumber(buttonName, i) == true)
                {
                    buttonValue += buttonName.Substring(i, 1);
                }
            }

            rowIndex = Int32.Parse(buttonValue[0].ToString());
            colIndex = Int32.Parse(buttonValue[1].ToString());
            cellIndex = colIndex + rowIndex * maxValue;
        }

        public bool IsDefault()
        {
            bool isDef = false;
            if (defIndexList.Contains(cellIndex))
            {
                isDef = true;
            }
            return isDef;     
        }

        //Other features

        //feature 1: check whether a row is vaild.
        public bool RowVaild(int RowNumber)
        {
            bool isVaildRow = true;

            int[] rowValue = new int[maxValue];
            //put every value of the row into an int array.
            //for next step to check
            for (int i = 0; i < maxValue; i++)
            {
                rowValue[i] = GetByRow(RowNumber, i);
            }

            //sort the value, the vaild value should be 1~maxValue.
            //if not return false.

            Array.Sort(rowValue);
            for (int a = 0; a < maxValue; a++)
            {
                if (rowValue[a] != a + 1)
                {
                    isVaildRow = false;
                }
            }
            return isVaildRow;
        }

        //feature 2: check whether a column is vaild.
        public bool ColumnVaild(int ColumnNumber)
        {
            bool isVaildColumn = true;

            int[] ColumnValue = new int[maxValue];
            //put each value of the Column into an int array.
            //for next step to check
            for (int i = 0; i < maxValue; i++)
            {
                ColumnValue[i] = GetByColumn(ColumnNumber, i);
            }

            //sort the value, the vaild value should be 1~maxValue.
            //if not return false.

            Array.Sort(ColumnValue);
            for (int a = 0; a < maxValue; a++)
            {
                if (ColumnValue[a] != a + 1)
                {
                    isVaildColumn = false;
                }
            }
            return isVaildColumn;
        }

        //feature 3: check whether a square is vaild.
        public bool SquareVaild(int squareNumber)
        {
            bool isVaildSquare = true;

            int[] SquareValue = new int[maxValue];
            //put every value of the Square into an int array.
            //for next step to check
            for (int i = 0; i < maxValue; i++)
            {
                SquareValue[i] = GetBySquare(squareNumber, i);
            }

            //sort the value, the vaild value should be 1~maxValue.
            //if not return false.

            Array.Sort(SquareValue);
            for (int a = 0; a < maxValue; a++)
            {
                if (SquareValue[a] != a + 1)
                {
                    isVaildSquare = false;
                }
            }
            return isVaildSquare;
        }

        public bool AllVaild()
        {
            bool isAllVaild = true;
            for(int a = 0; a < maxValue; a++)
            {
                if (!RowVaild(a))
                {
                    isAllVaild = false;
                    return isAllVaild;
                }
                if (!ColumnVaild(a))
                {
                    isAllVaild = false;
                    return isAllVaild;
                }
                if (!SquareVaild(a))
                {
                    isAllVaild = false;
                    return isAllVaild;
                }
            }
            return isAllVaild;
        }

        //feature 4: list vaild value by Row.
        public List<int> VaildValueByRow(int gridIndex)
        {

            //step1: put all value(1-maxvalue) into list.
            List<int> rowVaildValue = new List<int>();
            for (int i = 1; i <= maxValue; i++)
            {
                rowVaildValue.Add(i);
            }

            // get the rowIndex
            int rowIndex = gridIndex / maxValue;

            //step2: use get GetByRow() to get each value of the row
            for (int a = 0; a < maxValue; a++)
            {
                int eachRowValue = GetByRow(rowIndex, a);

                //step3: check whether the rowvalue in the list
                //if already in the list, remove it.
                //the remain number is vaild value.
                if (rowVaildValue.Contains(eachRowValue))
                {
                    rowVaildValue.Remove(eachRowValue);
                }

            }
            return rowVaildValue;
        }

        //feature 5: list vaild value by Column.
        public List<int> VaildValueByColumn(int gridIndex)
        {

            //step1: put all value(1-maxvalue) into list.
            List<int> ColumnVaildValue = new List<int>();
            for (int i = 1; i <= maxValue; i++)
            {
                ColumnVaildValue.Add(i);
            }

            // get the columnIndex
            int columnIndex = gridIndex % maxValue;

            //step2: use get GetByColumn() to get each value of the Column
            for (int a = 0; a < maxValue; a++)
            {
                int eachColumnValue = GetByColumn(columnIndex, a);

                //step3: check whether the rowvalue in the list
                //if already in the list, remove it.
                //the remain number is vaild value.
                if (ColumnVaildValue.Contains(eachColumnValue))
                {
                    ColumnVaildValue.Remove(eachColumnValue);
                }

            }
            return ColumnVaildValue;
        }

        //feature 6: list vaild value by Square.
        public List<int> VaildValueBySquare(int gridIndex)
        {

            //step1: put all value(1-maxvalue) into list.
            List<int> squareVaildValue = new List<int>();

            for (int i = 1; i <= maxValue; i++)
            {
                squareVaildValue.Add(i);
            }

            // get the squareIndex   *****************************incorrect
            //int columnIndex = gridIndex % maxValue;
            //int rowIndex = gridIndex / maxValue;
            // squareIndex = (rowIndex / squareHeight) * squareHeight + columnIndex % squareWidth;

            int squareIndex = 0;
            //use below method to get squreIndex *********************************************************
            for (int i = 0; i < maxValue; i++)
            {
                for (int j = 0; j < maxValue; j++)
                {
                    if ((i * maxValue) + j == gridIndex)
                        squareIndex = i / squareHeight * squareHeight + j / squareWidth;
                }
            }
            //step2: use get GetBySquare() to get each value of the square
            for (int a = 0; a < maxValue; a++)
            {
                int eachSquareValue = GetBySquare(squareIndex, a);

                //step3: check whether the squarevalue in the list
                //if already in the list, remove it.
                //the remain number is vaild value.
                if (squareVaildValue.Contains(eachSquareValue))
                {
                    squareVaildValue.Remove(eachSquareValue);
                }

            }
            return squareVaildValue;
        }

        //feature 7: Input a cell index, return all vaild value.
        public List<int> VaildValueByCell(int gridIndex)
        {
            List<int> VaildValue = new List<int>();

            for (int i = 1; i <= maxValue; i++)
            {
                VaildValue.Add(i);
            }
            List<int> RowVaildValue = VaildValueByRow(gridIndex);
            List<int> ColumnVaildValue = VaildValueByColumn(gridIndex);
            List<int> SquareVaildValue = VaildValueBySquare(gridIndex);

            for (int i = 1; i <= maxValue; i++)
            {
                if (!RowVaildValue.Contains(i))
                {
                    VaildValue.Remove(i);
                }
                if (!ColumnVaildValue.Contains(i))
                {
                    VaildValue.Remove(i);
                }
                if (!SquareVaildValue.Contains(i))
                {
                    VaildValue.Remove(i);
                }

            }
            return VaildValue;
        }

    }
}
