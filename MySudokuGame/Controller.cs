using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MySudokuGame
{
    public class Controller
    {
        protected IView view;
        protected SudokuGame game;
        // public List<int[]> sudokuList;
        public string test;

        public int maxValue, SquareHeight, SquareWidth;
        public int numOfArchiving = 1;
        public string sudokuString;
       
        public int[] sudokuArray;
        public List<int> defIndexList;

        public Controller(IView theView, SudokuGame theGame)
        {
            view = theView;
            view.SetController(this);
            game = theGame;
        }
        public void GameSelect(string gameselect)
        {
            game.FromCSV(gameselect);
        }

        public string GameSave()
        {
            string filePath;
            string mess;

            var csv = new StringBuilder();
            csv.AppendLine(game.ToCSV());

            string path = Directory.GetCurrentDirectory();

            //Directory.CreateDirectory(path);
            DateTime now = DateTime.Now;
            mess = "1";
            filePath = path + @"\loadGame\" + mess + ".csv";
            File.WriteAllText(filePath, csv.ToString());
            return filePath;
        } 
        public void InitGameData()
        {
            sudokuArray = game.ToArray();
            game.Set(sudokuArray);
            maxValue = game.GetMaxValue();
            SquareHeight = game.GetSquareHeight();
            SquareWidth = game.GetSquareWidth();
            defIndexList = game.GetdefIndex(sudokuArray);           
            sudokuString = game.ToPrettyString();
            game.SetMaxValue(maxValue);
            game.SetSquareHeight(SquareHeight);
            game.SetSquareWidth(SquareWidth);
            test = game.defaultInfo;
            
        }

        //public void GetDefIndex(string defInfo="")
        //{
        //    if(defInfo == "")
        //    {
        //        defIndexList = game.GetdefIndex(sudokuArray);
        //    }
        //    else
        //    {
        //        for(int i = 0; i < defInfo.Length; i++)
        //        {
        //            defIndexList.Add(defInfo[i]);
        //        }
        //    }
            
        //}


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

        public bool CheckRowVaild(int row)
        {
            return game.RowVaild(row);
        }
        public bool CheckColVaild(int col)
        {
            return game.ColumnVaild(col);
        }
        public bool CheckSquareVaild(int cellindex)
        {
            return game.SquareVaild(cellindex);
        }

        public bool CheckAllVaild()
        {
            return game.AllVaild();
        }



    }
}
