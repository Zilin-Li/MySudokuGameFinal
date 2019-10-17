using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace MySudokuGame
{
    public partial class SudokuGame : ISerialize
    {

        public string CSVFile;
        public string PrettyString;
        public int cellValue;


        //Realize interface ISerialize

        //Load the game value from a CSV file
        public void FromCSV(string csv)
        {

            CSVFile = csv;
        }

        //the function to save the game;
        //change the current sudoku array to CSVfile(a string)
        public string ToCSV()
        {
            string saveFile = "";
            for (int i = 0; i < sudokuArray.Length; i++)
            {
                saveFile += sudokuArray[i] + ",";
            }
            saveFile += '\n';

            var csv = new StringBuilder();
            csv.AppendLine(saveFile);
            //get current working directory
            string path = Directory.GetCurrentDirectory();
            string filePath = path + "/mysudoku.csv";
            File.WriteAllText(filePath, csv.ToString());
            return saveFile;
        }

        //Set a value by cell
        public void SetCell(int value, int gridIndex)
        {
            if (value >= 0 && value <= maxValue && gridIndex >= 0 && gridIndex < maxValue * maxValue)
            {
                sudokuArray[gridIndex] = value;
            }
            else
            {
                Console.WriteLine("Out of range");
            }

        }

        //Get a value by cell
        public int GetCell(int gridIndex)
        {
            if (gridIndex >= 0 && gridIndex < maxValue * maxValue)
            {
                cellValue = sudokuArray[gridIndex];
            }

            else
            {
                cellValue = 0;
            }

            return cellValue;
        }

        // To dispaly a game board
        public string ToPrettyString()
        {
            PrettyString = "";
            for (int i = 0; i < maxValue * maxValue; i++)
            {
                //cellArray[i] = 7;
                if ((i + 1) % maxValue == 0)
                {
                    PrettyString += " " + sudokuArray[i].ToString();
                    PrettyString += "\n";
                }
                else
                {
                    if ((i + 1) % squareWidth == 0)
                    {
                        PrettyString += " " + sudokuArray[i].ToString() + " |";
                    }
                    else
                    {
                        PrettyString += " " + sudokuArray[i].ToString();
                    }
                }

                if ((i + 1) % (squareHeight * maxValue) == 0 && (i + 1) % (maxValue * maxValue) != 0)
                {
                    for (int j = 0; j < maxValue / squareWidth; j++)
                    {
                        for (int k = 0; k < squareWidth * 2 + 1; k++)
                        {
                            PrettyString += "-";
                        }
                        if (j != maxValue / squareWidth - 1)
                        {
                            PrettyString += "+";
                        }
                    }
                    PrettyString += "\n";
                }
            }
            PrettyString = PrettyString.Replace('0', '*');
            return PrettyString;
        }
    }
}


