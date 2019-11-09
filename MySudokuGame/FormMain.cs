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

        public FormMain()
        {
            InitializeComponent();
        }
        public void SetController(Controller contr)
        {
            theController = contr;
        }

//------------------------------------ Create Controls -----------------------------------------

        //Creat game scale, in order to dispaly row number and col number.
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


        // Creat number buttons
        public void MakeButtons(string text, int num)
        {
            Button btnNew = new Button();
            btnNew.Name = "iptBtn_" + text;
            btnNew.Height = 50;
            btnNew.Width = 50;
            btnNew.Font = new Font("Arial", 20);
            btnNew.Text = text;
            btnNew.Visible = true;
            btnNew.Location = new Point(100 + 50 * num, 150 + 50 * theController.maxValue);
            GameBoard.Controls.Add(btnNew);
        }

        //Create game buttons
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
            
            btnNew.Location = new Point(100+ 50 * column, 100 + 50 * row);
            if (theController.maxValue==4)
            {
                if(squareIndex==0|| squareIndex == 3)
                    btnNew.BackColor = Color.LightBlue;
            }
            if (theController.maxValue == 6)
            {
                if (squareIndex == 0 || squareIndex == 3 || squareIndex == 4)
                    btnNew.BackColor = Color.LightBlue;
            }
            if (theController.maxValue == 9)
            {
                if (squareIndex%2==0)
                    btnNew.BackColor = Color.LightBlue;
            }
            GameBoard.Controls.Add(btnNew);
        }

        //Create game timer
        



//------------------------------------ Game Display -----------------------------------------

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

            for (int i = 0; i <= theController.maxValue; i++)
            {
                string text = (i + 1).ToString();
                if (i != theController.maxValue)
                {
                    MakeButtons(text, i);
                }
                else
                {
                    MakeButtons("", i);
                }
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
        }

        // Show the vaild area, including vaild row,col,square.
        private void VaildAreaDisplay()
        {
            string btnName;
            string textName;
            

            bool isRowVaild, isColVaild, isSquareVaild;
            for(int i = 0; i < theController.maxValue; i++)
            {
                isRowVaild = theController.CheckRowVaild(i);
                isColVaild = theController.CheckColVaild(i);
                isSquareVaild = theController.CheckSquareVaild(i);

                if (isRowVaild)
                {
                    textName = "Row_" + (i+1).ToString();
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
                        int colInd = (i % (theController.maxValue / theController.SquareWidth)) * theController.SquareWidth + (j % theController.SquareWidth);
                        int rowInd = (i / (theController.maxValue / theController.SquareWidth)) * theController.SquareHeight + (j / theController.SquareWidth);
                        btnName = "btn_" + rowInd.ToString() + "_" + colInd.ToString();
                        Control c = Controls.Find(btnName, true)[0];
                        c.BackColor = Color.DarkSeaGreen;
                    }
                }
                else
                {   
                    for (int j = 0; j < theController.maxValue; j++)
                    {
                        int colInd = (i % (theController.maxValue / theController.SquareWidth)) * theController.SquareWidth + (j % theController.SquareWidth);
                        int rowInd = (i / (theController.maxValue / theController.SquareWidth)) * theController.SquareHeight + (j / theController.SquareWidth);
                        btnName = "btn_" + rowInd.ToString() + "_" + colInd.ToString();

                        Control c = Controls.Find(btnName, true)[0];
                        c.BackColor = Color.White;

                        if (theController.maxValue == 4)
                        {
                            if (i == 0 || i == 3)
                                c.BackColor = Color.LightBlue;
                        }
                        if (theController.maxValue == 6)
                        {
                            if (i == 0 || i == 3 || i == 4)
                                c.BackColor = Color.LightBlue;
                        }
                        if (theController.maxValue == 9)
                        {
                            if (i % 2 == 0)
                                c.BackColor = Color.LightBlue;
                        }
                    }

                }
                
            }
        }

        // Display Win information.
        private void WinInfoDisplay()
        {
            if (theController.CheckAllVaild())
            {
                TextBox c = new TextBox();
                c.Font = new Font("Microsoft Sans Serif", 36);
                c.Text = "You win!!";
                c.ForeColor = Color.LightCoral;
                c.Visible = true;
                c.Location = new Point(50, 200);
                c.Size = new Size(350, 96);
                c.TextAlign = HorizontalAlignment.Center;

                GameBoard.Controls.Clear();
                GameBoard.Controls.Add(c);
                Mytime.Stop();
            }
        }


//------------------------------------New Game Options-----------------------------------------
        //
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
        
        // User choose easy game.
        private void EasyToolStripMenuItem1_Click(object sender, EventArgs e)
        {   
            gameSelect = "easy";
            theController.GameSelect(gameSelect);
            SetGame();
        }

        // User choose medium game.
        private void MediumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gameSelect = "medium";
            theController.GameSelect(gameSelect);
            SetGame();
        }

        // User choose hard game.
        private void HardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gameSelect = "hard";
            theController.GameSelect(gameSelect);
            SetGame();
        }

        //private void Button1_Click(object sender, EventArgs e)
        //{
        //    string path = System.AppDomain.CurrentDomain.BaseDirectory;
        //    string fileName = path + "easy.csv";

        //    StreamReader sr = new StreamReader(fileName, System.Text.Encoding.Default);
        //    String ls_input = sr.ReadToEnd().TrimStart();
        //    if (!string.IsNullOrEmpty(ls_input))
        //    {
        //        testbox.Text = ls_input;
        //    }

        //    sr.Close();
        //}


        //private void NewGameToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    string fileName = string.Empty;
        //    OpenFileDialog dlg = new OpenFileDialog();
        //    dlg.DefaultExt = "csv";
        //    dlg.Filter = "Csv Files|*.csv";
        //    if (dlg.ShowDialog() == DialogResult.OK)
        //        fileName = dlg.FileName;
        //    if (fileName == null)
        //        return;

        //    //读取文件内容
        //    StreamReader sr = new StreamReader(fileName, System.Text.Encoding.Default);
        //    String ls_input = sr.ReadToEnd().TrimStart();
        //    if (!string.IsNullOrEmpty(ls_input))
        //    {
        //        testbox.Text = ls_input;
        //    }

        //    sr.Close();
        //}

//------------------------------------ Play the Game -----------------------------------------

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

                theController.ChangeValue(ClickedText, btnWho.Name);
                GameValueDisplay(theController.sudokuString);
                this.VaildAreaDisplay();
                this.WinInfoDisplay();
            }

            else if (btnWho.Name.StartsWith("iptBtn_"))
            {
                ClickedText = btnWho.Text;
            }
        }

        private void Mytime_Tick(object sender, EventArgs e)
        {
            timeTicks++;
           
            int seconds = (timeTicks / 10) % 60;
            int minutes = (timeTicks / 10/60) % 60;

            TimeBox.Text = minutes.ToString("00") + " : " + seconds.ToString("00");
            //TimeBox.Text = timeTicks.ToString();
        }

        private void PauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if((string)Mytime.Tag == "Open" )
            {
                Mytime.Stop();
                Mytime.Tag = "Close";
                GameBoard.Visible = false;
                PauseButton.BackColor = Color.Gray;
            }
            else
            {
                Mytime.Start();
                Mytime.Tag = "Open";
                GameBoard.Visible = true;
                PauseButton.BackColor = Color.Teal;
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
    }
}
