using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MySudokuGame
{
   
    public class NewSudoku: SudokuGame
    {
        public int seconds, minutes;
        public List<KeyValuePair<string, int>> scoreList;
        public string scoreOutput = "";
        public List<string> historyList = new List<string>();
        public int stepNumber = 0;
        public string stepDetails;
        public int[] X1Index;
        public int[] X2Index;

        // Get button names, like "btn_0_1", trans it to cellindex.
        public int GetButtonInfo(string buttonName)
        {
            string buttonValue = "";
            for (int i = 0; i < buttonName.Length; i++)
            {
                if (Char.IsNumber(buttonName, i) == true)
                {
                    buttonValue += buttonName.Substring(i, 1);
                }
            }

            rowIndex = Int32.Parse(buttonValue[0].ToString());
            colIndex = Int32.Parse(buttonValue[1].ToString());
            cellIndex = colIndex + rowIndex * maxValue;
            return cellIndex;
        }

        // Get default value index information from sudokuarray.
        public List<int> LoadGameInfo(int[] gameArray)
        {
            //defIndexList 是用来记录游戏默认值位置的。
            defIndexList = new List<int>();

            if (defaultInfo == "")
            {
                for (int i = 3; i < gameArray.Length; i++)
                {
                    if (gameArray[i] != 0)
                    {
                        defIndexList.Add(i - 3);
                    }
                }
                seconds = 0;
                minutes = 0;
            }
            else
            {
                defaultInfo = defaultInfo.Replace(",\n", string.Empty);
                int[] nums = Array.ConvertAll(defaultInfo.Split(','), int.Parse);
                defIndexList = nums.ToList();

                timeInfo = timeInfo.Replace(",\r\n", string.Empty);
                int[] time = Array.ConvertAll(timeInfo.Split(','), int.Parse);
                minutes = time[0];
                seconds = time[1];
            }
            return defIndexList;
        }

        // Determines whether a value is a default value。
        public bool IsDefault()
        {
            bool isDef = false;
            if (defIndexList.Contains(cellIndex))
            {
                isDef = true;
            }
            return isDef;     
        }

        // Give a value, find the location of all values that are identical to this value.
        // Return a int list including the value indexes.
        public List<int> GetRepeatNumberIndex(int value)
        {
            List<int> repeatNumList = new List<int>();
            for (int i =3; i < sudokuArray.Length; i++)
            {
                if(sudokuArray[i] == value)
                {
                    repeatNumList.Add(i);
                }
            }
            return repeatNumList;
        }   

        // Check whether a row is complete.
        public bool RowVaild(int rowNumber)
        {
            bool isVaildRow = true;

            int[] rowValue = new int[maxValue];
            // Put every value of the row into an int array.
            // For next step to check.
            for (int i = 0; i < maxValue; i++)
            {
                rowValue[i] = GetByRow(rowNumber, i);
            }

            // Sort the value, the vaild value should be 1~maxValue.
            // If not return false.

            Array.Sort(rowValue);
            for (int a = 0; a < maxValue; a++)
            {
                if (rowValue[a] != a + 1)
                {
                    isVaildRow = false;
                }
            }
            return isVaildRow;
        }

        // Check whether a column is complete.
        public bool ColumnVaild(int columnNumber)
        {
            bool isVaildColumn = true;

            int[] ColumnValue = new int[maxValue];
            // Put each value of the Column into an int array.
            // For next step to check.
            for (int i = 0; i < maxValue; i++)
            {
                ColumnValue[i] = GetByColumn(columnNumber, i);
            }

            // Sort the value, the vaild value should be 1~maxValue.
            // If not return false.

            Array.Sort(ColumnValue);
            for (int a = 0; a < maxValue; a++)
            {
                if (ColumnValue[a] != a + 1)
                {
                    isVaildColumn = false;
                }
            }
            return isVaildColumn;
        }

        // Check whether a square is complete.
        public bool SquareVaild(int squareNumber)
        {
            bool isVaildSquare = true;

            int[] SquareValue = new int[maxValue];
            //put every value of the Square into an int array.
            //for next step to check
            for (int i = 0; i < maxValue; i++)
            {
                SquareValue[i] = GetBySquare(squareNumber, i);
            }
            //sort the value, the vaild value should be 1~maxValue.
            //if not return false.

            Array.Sort(SquareValue);
            for (int a = 0; a < maxValue; a++)
            {
                if (SquareValue[a] != a + 1)
                {
                    isVaildSquare = false;
                }
            }
            return isVaildSquare;
        }

        // XSudoku Index array
        public int[] GetX1Index()
        {
            X1Index = new int[maxValue];
            for (int i = 0; i < maxValue; i++)
            {
                X1Index[i] = maxValue * i + i;
            }
            return X1Index;
        }
        // XSudoku Index array
        public int[] GetX2Index()
        {
            X2Index = new int[maxValue];
            for (int i = 1; i <= maxValue; i++)
            {
                X2Index[i - 1] = maxValue * i - i;
            }
            return X2Index;
        }

        // Xsudoku
        // Check whether the X1 complete.
        public bool X1Vaild()
        {
            bool isVaildX1 = true;
            int[] X1Value = new int[maxValue];
            //put every value of the Square into an int array.
            //for next step to check
            for (int i = 0; i < maxValue; i++)
            {
                X1Value[i] = GetCell(X1Index[i]);
            }
            //sort the value, the vaild value should be 1~maxValue.
            //if not return false.
            Array.Sort(X1Value);
            for (int a = 0; a < maxValue; a++)
            {
                if (X1Value[a] != a + 1)
                {
                    isVaildX1 = false;
                }
            }
            return isVaildX1;
        }

        // Xsudoku
        // Check whether the X2 complete.
        public bool X2Vaild()
        {
            bool isVaildX2 = true;
            int[] X2Value = new int[maxValue];
            //put every value of the Square into an int array.
            //for next step to check
            for (int i = 0; i < maxValue; i++)
            {
                X2Value[i] = GetCell(X2Index[i]);
            }
            //sort the value, the vaild value should be 1~maxValue.
            //if not return false.
            Array.Sort(X2Value);
            for (int a = 0; a < maxValue; a++)
            {
                if (X2Value[a] != a + 1)
                {
                    isVaildX2 = false;
                }
            }
            return isVaildX2;
        }

        // Check whether the game complete.
        // Except for x sudoku 
        public bool AllVaild()
        {
            bool isAllVaild = true;
            for(int a = 0; a < maxValue; a++)
            {
                if (!RowVaild(a))
                {
                    isAllVaild = false;
                    return isAllVaild;
                }
                if (!ColumnVaild(a))
                {
                    isAllVaild = false;
                    return isAllVaild;
                }
                if (!SquareVaild(a))
                {
                    isAllVaild = false;
                    return isAllVaild;
                }
            }
            return isAllVaild;
        }

        // XSudoku
        // Check whether the game complete.
        public bool XGameAllVaild()
        {
            bool isXAllVaild = false;

            if (AllVaild() && X1Vaild() && X2Vaild())
            {
                isXAllVaild = true;
            }          
            return isXAllVaild;
        }

        // List all possible values of the row.
        public List<int> VaildValueByRow(int gridIndex)
        {
            //step1: put all value(1-maxvalue) into list.
            List<int> rowVaildValue = new List<int>();
            for (int i = 1; i <= maxValue; i++)
            {
                rowVaildValue.Add(i);
            }
            // get the rowIndex
            int rowIndex = gridIndex / maxValue;

            //step2: use get GetByRow() to get each value of the row
            for (int a = 0; a < maxValue; a++)
            {
                int eachRowValue = GetByRow(rowIndex, a);

                //step3: check whether the rowvalue in the list
                //if already in the list, remove it.
                //the remain number is vaild value.
                if (rowVaildValue.Contains(eachRowValue))
                {
                    rowVaildValue.Remove(eachRowValue);
                }
            }
            return rowVaildValue;
        }
        // List all possible values of the Column.
        public List<int> VaildValueByColumn(int gridIndex)
        {
            //step1: put all value(1-maxvalue) into list.
            List<int> ColumnVaildValue = new List<int>();
            for (int i = 1; i <= maxValue; i++)
            {
                ColumnVaildValue.Add(i);
            }
            // get the columnIndex
            int columnIndex = gridIndex % maxValue;

            //step2: use get GetByColumn() to get each value of the Column
            for (int a = 0; a < maxValue; a++)
            {
                int eachColumnValue = GetByColumn(columnIndex, a);

                //step3: check whether the rowvalue in the list
                //if already in the list, remove it.
                //the remain number is vaild value.
                if (ColumnVaildValue.Contains(eachColumnValue))
                {
                    ColumnVaildValue.Remove(eachColumnValue);
                }
            }
            return ColumnVaildValue;
        }

        // List all possible values of the Square.
        public List<int> VaildValueBySquare(int gridIndex)
        {
            //step1: put all value(1-maxvalue) into list.
            List<int> squareVaildValue = new List<int>();
            for (int i = 1; i <= maxValue; i++)
            {
                squareVaildValue.Add(i);
            }
            int squareIndex = 0;
            for (int i = 0; i < maxValue; i++)
            {
                for (int j = 0; j < maxValue; j++)
                {
                    if ((i * maxValue) + j == gridIndex)
                        squareIndex = i / squareHeight * squareHeight + j / squareWidth;
                }
            }
            //step2: use get GetBySquare() to get each value of the square
            for (int a = 0; a < maxValue; a++)
            {
                int eachSquareValue = GetBySquare(squareIndex, a);

                //step3: check whether the squarevalue in the list
                //if already in the list, remove it.
                //the remain number is vaild value.
                if (squareVaildValue.Contains(eachSquareValue))
                {
                    squareVaildValue.Remove(eachSquareValue);
                }
            }
            return squareVaildValue;
        }

        public List<int> VaildValueByX1()
        {
            List<int> X1VaildValue = new List<int>();

            for (int i = 1; i <= maxValue; i++)
            {
                X1VaildValue.Add(i);
            }
            for (int a = 0; a < maxValue; a++)
            {
                int eachX1Value = GetCell(X1Index[a]);
                if (X1VaildValue.Contains(eachX1Value))
                {
                    X1VaildValue.Remove(eachX1Value);
                }
            }
            return X1VaildValue;
        }

        public List<int> VaildValueByX2()
        {
            List<int> X2VaildValue = new List<int>();

            for (int i = 1; i <= maxValue; i++)
            {
                X2VaildValue.Add(i);
            }
            for (int a = 0; a < maxValue; a++)
            {
                int eachX2Value = GetCell(X2Index[a]);
                if (X2VaildValue.Contains(eachX2Value))
                {
                    X2VaildValue.Remove(eachX2Value);
                }
            }
            return X2VaildValue;
        }


        // List all possible values of a cell.
        public List<int> VaildValueByCell(int gridIndex)
        {
            List<int> VaildValue = new List<int>();

            for (int i = 1; i <= maxValue; i++)
            {
                VaildValue.Add(i);
            }
            List<int> RowVaildValue = VaildValueByRow(gridIndex);
            List<int> ColumnVaildValue = VaildValueByColumn(gridIndex);
            List<int> SquareVaildValue = VaildValueBySquare(gridIndex);

            for (int i = 1; i <= maxValue; i++)
            {
                if (!RowVaildValue.Contains(i))
                {
                    VaildValue.Remove(i);
                }
                if (!ColumnVaildValue.Contains(i))
                {
                    VaildValue.Remove(i);
                }
                if (!SquareVaildValue.Contains(i))
                {
                    VaildValue.Remove(i);
                }

            }
            return VaildValue;
        }

        // Get game score when game complete.
        public int GetScore(int min, int sec)
        {    
            int gameScore;
            gameScore = (int)((1.0 / (min * 60 + sec)) * 100000 * maxValue);  
            return gameScore;
        }


        // Step 1: Get User name and score.
        // Step 2: Read history score frome file.
        // Step 3: Sort all scores.
        // Step 4: Write top 5 score to file.
        public string AddScore(string name, int score)
        {
            scoreOutput = "";
            scoreList = new List<KeyValuePair<string, int>>();
            StreamReader sr = new StreamReader("HistoryScoreLists.txt");
            //Read the first line of text
            String line = sr.ReadLine();
            //Continue to read until you reach end of file
            while (line != ""&& line != null)
            {              
                string[] results = line.Split(',');
               
                scoreList.Add(new KeyValuePair<string, int>(results[0], Int32.Parse(results[1])));
                //Read the next line
                line = sr.ReadLine();
            }
            sr.Close();
            if (scoreList.Count < 5)
            {
                scoreList.Add(new KeyValuePair<string, int>(name, score));          
            }
            else
            {
                if(scoreList[scoreList.Count-1].Value < score)
                {
                    scoreList.RemoveAt(scoreList.Count-1);
                    scoreList.Add(new KeyValuePair<string, int>(name, score));
                }
            }
            scoreList.Sort((x, y) => (y.Value.CompareTo(x.Value)));

            TextWriter tw = new StreamWriter("HistoryScoreLists.txt");
            foreach (var value in scoreList)
            {
                scoreOutput += (value.Key + " : " + value.Value + "\n");          
                tw.WriteLine(value.Key + "," + value.Value);          
            }
            tw.Close();
            return scoreOutput;
        }

        // Record the steps.
        public void RecordStep(int cellvalue)
        {
            string indexNumber = cellIndex.ToString();
            string oldNumber = GetCell(cellIndex).ToString();
            string newNumber = cellvalue.ToString();
            while (historyList.Count > stepNumber)
            {
                historyList.RemoveAt(historyList.Count - 1);
            }

            historyList.Add(indexNumber + "," + oldNumber + "," + newNumber);
            stepNumber = historyList.Count;
        }

        // Undo by step.
        public void Undo()
        {
            if (historyList.Count > 0 && stepNumber >= 1)
            {
                stepDetails = historyList[stepNumber - 1];
                string[] info = stepDetails.Split(',');
                int index = Int32.Parse(info[0]);
                int oldnumber = Int32.Parse(info[1]);
                //int newNumber = Int32.Parse(info[2]);
                SetCell(oldnumber, index);
                stepNumber--; 
            }
        }

        // Redo by step.
        public void Redo()
        {
            if (historyList.Count > stepNumber)
            {
                stepDetails = historyList[stepNumber];
                string[] info = stepDetails.Split(',');
                var index = Int32.Parse(info[0]);
                //var oldnumber = Int32.Parse(info[1]);
                var newNumber = Int32.Parse(info[2]);
                SetCell(newNumber, index);
                stepNumber++;      
            }
        }

       






    }
}
