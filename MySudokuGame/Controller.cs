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
        protected NewSudoku game;
        public string test;
        public int maxValue, SquareHeight, SquareWidth;
        public int seconds, minutes;
        public int numOfArchiving = 1;
        public string sudokuString;
   
       
        public int[] sudokuArray;
        public List<int> defIndexList;


        public List<string> historyList = new List<string>();
        public int stepNumber = 0;
        public string stepDetails;

        public Controller(IView theView, NewSudoku theGame)
        {
            view = theView;
            view.SetController(this);
            game = theGame;
        }
        public void GameSelect(string gameselect)
        {
            game.FromCSV(gameselect);
        }

        // Save the game: game values , default information and time information.
        public string GameSave(int second, int min)
        {
            string filePath;
            string mess;
            string timelog;
            //Form send time info through parameters to controller.
            timelog = '\n' + "T," + min + "," + second;

            var csv = new StringBuilder();
            csv.AppendLine(game.ToCSV() + timelog);
            string path = Directory.GetCurrentDirectory();
            DateTime now = DateTime.Now;
            mess = "1";
            filePath = path + @"\loadGame\" + mess + ".csv";
            File.WriteAllText(filePath, csv.ToString());
            return filePath;
        } 

        // 游戏初始化
        public void InitGameData()
        {
            sudokuArray = game.ToArray();
            game.Set(sudokuArray);
            maxValue = game.GetMaxValue();
            SquareHeight = sudokuArray[1];
            SquareWidth = sudokuArray[2];
            defIndexList = game.LoadGameInfo(sudokuArray);
            seconds = game.seconds;
            minutes = game.minutes;
            sudokuString = game.ToPrettyString();
            game.SetMaxValue(maxValue);
            game.SetSquareHeight(SquareHeight);
            game.SetSquareWidth(SquareWidth);
            test = game.defaultInfo;
            
        }

        // 改变游戏值
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

                string indexNumber = game.cellIndex.ToString();
                string oldNumber = game.GetCell(game.cellIndex).ToString();
                string newNumber = cellvalue.ToString();

              

                historyList.Add(indexNumber + "," + oldNumber + "," + newNumber);

                stepNumber = historyList.Count;
                game.SetCell(cellvalue, game.cellIndex);
                sudokuString = game.ToPrettyString();

            }
        }


        public void undo()
        {
            if (historyList.Count > 0 && stepNumber >= 1)
            {
                stepDetails = historyList[stepNumber - 1];
                string[] info = stepDetails.Split(',');
                var index = Int32.Parse(info[0]);
                var oldnumber = Int32.Parse(info[1]);
                var newNumber = Int32.Parse(info[2]);
                game.SetCell(oldnumber, index);
                stepNumber--;

                sudokuString = game.ToPrettyString();
                view.GameValueDisplay(sudokuString);
            }

        }

        public void redo()
        {
            if (historyList.Count > stepNumber)
            {
                stepDetails = historyList[stepNumber];
                string[] info = stepDetails.Split(',');
                var index = Int32.Parse(info[0]);
                var oldnumber = Int32.Parse(info[1]);
                var newNumber = Int32.Parse(info[2]);
                game.SetCell(newNumber, index);
                stepNumber++;
                sudokuString = game.ToPrettyString();
                view.GameValueDisplay(sudokuString);
            }
        }




        public string SelectPromptMethod(string buttonName)
        {
            string promptMethod;
            int cellIndex = game.GetButtonInfo(buttonName);
            int cellValue = game.GetCell(cellIndex);
            if(cellValue != 0)
            {
                promptMethod = "showRepeatNumber";
            }
            else
            {
                promptMethod = "showVaildValue";
            }
            return promptMethod;

        }
        public List<int> HintForVaildValue(string buttonName)
        {
            return game.VaildValueByCell(game.GetButtonInfo(buttonName));
        }

        public List<int> HintForRepeatNumber(string buttonName)
        {
            int cellIndex = game.GetButtonInfo(buttonName);
            int cellValue = game.GetCell(cellIndex);

            return game.GetRepeatNumberIndex(cellValue);
        }

        // check row col square vaild.
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

        // Get Score

        public int GetGameScore(int min, int sec)
        {
            return game.GetScore(min, sec);
        }

        public string ScoreList(string name, int score)
        {
            return game.AddScore(name, score);
        }





    }
}
