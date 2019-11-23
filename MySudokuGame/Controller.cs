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
        public int maxValue, SquareHeight, SquareWidth;
        public int seconds, minutes;
        public string sudokuString;    
        public int[] sudokuArray;
        public int[] X1Index;
        public int[] X2Index;
        public List<int> defIndexList;
        public string test;

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

        // Initialize the game.
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
            X1Index = game.GetX1Index();
            X2Index = game.GetX2Index();
        }

        // When user click game buttons, determines whether the game value can be changed.
        // If the value clicked is not the default value, change the game value.
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

                game.RecordStep(cellvalue);


                game.SetCell(cellvalue, game.cellIndex);
                // Record the number of steps played and the value changed.


                
                sudokuString = game.ToPrettyString();

            }
        }

        // Undo
        public void Undo()
        {
            game.Undo();
            sudokuString = game.ToPrettyString();
            view.GameValueDisplay(sudokuString);
        }
       
        // Redo
        public void Redo()
        {
            game.Redo();
            sudokuString = game.ToPrettyString();
            view.GameValueDisplay(sudokuString);
        }

        // If the user selects a cell value of 0, return "showVaildValue".
        // If the user selects a cell value of non-0, return "showRepeatNumber".
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

        // Return a list including all possible values of the cell.
        public List<int> HintForVaildValue(string buttonName)
        {
            return game.VaildValueByCell(game.GetButtonInfo(buttonName));
            //return game.XVaildByCell(game.GetButtonInfo(buttonName));
        }

        // Return a list including all RepeatNumber's index.
        public List<int> HintForRepeatNumber(string buttonName)
        {
            int cellIndex = game.GetButtonInfo(buttonName);
            int cellValue = game.GetCell(cellIndex);

            return game.GetRepeatNumberIndex(cellValue);
        }

        // Check whether a row completed.
        public bool CheckRowVaild(int row)
        {
            return game.RowVaild(row);
        }

        // Check whether a column completed.
        public bool CheckColVaild(int col)
        {
            return game.ColumnVaild(col);
        }

        // Check whether a square completed.
        public bool CheckSquareVaild(int cellindex)
        {
            return game.SquareVaild(cellindex);
        }

        // Check whether the game completed.
        // Except for X sudoku.
        public bool CheckAllVaild()
        {
            return game.AllVaild();
        }

        // Check whether X1 completed.
        public bool CheckX1Vaild()
        {
            return game.X1Vaild();
        }
        // Check whether X2 completed.
        public bool CheckX2Vaild()
        {
            return game.X2Vaild();
        }

        // Check whether the X sudoku game completed.

        public bool CheckXAllVaild()
        {
            return game.XGameAllVaild();
        }

        // Calculate game score.
        public int GetGameScore(int min, int sec)
        {
            return game.GetScore(min, sec);
        }

        // Get Top 5 score.
        public string ScoreList(string name, int score)
        {
            return game.AddScore(name, score);
        }

        // Save the game
        // Including game values , default information and time information.
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

    }
}
