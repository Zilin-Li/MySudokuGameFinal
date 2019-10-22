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
        public List<int> defIndexList;

        //Realize interface IGame.
        public void SetMaxValue(int maximum)
        {
            maxValue = maximum;
        }

        //直接从defData提取最大值
        public int GetMaxValue()
        {
            int Value = sudokuArray[0];
            return Value;
        }

        
        public int[] ToArray()//返回含有游戏默认值的int 数组
        {
            //  defData 是用来储存初始游戏数据的字符串。
            string defData = "";

            for (int i = 0; i < CSVFile.Length; i++)
            {
                if (Char.IsNumber(CSVFile, i) == true)
                {
                    defData += CSVFile.Substring(i, 1);
                }
            }

            //全局变量sudokuArray 是包含游戏所有值的数组，包含最大值，squareW/H，以及cellvalue.

            sudokuArray = new int[defData.Length];
            for (int i = 0; i < defData.Length; i++)
                sudokuArray[i] = Int32.Parse(defData[i].ToString());

            return sudokuArray;

        }

        //Get the initial game value, and input to the program 
        public void Set(int[] cellValues)
        {
            sudokuArray = cellValues;
        }

        //直接从defData提取 SquareWidth 
        public int GetSquareWidth()
        {
            int Width = sudokuArray[2];
            return Width;
        }

        //Set SquareWidth to the program
        public void SetSquareWidth(int Width)
        {
            squareWidth = Width;
        }

        //直接从defData提取 SquareHeight 
        public int GetSquareHeight()
        {
            int Height = sudokuArray[1];
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

        public List<int> GetdefIndex(int[] gameArray)
        {
            //defIndexList 是用来记录游戏默认值位置的。
            defIndexList = new List<int>();
            
            for (int i = 3; i < gameArray.Length; i++)
            {
                if (gameArray[i] != 0)
                {
                    defIndexList.Add(i-3);
                }
            }
            return defIndexList;
        }
    }
}
