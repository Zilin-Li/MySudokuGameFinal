using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MySudokuGame
{
   
    public partial class FormMain : Form, IView
    {
        //timer 
        public delegate void OnPublishGameTimeDelegate(string timeDescription);
        public event OnPublishGameTimeDelegate OnPublishGameTimeEvent;
        private DateTime gameStartTime;
        private System.Windows.Forms.Timer gameTimer = new System.Windows.Forms.Timer();
        private void SetGameTimer()
        {
            Mytime.Interval = 1000;
            Mytime.Enabled = true;
            Mytime.Tick += (sender, args) =>
            {
                long dMillisecond = DateTime.Now.Millisecond - gameStartTime.Millisecond;
                long hour = dMillisecond / 60 / 60 / 1000;
                long minute = (dMillisecond - hour * (60 * 60 * 1000)) / (60 * 1000);
                long second = ((dMillisecond - hour * (60 * 60 * 1000)) % (60 * 1000)) / 1000;
                OnPublishGameTimeEvent?.Invoke((hour > 0 ? (hour > 9 ? hour.ToString() : "0" + hour) + ":" : "")
                                + (minute > 9 ? minute.ToString() : "0" + minute) + "：" + (second > 9 ? second.ToString() : "0" + second));
            };
        }
        //end here
        private Controller theController;
        string ClickedText = "";

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
            btnNew.Height = 50;
            btnNew.Width = 50;
            btnNew.Font = new Font("Arial", 20);
            btnNew.Text = text;
            btnNew.Visible = true;
            btnNew.Location = new Point(10 + 50 * num, 50 + 50 * theController.maxValue);

            GameBoard.Controls.Add(btnNew);
        }

        //创建游戏按键

        public void MakeButtons2(string name, string text, int row, int column)
        {
            Button btnNew = new Button();
            btnNew.Name = name + row.ToString() + "_" + column.ToString();
            btnNew.Height = 50;
            btnNew.Width = 50;
            btnNew.Font = new Font("Arial", 20);
            btnNew.Text = text;
            btnNew.Visible = true;
            btnNew.Location = new Point(10 + 50 * column, 10 + 50 * row);

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

        private void EasyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            theController.InitGameData();
            this.GameBoardDisplay();
            this.GameValueDisplay(theController.sudokuString);
            SetClicks();
            gameStartTime = DateTime.Now;
            gameTimer.Start();
            SetGameTimer();



        }

        private void MediumToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            theController.InitGameData();
            // this.GameBoardDisplay();

        }

    }
}
