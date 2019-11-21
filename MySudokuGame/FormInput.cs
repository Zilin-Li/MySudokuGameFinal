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
    public partial class FormInput : Form
    {
        public FormInput()
        {
            InitializeComponent();
        }

        public string Get()
        {
            return textBox1.Text;
        }

        private void FormInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
