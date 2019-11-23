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
        public string defaultInfo,timeInfo;
        public List<int> defIndexList;


        //Realize interface ISerialize

        //Load the game value from a CSV file
        public void FromCSV(string gameselect)
        {
            string path = System.AppDomain.CurrentDomain.BaseDirectory;
            string fileName = "";
            
            int index1,index2;

            fileName = path + gameselect;
      
            StreamReader sr = new StreamReader(fileName, System.Text.Encoding.Default);
            String ls_input = sr.ReadToEnd().TrimStart();
            if (!string.IsNullOrEmpty(ls_input))
            {
                CSVFile = ls_input;
            }
            sr.Close();

            // check new game or load game
  
            defaultInfo = "";
            index1 = CSVFile.IndexOf('#');
            index2 = CSVFile.IndexOf('T');
            if (index1 != -1)
            {
                timeInfo = CSVFile.Substring(index2 + 2);
                defaultInfo = CSVFile.Substring(index1+2, index2-(index1 + 2));
                CSVFile = CSVFile.Substring(0, index1);  
            }       
        }

        // Trans the game value and dafault number information into CSV format string;
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
            return saveFile;
        }

        //Set a value by cell
        public void SetCell(int value, int gridIndex)
        {
            sudokuArray[gridIndex+3] = value;  
        }

        //Get a value by cell
        public int GetCell(int gridIndex)
        {        
            cellValue = sudokuArray[gridIndex+3];

            return cellValue;
        }

        // Trans sudokuArray to string.
        // Do not including the max value, Height, Weight.
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


