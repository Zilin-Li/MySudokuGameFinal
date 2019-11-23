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

    public partial class FormMain : Form, IView
    {
        private Controller theController;
        private string ClickedText = "";
        private string gameSelect;
        private int timeTicks = 0;
        private int seconds;
    
        private int minutes = 0;


        public FormMain()
        {
            InitializeComponent();
        }
        public void SetController(Controller contr)
        {
            theController = contr;
        }

        //------------------------------------ Create Controls -----------------------------------------

        // Creat game scale, in order to dispaly row number and col number.
        public void MakeGameScale(string name, int num, int row, int column)
        {
            TextBox textNew = new TextBox();
            textNew.Name = name + num.ToString();
            textNew.Height = 50;
            textNew.Width = 50;
            textNew.Font = new Font("Microsoft Sans Serif", 16);
            textNew.Text = num.ToString();
            textNew.TextAlign = HorizontalAlignment.Center;

            textNew.BorderStyle = BorderStyle.None;
            textNew.Location = new Point(50 + 50 * column, 50 + 52 * row);
            GameBoard.Controls.Add(textNew);
        }


        // Creat number buttons.
        public void MakeButtons(string text, int num)
        {
            Button btnNew = new Button();
            btnNew.Name = "iptBtn_" + text;
            btnNew.Height = 50;
            btnNew.Width = 50;
            btnNew.Font = new Font("Arial", 20);
            //btnNew.Text = text;
            btnNew.Visible = true;
            btnNew.Location = new Point(50 + 50 * num, 150 + 50 * theController.maxValue);
            btnNew.BackColor = Color.White;
            GameBoard.Controls.Add(btnNew);
        }

        // Create game buttons.
        public void MakeButtons2(string name, string text, int row, int column)
        {
            int squareIndex;
            squareIndex = row / theController.SquareHeight * theController.SquareHeight + column / theController.SquareWidth;

            Button btnNew = new Button();
            btnNew.Name = name + row.ToString() + "_" + column.ToString();
            btnNew.Height = 50;
            btnNew.Width = 50;
            btnNew.Font = new Font("Arial", 20);
            btnNew.Text = text;
            btnNew.Visible = true;

            btnNew.Location = new Point(100 + 50 * column, 100 + 50 * row);
            if (theController.maxValue == 4)
            {
                if (squareIndex == 0 || squareIndex == 3)
                    btnNew.BackColor = Color.LightBlue;
            }
            if (theController.maxValue == 6)
            {
                if (squareIndex == 0 || squareIndex == 3 || squareIndex == 4)
                    btnNew.BackColor = Color.LightBlue;
            }
            if (theController.maxValue == 9)
            {
                if (squareIndex % 2 == 0)
                    btnNew.BackColor = Color.LightBlue;
            }
            GameBoard.Controls.Add(btnNew);
        }

        // Add click event to each button on GameBoard.
        public void SetClicks()
        {
            foreach (Control c in GameBoard.Controls)
            {
                if (c is Button)
                {
                    Button who = c as Button;
                    who.Click += new EventHandler(WhoClicked);
                }
            }
        }

        // Game buttons click event.
        public void WhoClicked(object sender, EventArgs e)
        {
            Button btnWho = sender as Button;
            Text = btnWho.Name;

            if (btnWho.Name.StartsWith("btn"))
            {
                if (ClickedText == "?")
                {
                    string promptMethod;
                    promptMethod = theController.SelectPromptMethod(btnWho.Name);
                    if (promptMethod == "showVaildValue")
                    {
                        HintVaildValue(theController.HintForVaildValue(btnWho.Name));
                        for (int i = 0; i < theController.maxValue * theController.maxValue; i++)
                        {
                            int colInd = i % theController.maxValue;
                            int rowInd = i / theController.maxValue;
                            ClearGameBoard(colInd, rowInd);
                        }
                    }
                    if (promptMethod == "showRepeatNumber")
                    {
                        HintRepeatNumber(theController.HintForRepeatNumber(btnWho.Name));
                        ClearNumberBoard();
                    }
                }
                else
                {
                    theController.ChangeValue(ClickedText, btnWho.Name);
                    ClearNumberBoard();
                    GameValueDisplay(theController.sudokuString);
                    VaildAreaDisplay();

                    //VaildXDisplay();
                    WinInfoDisplay();
                
                }
            }
            else if (btnWho.Name.StartsWith("iptBtn_"))
            {
                ClickedText = btnWho.Text;
            }
        }

        //Create game timer
        private void Mytime_Tick(object sender, EventArgs e)
        {
            timeTicks++;
            seconds = theController.seconds;
            minutes = theController.minutes;
            seconds += (timeTicks / 10) % 60;
            minutes += (timeTicks / 10 / 60) % 60;
            TimeBox.Text = minutes.ToString("00") + " : " + seconds.ToString("00");
        }

        // Display gameboard.
        public void GameBoardDisplay()
        {
            string cellValueS = "";
            for (int row = 0; row < theController.maxValue; row++)
            {
                for (int col = 0; col < theController.maxValue; col++)
                {
                    if (row == 0)
                    {
                        MakeGameScale("Col_", col + 1, row, col + 1);
                    }
                    if (col == 0)
                    {
                        MakeGameScale("Row_", row + 1, row + 1, col);
                    }

                    MakeButtons2("btn_", cellValueS, row, col);
                }
            }
            for (int i = 0; i <= theController.maxValue + 1; i++)
            { 
                MakeButtons((i+1).ToString(), i);    
            }
        }

        // Display sudoku value on the board.
        public void GameValueDisplay(string gameDataString)
        {
            string btnName;
            string cellValueS;

            for (int row = 0; row < theController.maxValue; row++)
            {
                for (int col = 0; col < theController.maxValue; col++)
                {
                    int cellIndex = col + row * theController.maxValue;
                    cellValueS = gameDataString[cellIndex].ToString();
                    btnName = "btn_" + row.ToString() + "_" + col.ToString();

                    Control c = Controls.Find(btnName, true)[0];
                    if (theController.defIndexList.Contains(cellIndex))
                    {
                        c.ForeColor = Color.DeepPink;
                    }

                    if (cellValueS == "0")
                    {
                        c.Text = "";
                    }
                    else
                    {
                        c.Text = cellValueS;
                    }
                }
            }
            for (int i = 1; i <= theController.maxValue+2 ; i++)
            {
                btnName = "iptBtn_" + i.ToString();
                Control c = Controls.Find(btnName, true)[0];

                if (i == theController.maxValue+2)
                {
                    c.Text = "?";
                }
                else if (i == theController.maxValue+1)
                {
                    c.Text = "";
                }
                else
                {
                    c.Text = i.ToString();
                }
            }

        }

        public void ClearNumberBoard()
        {
            for (int i = 1; i <= theController.maxValue; i++)
            {
                string btnName = "iptBtn_" + i.ToString();
                Control c = Controls.Find(btnName, true)[0];
                c.BackColor = Color.White;
            }
        }

        public void ClearGameBoard(int colInd, int rowInd)
        {
            string btnName = "btn_" + rowInd.ToString() + "_" + colInd.ToString();
            Control button = Controls.Find(btnName, true)[0];
            int squareIndex = rowInd / theController.SquareHeight * theController.SquareHeight + colInd / theController.SquareWidth;
            button.BackColor = Color.White;

            if (theController.maxValue == 4)
            {
                if (squareIndex == 0 || squareIndex == 3)
                    button.BackColor = Color.LightBlue;
            }
            if (theController.maxValue == 6)
            {
                if (squareIndex == 0 || squareIndex == 3 || squareIndex == 4)
                    button.BackColor = Color.LightBlue;
            }
            if (theController.maxValue == 9)
            {
                if (squareIndex % 2 == 0)
                    button.BackColor = Color.LightBlue;
            }
           
        }

        // Show the vaild area, including vaild row,col,square.

        private void VaildAreaDisplay()
        {
            string btnName;
            string textName;
            bool isRowVaild, isColVaild, isSquareVaild;
            for (int i = 0; i < theController.maxValue; i++)
            {
                isRowVaild = theController.CheckRowVaild(i);
                isColVaild = theController.CheckColVaild(i);
                isSquareVaild = theController.CheckSquareVaild(i);

                if (isRowVaild)
                {
                    textName = "Row_" + (i + 1).ToString();
                    Control c = Controls.Find(textName, true)[0];
                    c.ForeColor = Color.Green;
                }
                else
                {
                    textName = "Row_" + (i + 1).ToString();
                    Control c = Controls.Find(textName, true)[0];
                    c.ForeColor = Color.Black;
                }
                if (isColVaild)
                {
                    textName = "Col_" + (i + 1).ToString();
                    Control c = Controls.Find(textName, true)[0];
                    c.ForeColor = Color.Green;
                }

                else
                {
                    textName = "Col_" + (i + 1).ToString();
                    Control c = Controls.Find(textName, true)[0];
                    c.ForeColor = Color.Black;
                }

                if (isSquareVaild)
                {
                    for (int j = 0; j < theController.maxValue; j++)
                    {
                        int colInd = (i % (theController.maxValue / theController.SquareWidth))
                            * theController.SquareWidth + (j % theController.SquareWidth);
                        int rowInd = (i / (theController.maxValue / theController.SquareWidth)) 
                            * theController.SquareHeight + (j / theController.SquareWidth);
                        btnName = "btn_" + rowInd.ToString() + "_" + colInd.ToString();
                        Control c = Controls.Find(btnName, true)[0];
                        c.BackColor = Color.DarkSeaGreen;
                    }
                }
                else
                {
                    for (int j = 0; j < theController.maxValue; j++)
                    {
                        int colInd = (i % (theController.maxValue / theController.SquareWidth)) 
                            * theController.SquareWidth + (j % theController.SquareWidth);
                        int rowInd = (i / (theController.maxValue / theController.SquareWidth)) 
                            * theController.SquareHeight + (j / theController.SquareWidth);
                        ClearGameBoard(colInd, rowInd);
                    }
                }
            }
        }

        private void VaildXDisplay()
        {
            string btnName;
            
            bool isX1Vaild = theController.CheckX1Vaild();
            bool isX2Vaild = theController.CheckX2Vaild();
            if (isX1Vaild)
            {
                for(int i = 0; i < theController.maxValue; i++)
                {
                    int cellIndex = theController.X1Index[i];
                    int col = cellIndex / theController.maxValue;
                    int row = cellIndex % theController.maxValue;
                    btnName = "btn_" + row.ToString() + "_" + col.ToString();
                    Control c = Controls.Find(btnName, true)[0];
                    c.BackColor = Color.Green;
                }
            }

            if (isX2Vaild)
            {
                for (int i = 0; i < theController.maxValue; i++)
                {
                    int cellIndex = theController.X2Index[i];
                    int col = cellIndex / theController.maxValue;
                    int row = cellIndex % theController.maxValue;
                    btnName = "btn_" + row.ToString() + "_" + col.ToString();
                    Control c = Controls.Find(btnName, true)[0];
                    c.BackColor = Color.Green;
                }
            }

        }

        // Display Win information.
        private void WinInfoDisplay()
        {
            if (theController.CheckAllVaild())
            {
                TextBox c = new TextBox();
                c.Font = new Font("Microsoft Sans Serif", 15);
                c.Text = "You win!! \n" + "Your Score is: " +
                    theController.GetGameScore(minutes, seconds);
                c.ForeColor = Color.LightCoral;
                c.Visible = true;
                c.Location = new Point(50, 200);
                c.Size = new Size(400, 96);
                c.TextAlign = HorizontalAlignment.Center;
                GameBoard.Controls.Clear();
                GameBoard.Controls.Add(c);
                Mytime.Stop();
                ScoreMessage.Visible = true;



                var username = Prompt.ShowDialog("Please enter your name:", "username");
                //replace "," from user's name
                username = username.Replace(",", string.Empty);
                username = username == "" ? "No name" : username;
                ScoreMessage.Text = theController.ScoreList(username, theController.GetGameScore(minutes, seconds));
            }
           
        }
        
        //used for creating new WinForm
        public static class Prompt
        {
            public static string ShowDialog(string text, string caption)
            {
                Form prompt = new Form()
                {
                    Width = 500,
                    Height = 150,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    Text = caption,
                    StartPosition = FormStartPosition.CenterScreen
                };
                Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
                TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
                Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
                confirmation.Click += (sender, e) => { prompt.Close(); };
                prompt.Controls.Add(textBox);
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(textLabel);
                prompt.AcceptButton = confirmation;

                return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
            }
        }

        private void HintVaildValue(List<int> vaildValue)
        {
            string btnName;
            for(int i = 1; i <= theController.maxValue; i++)
            {
                btnName = "iptBtn_" + i.ToString();
                Control c = Controls.Find(btnName, true)[0];
                c.BackColor = Color.White;
                if (vaildValue.Contains(i))
                {
                   c.BackColor = Color.Pink;
                }
            }       
        }
        private void HintRepeatNumber(List<int> vaildValue)
        {
            string list="";
            foreach(int i in vaildValue)
            {
                list += i.ToString()+",";
            }
            textBox1.Text = list;

            for (int i =0; i < theController.maxValue*theController.maxValue; i++)
            {
                int colInd = i % theController.maxValue;
                int rowInd = i / theController.maxValue;
                string btnName = "btn_" + rowInd.ToString() + "_" + colInd.ToString();
                Control button = Controls.Find(btnName, true)[0];

                if (vaildValue.Contains(i+3))
                {
                    button.BackColor = Color.Pink;
                }
                else
                {
                    ClearGameBoard(colInd, rowInd);   
                }
            }
        }

        //游戏流程
        private void SetGame()
        {
            GameBoard.Visible = true;
            GameBoard.Controls.Clear();
            theController.InitGameData();

            this.GameBoardDisplay();

            this.GameValueDisplay(theController.sudokuString);
            SetClicks();
            Mytime.Start();
            Mytime.Tag = "Open";
            timeTicks = 0;
        }


//------------------------------------游戏选择-----------------------------------------


        // User choose easy game.
        private void EasyToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            gameSelect = "easy.csv";
            theController.GameSelect(gameSelect);
            SetGame();
        }

        // User choose medium game.
        private void MediumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gameSelect = "medium.csv";
            theController.GameSelect(gameSelect);
            SetGame();
        }

        // User choose hard game.
        private void HardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gameSelect = "hard.csv";
            theController.GameSelect(gameSelect);
            SetGame();
        }
        // User choose X sudoku game.
        private void XSudokuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gameSelect = "Xsudoku.csv";
            theController.GameSelect(gameSelect);
            SetGame();
        }

        //加载存档游戏。
        private void LoadGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fileName = string.Empty;
            string path = Directory.GetCurrentDirectory();

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = path + @"\loadGame";

            dlg.DefaultExt = "csv";
            dlg.Filter = "Csv Files|*.csv";

            DialogResult result = dlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                fileName = dlg.SafeFileName;
                gameSelect = @"\loadGame\" + fileName;

                theController.GameSelect(gameSelect);
                SetGame();
                textBox1.Text = theController.test;

            }
        }

//------------------------------------ 游戏按键功能 -----------------------------------------
        private void PauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((string)Mytime.Tag == "Open")
            {
                Mytime.Stop();
                Mytime.Tag = "Close";
                GameBoard.Visible = false;
                PauseButton.Text = "Continue";
                pauseToolStripMenuItem.Text = "Continue";
            }
            else
            {
                Mytime.Start();
                Mytime.Tag = "Open";
                GameBoard.Visible = true;
                PauseButton.Text = "Pause";
                pauseToolStripMenuItem.Text = "Pause";
            }
        }
        private void PauseButton_Click(object sender, EventArgs e)
        {
            PauseToolStripMenuItem_Click(sender, e);
        }

        private void RestoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetGame();
        }

        private void RestoreButton_Click(object sender, EventArgs e)
        {
            SetGame();
        }

        private void SaveGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (theController.sudokuArray != null)
            {
                theController.GameSave(seconds, minutes);
            }

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void UndoButton_Click(object sender, EventArgs e)
        {
            theController.Undo();
        }

        private void RedoButton_Click(object sender, EventArgs e)
        {
            theController.Redo();
        }

        private void UndoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            theController.Undo();
        }

        private void RedoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            theController.Redo();
        }

        
    }
}
