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
    public partial class FormMain : Form,IView
    {
        private Controller theController;
        private SudokuGame theGame;

        public FormMain()
        {
            InitializeComponent();
        }
        public void SetController(Controller contr)
        {
            theController = contr;
        }
        public void SetModel(SudokuGame theModel)
        {
            theGame = theModel;
        }

        protected void MakeButtons(int num)
        {
            Button btnNew = new Button();
            btnNew.Name = "btn";
            btnNew.Height = 50;
            btnNew.Width = 50;
            btnNew.Font = new Font("Arial", 20);
            btnNew.Text = (num + 1).ToString();
            btnNew.Visible = true;
            btnNew.Location = new Point(10 + 50 * num, 50 + 50 * theGame.maxValue);

            GameBoard.Controls.Add(btnNew);
        }

        protected void MakeButtons2(string name, string text, int row, int column)
        {
            Button btnNew = new Button();
            btnNew.Name = name + row.ToString() + "_" + column.ToString();
            btnNew.Height = 50;
            btnNew.Width = 50;
            btnNew.Font = new Font("Arial", 20);
            btnNew.Text = text;
            btnNew.Visible = true;
            btnNew.Location = new Point(10 + 50 * row, 10 + 50 * column);

            GameBoard.Controls.Add(btnNew);
        }

        public void BoardDisplay()
        {

            for (int i = 0; i < theGame.maxValue; ++i)
            {
                for (int j = 0; j < theGame.maxValue; ++j)
                {
                    int arrayIndex = i + j * theGame.maxValue;
                    string text = theGame.sudokuArray[arrayIndex].ToString();
                    MakeButtons2("btn_", text, i, j);
                }
            }

            for (int a = 0; a < theGame.maxValue; a++)
            {
                MakeButtons(a);
            }

        }

        private void EasyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            theController.InitGameData();
            this.BoardDisplay();//Here should link to controller， controller:1, get game infor for csv，2,sent the info to this project)
        }

        private void MediumToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            theController.InitGameData();
            this.BoardDisplay();
        }
    }
}
