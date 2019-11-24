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
        public int[] sudokuArray;
        

        //Realize interface IGame.
        public void SetMaxValue(int maximum)
        {
            maxValue = maximum;
        }

        // Get max value.
        public int GetMaxValue()
        {
            int Value = sudokuArray[0];
            return Value;
        }

        // CSVstring to Sudoku int array.
        // int[] array1 including maxvalue，squareW/H，cellvalues.
        public int[] ToArray()
        {    
            string defData = "";
            int[] array1;

            for (int i = 0; i < CSVFile.Length; i++)
            {
                if (Char.IsNumber(CSVFile, i) == true)
                {
                    defData += CSVFile.Substring(i, 1);
                }
            }
            array1 = new int[defData.Length];
            for (int i = 0; i < defData.Length; i++)
                array1[i] = Int32.Parse(defData[i].ToString());
            return array1;
        }

        //Get the initial game value, and input to the program 
        public void Set(int[] cellValues)
        {
            sudokuArray = cellValues;
        }
 
        //Set SquareWidth to the program
        public void SetSquareWidth(int Width)
        {
            squareWidth = Width;
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
