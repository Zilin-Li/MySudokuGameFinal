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
        public string defaultInfo;


        //Realize interface ISerialize

        //Load the game value from a CSV file
        public void FromCSV(string gameselect)
        {
            string path = System.AppDomain.CurrentDomain.BaseDirectory;
            string fileName = "";
            
            int index1;

            fileName = path + gameselect;
      
            StreamReader sr = new StreamReader(fileName, System.Text.Encoding.Default);
            String ls_input = sr.ReadToEnd().TrimStart();
            if (!string.IsNullOrEmpty(ls_input))
            {
                CSVFile = ls_input;
            }

            sr.Close();

            // check new game or load game
            // ref: https://www.geeksforgeeks.org/c-sharp-string-indexof-method-set-1/

            defaultInfo = "";
            index1 = CSVFile.IndexOf('#');
            if (index1 != -1)
            {
                defaultInfo = CSVFile.Substring(index1+2);
                CSVFile = CSVFile.Substring(0, index1);  
            }
         
        }

        //the function to save the game;
        public string ToCSV()
        {
            string saveFile = "";
            for (int i = 0; i < sudokuArray.Length; i++)
            {
                saveFile += sudokuArray[i] + ",";
            }
            saveFile += '\n' + "#,";

        
            for(int d = 0; d < defIndexList.Count; d++)
            {
                saveFile += defIndexList[d] + ",";
            }
            //saveFile += '\n';
            return saveFile;
        }

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


