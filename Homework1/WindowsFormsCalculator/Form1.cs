using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Btn_Calculate_Click(object sender, EventArgs e)
        {
            double num1, num2;

            if (!Double.TryParse(textBox_Num1.Text, out num1) || !Double.TryParse(textBox_Num2.Text, out num2))
            {
                textBox_Result.Text = "输入错误！";
                return;
            }

            switch (comboBox_Operator.SelectedIndex)
            {
                case 0:
                    textBox_Result.Text = $"{num1 + num2}";
                    break;
                case 1:
                    textBox_Result.Text = $"{num1 - num2}";
                    break;
                case 2:
                    textBox_Result.Text = $"{num1 * num2}";
                    break;
                case 3:
                    if (num2 == 0)
                    {
                        textBox_Result.Text = "除数不能为0！";
                        return;
                    }
                    textBox_Result.Text = $"{num1 / num2}";
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox_Operator.SelectedIndex = 0;
        }

        private void Btn_Clear_Click(object sender, EventArgs e)
        {
            textBox_Num1.Text = null;
            textBox_Num2.Text = null;
            textBox_Result.Text = null;
            comboBox_Operator.SelectedIndex = 0;
        }
    }
}
