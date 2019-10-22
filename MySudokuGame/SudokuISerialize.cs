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
        //public string ToCSV()
        //{
        //    string saveFile = "";
        //    for (int i = 0; i < sudokuArray.Length; i++)
        //    {
        //        saveFile += sudokuArray[i] + ",";
        //    }
        //    saveFile += '\n';

        //    var csv = new StringBuilder();
        //    csv.AppendLine(saveFile);
        //    //get current working directory
        //    string path = Directory.GetCurrentDirectory();
        //    string filePath = path + "/mysudoku.csv";
        //    File.WriteAllText(filePath, csv.ToString());
        //    return saveFile;
        //}

        //Set a value by cell
        public void SetCell(int value, int gridIndex)
        {
            if (value >= 0 && value <= maxValue && gridIndex >= 0 && gridIndex < maxValue * maxValue)
            {
                sudokuArray[gridIndex+3] = value;
            }
            
        }

        ////Get a value by cell
        //public int GetCell(int gridIndex)
        //{
        //    if (gridIndex >= 0 && gridIndex < maxValue * maxValue)
        //    {
        //        cellValue = sudokuArray[gridIndex];
        //    }
        //    else
        //    {
        //        cellValue = 0;
        //    }
        //    return cellValue;
        //}



        //这个功能是用来把sudokuArray的数据转变成string格式的
        public string ToPrettyString()
        {
            PrettyString = "";

            for (int i = 3; i < sudokuArray.Length; i++)
            {             
                PrettyString += sudokuArray[i];                
            }
            return PrettyString;
        }

    }
}


