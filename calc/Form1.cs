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
        
        private void button_Click(object sender, EventArgs e)
        {
            Button _button;
            _button = (Button)sender;
            textBox1.Text += _button.Text;
            
        }
        private void Text_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Return)
            {
                this.button_e_Click(sender, e);
            }
           

        }

        private void button_close_Click(object sender, EventArgs e)
        {
            textBox1.Text += button11.Text;    
        }
        private void button_open_Click(object sender, EventArgs e)
        {
            textBox1.Text += button18.Text;
        }
        private void button_C_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
        }

        private void button_e_Click(object sender, EventArgs e)
        {
            var cal=textBox1.Text.ToCharArray();
            string s = calculate(cal);
            string ans = make_answer(s);
            textBox1.Text = ans;
        }
        private string make_answer(string s)
        {
            string[] cal = s.Split(' ');
            
            string[] stack = new string[30];
            int cnt = 0;
            for(int i = 0; i < cal.Length; i++)
            {
                if (cal[i].Equals("+"))
                {
                    int a = Convert.ToInt32(stack[cnt - 2]) + Convert.ToInt32(stack[cnt - 1]);
                    stack[cnt - 2] = a.ToString();
                    cnt--;
                }else if (cal[i].Equals("-"))
                {
                    int a = Convert.ToInt32(stack[cnt - 2]) - Convert.ToInt32(stack[cnt - 1]);
                    stack[cnt - 2] = a.ToString();
                    cnt--;
                }
                else if (cal[i].Equals("*"))
                {
                    int a = Convert.ToInt32(stack[cnt - 2]) * Convert.ToInt32(stack[cnt - 1]);
                    stack[cnt - 2] = a.ToString();
                    cnt--;
                }
                else if (cal[i].Equals("/"))
                {
                    float a = Convert.ToInt32(stack[cnt - 2]) / Convert.ToInt32(stack[cnt - 1]);
                    stack[cnt - 2] = a.ToString();
                    cnt--;
                }
                else
                {
                    stack[cnt] = cal[i];
                    cnt++;
                }
            }return stack[0];
        }

        private int get_prt(char c)
        {
            if (c == '*' || c == '/')
            {
                return 9;
            }
            else
            {
                return 5;
            }
        }
        private string calculate(char[] cal)
        {
            string exp = "";
            char[] stack = new char[30];
            int cnt = 0;
            for (int i = 0; i < cal.Length; i++)
            {
                if(cal[i]=='(')
                {
                    string m = "";
                    i++;
                    while (cal[i] != ')')
                    {
                        m += cal[i];
                        i++;
                    }
                    if (exp!="")
                    {
                        exp += " ";
                    }
                    exp += calculate(m.ToCharArray());
                    
                }

                else if(cal[i]=='+'||cal[i]=='-'||cal[i]=='*'||cal[i]=='/'){
                    int prt = get_prt(cal[i]);
                    if (cnt != 0)
                    {
                        int postprt = get_prt(stack[cnt - 1]);
                        while (prt <= postprt&&cnt>0)
                        {
                            exp += " "+stack[cnt - 1];
                            cnt--;
                        }
                    }
                    stack[cnt] = cal[i];
                    cnt++;
                }
                else
                {
                    if (i>=1&&cal[i - 1] - '0' >= 0 && cal[i - 1] - '0' <= 9)
                    {
                        exp += cal[i];
                    }
                    else if (i == 0)
                    {
                        exp += cal[i];
                    }
                    else
                    {
                        exp += " " + cal[i];
                    }
                    
                }
            }
            while(cnt>0)
            {
                exp += " " + stack[cnt-1];
                cnt--;
            }
            
            return exp;
        }
        
    }
}
