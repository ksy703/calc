using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_num_Click(object sender, EventArgs e)
        {
            Button _button;
            _button = (Button)sender;
            textBox1.Text += _button.Text;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (!this.textBox1.Text.Contains("."))
            {
                textBox1.Text += ".";
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text += "+";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox1.Text += "-";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox1.Text += "*";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox1.Text += "/";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
        }
    }
}
