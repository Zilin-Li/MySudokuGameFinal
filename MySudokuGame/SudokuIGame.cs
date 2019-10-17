using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySudokuGame
{
    public partial class SudokuGame : IGame
    {
        public int maxValue;
        public int squareHeight;
        public int squareWidth;
        public int[] sudokuArray, CSVArray;

        //Realize interface IGame.
        public void SetMaxValue(int maximum)
        {
            maxValue = maximum;
        }

        //Get max value from CSVArray
        public int GetMaxValue()
        {
            int Value = CSVArray[0];
            return Value;
        }

        //We get a string "CSVFile", Which including ',' and '\n'
        //This function to change the string to an int[]
        public int[] ToArray()
        {
            //trans the CSVFile into a string which only including cellvalue.
            string cellValueStr = "";
            for (int i = 0; i < CSVFile.Length; i++)
            {
                if (Char.IsNumber(CSVFile, i) == true)
                {
                    cellValueStr += CSVFile.Substring(i, 1);
                }
            }
            // put the cellvalue into a int array.

            CSVArray = new int[cellValueStr.Length];
            for (int i = 0; i < cellValueStr.Length; i++)
                CSVArray[i] = Int32.Parse(cellValueStr[i].ToString());

            return CSVArray;
        }

        //Get the initial game value, and input to the program 
        public void Set(int[] cellValues)
        {
            sudokuArray = new int[maxValue * maxValue];

            for (int i = 0; i < maxValue * maxValue; i++)
            {
                sudokuArray[i] = cellValues[i + 3];
            }

        }

        //Get SquareWidth from CSVArray
        public int GetSquareWidth()
        {
            int Width = CSVArray[2];
            return Width;
        }

        //Set SquareWidth to the program
        public void SetSquareWidth(int Width)
        {
            squareWidth = Width;
        }

        //Get SquareHeight from CSVArray
        public int GetSquareHeight()
        {
            int Height = CSVArray[1];
            return Height;
        }

        //Set SquareHeight to the program
        public void SetSquareHeight(int Height)
        {
            squareHeight = Height;
        }

        //Restart the game.
        public void Restart()
        {
            this.Set(this.ToArray());

        }

    }
}
