using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Лаба1
{

    public partial class Form1 : Form
    {
        public static string answer = "";
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e) //не рабтает
        {
            foreach (var item in this.Controls) //обходим все элементы формы
            {
                if (item is Button) // проверяем, что это кнопка
                {
                    ((Button)item).Click += CommonBtn_Click; //приводим к типу и устанавливаем обработчик события  
                }
            }

        }
        private void CommonBtn_Click(object sender, EventArgs e)
        {
            Button but = sender as Button;
            Calculation calc = new Calculation();

            string str = but.Text;
            if (str == "CE")
            {
                textBox1.Text = calc.Clear();
            }
            else if (str == "Del")
            {
                textBox1.Text = calc.Delete(textBox1.Text);
            }
            else if (str == "Ans")
            {
                textBox1.Text = calc.Answer();
            }
            else if (str == "=")
            {
                if (textBox1.Text.Contains("%"))
                {
                    textBox1.Text = calc.Remainder(textBox1.Text);
                }
                else if (textBox1.Text.Contains("Div"))
                {
                    textBox1.Text = calc.WholePart(textBox1.Text);
                }
                else
                {
                    textBox1.Text = calc.DefaultEqually(textBox1.Text);
                }
            }
            else textBox1.Text = calc.BaseMathOperations(textBox1.Text, str);
        }


    }
}
