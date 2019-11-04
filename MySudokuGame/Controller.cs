using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySudokuGame
{
    public class Controller
    {
        protected IView view;
        protected SudokuGame game;
        public List<int[]> sudokuList;

        public int maxValue, SquareHeight, SquareWidth;
        public string sudokuString;
        //public int rowIndex, colIndex, cellIndex;
      
        //public string vaildValue;
        public int[] sudokuArray;
        public List<int> defIndexList;

        public Controller(IView theView, SudokuGame theGame)
        {
            view = theView;
            view.SetController(this);
            game = theGame;
        }

        public void InitGameData()
        {
            string CSVFile = "";
            // 2 by 2 file
            CSVFile = "4,2,2" + '\n';
            CSVFile += ("1,0,3,4,2,3,0,1,0,4,1,2,0,1,2,0" + '\n');

            // section 2 high by 3 wide file
            //CSVFile = "6,2,3" + '\n';
            //CSVFile += ("0,0,3,4,5,6,0,3,4,5,6,1,0,4,5,6,1,2,0,5,6,1,2,3,5,0,1,2,3,4,6,1,2,3,0,0" + '\n');

            // section 3 high by 2 wide file
            //CSVFile = "6,3,2" + '\n';
            //CSVFile += ("0,0,3,4,5,6,0,3,4,5,6,1,0,4,5,6,1,2,0,5,6,1,2,3,5,0,1,2,3,4,6,1,2,3,0,0" + '\n');

            // 3 by 3 file
            //CSVFile = "9,3,3" + '\n';
            //CSVFile += ("0,0,3,4,5,6,7,8,9,2,3,4,5,6,7,8,9,1,3,4,5,6,7,8,9,1,2,4,5,6,7,8,9,1,2,3,5,6,7,8,9,1,2,3,4,6,7,8,9,1,2,3,4,5,7,8,9,1,2,3,4,5,6,8,9,1,2,3,4,5,6,7,9,1,2,3,4,5,6,7,8" + '\n');

            game.FromCSV(CSVFile);
            sudokuArray = game.ToArray();

            maxValue = game.GetMaxValue();
            SquareHeight = game.GetSquareHeight();
            SquareWidth = game.GetSquareWidth();
            defIndexList = game.GetdefIndex(sudokuArray);
            
            sudokuString = game.ToPrettyString();

            game.SetMaxValue(maxValue);
            game.SetSquareHeight(SquareHeight);
            game.SetSquareWidth(SquareWidth);
            game.Set(sudokuArray);
        }

        public void ChangeValue(string value, string buttonName)
        {
            int cellvalue;
            game.GetButtonInfo(buttonName);
            if (!game.IsDefault())
            {
                if (value == "")
                {
                    cellvalue = 0;
                }
                else
                {
                    cellvalue = int.Parse(value);
                }
                game.SetCell(cellvalue, game.cellIndex);
                sudokuString = game.ToPrettyString();
            }
           

        }

    }
}
