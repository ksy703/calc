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
        //Enter keydown
        private void Text_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                button_e_Click(sender, e);
            }
        }
        //C button click
        private void button_C_Click(object sender, EventArgs e)
        {
            textBox1.Focus();
            textBox1.Text = string.Empty;
        }
        //= button click
        private void button_e_Click(object sender, EventArgs e)
        {
            var formula = textBox1.Text.ToCharArray();
            string ans = make_postfix(formula);
            textBox1.Focus();
            textBox1.Text = ans;
            textBox1.SelectionStart=textBox1.Text.Length;
        }
        //나머지 button click
        private void button_Click(object sender, EventArgs e)
        {
            Button _button;
            _button = (Button)sender;
            textBox1.Focus();
            textBox1.Text += _button.Text;
            textBox1.SelectionStart=textBox1.Text.Length;
        }


        //후위표기식 계산
        private string calculate(string s)
        {
            string[] cal = s.Split(' ');
            
            string[] stack = new string[30];
            int cnt = 0;
            for(int i = 0; i < cal.Length; i++)
            {
                if (cal[i].Equals("+"))
                {
                    Double a = Convert.ToDouble(stack[cnt - 2]) + Convert.ToDouble(stack[cnt - 1]);
                    stack[cnt - 2] = a.ToString();
                    cnt--;
                }else if (cal[i].Equals("-"))
                {
                    Double a = Convert.ToDouble(stack[cnt - 2]) - Convert.ToDouble(stack[cnt - 1]);
                    stack[cnt - 2] = a.ToString();
                    cnt--;
                }
                else if (cal[i].Equals("*"))
                {
                    Double a = Convert.ToDouble(stack[cnt - 2]) * Convert.ToDouble(stack[cnt - 1]);
                    stack[cnt - 2] = a.ToString();
                    cnt--;
                }
                else if (cal[i].Equals("/"))
                {
                    Double a = Convert.ToDouble(stack[cnt - 2]) / Convert.ToDouble(stack[cnt - 1]);
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

        //계산 우선순위
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
        
        //get_prt로 계산 우선순위 결정, 후위표기법으로 변경
        private string make_postfix(char[] cal)
        {
            string exp = "";
            char[] stack = new char[30];
            int cnt = 0;
            for (int i = 0; i < cal.Length; i++)
            {
                //괄호
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
                    exp += make_postfix(m.ToCharArray());
                    
                }
                //수식
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
                //숫자 또는 소수점
                else
                {
                    if (i==0||(i>=1&&(cal[i - 1] - '0' >= 0 && cal[i - 1] - '0' <= 9)||(cal[i-1]=='.')))
                    {
                        exp += cal[i];
                    }
                    else
                    {
                        exp += " " + cal[i];
                    }
                    
                }
            }
            //stack에 남은 숫자들
            while(cnt>0)
            {
                exp += " " + stack[cnt-1];
                cnt--;
            }
            
            return calculate(exp);
        }
        
    }
}
