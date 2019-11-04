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

        public FormMain()
        {
            InitializeComponent();
        }
        public void SetController(Controller contr)
        {
            theController = contr;
        }


        //创建数字板按键
        public void MakeButtons(string text, int num)
        {
            Button btnNew = new Button();
            btnNew.Name = "iptBtn_" + text;
            btnNew.Height = 60;
            btnNew.Width = 60;
            btnNew.Font = new Font("Arial", 20);
            btnNew.Text = text;
            btnNew.Visible = true;
            btnNew.Location = new Point(10 + 60 * num, 60 + 60 * theController.maxValue);

            GameBoard.Controls.Add(btnNew);
        }

        //创建游戏按键

        public void MakeButtons2(string name, string text, int row, int column)
        {
            int squareIndex;
            squareIndex = row / theController.SquareHeight * theController.SquareHeight + column / theController.SquareWidth;

            Button btnNew = new Button();
            btnNew.Name = name + row.ToString() + "_" + column.ToString();
            btnNew.Height = 60;
            btnNew.Width = 60;
            btnNew.Font = new Font("Arial", 20);
            btnNew.Text = text;
            btnNew.Visible = true;
            btnNew.Location = new Point(10 + 60 * column, 10 + 60 * row);
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

        public void GameBoardDisplay()
        {
            string cellValueS = "";
            for (int row = 0; row < theController.maxValue; row++)
            {
                for (int col = 0; col < theController.maxValue; col++)
                {
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

        public void WhoClicked(object sender, EventArgs e)
        {
            Button btnWho = sender as Button;
            Text = btnWho.Name;

            if (btnWho.Name.StartsWith("btn"))
            {
                theController.ChangeValue(ClickedText, btnWho.Name);
                GameValueDisplay(theController.sudokuString);


            }
            else if (btnWho.Name.StartsWith("iptBtn_"))
            {
                ClickedText = btnWho.Text;
            }
        }



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


        private void EasyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GameBoard.Controls.Clear();
            gameSelect = "easy";
            theController.GameSelect(gameSelect);
            theController.InitGameData();
            this.GameBoardDisplay();
            this.GameValueDisplay(theController.sudokuString);
            SetClicks();
            
        }
        private void MediumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GameBoard.Controls.Clear();
            gameSelect = "medium";
            theController.GameSelect(gameSelect);
            theController.InitGameData();
            this.GameBoardDisplay();
            this.GameValueDisplay(theController.sudokuString);
            SetClicks();
        }
        private void HardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GameBoard.Controls.Clear();
            gameSelect = "hard";
            theController.GameSelect(gameSelect);
            theController.InitGameData();
            this.GameBoardDisplay();
            this.GameValueDisplay(theController.sudokuString);
            SetClicks();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string path = System.AppDomain.CurrentDomain.BaseDirectory;
            string fileName = path + "easy.csv";
            
            StreamReader sr = new StreamReader(fileName, System.Text.Encoding.Default);
            String ls_input = sr.ReadToEnd().TrimStart();
            if (!string.IsNullOrEmpty(ls_input))
            {
                testbox.Text = ls_input;
            }

            sr.Close();
        }

       
    }
}
