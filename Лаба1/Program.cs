using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;


//Сложение, вычитание, деление, умножение получение остатка от
//деления, получение целой части деления, очистка. Добавьте
//операции хранения и извлечения значения в памяти.
namespace Лаба1
{
    interface ICalculations
    {
        string Clear();
        string Delete(string str);
        string BaseMathOperations(string str, string operation);
        string Answer();
        string Remainder(string str);
        string WholePart(string str);
        string DefaultEqually(string str);
    }
    class Calculation : ICalculations
    {
        public string Clear()
        {
            return "";
        }
        public string Delete(string str)
        {
            return str.Remove(str.Length - 1);
        }
        public string BaseMathOperations(string str, string op)
        {
            return str + op;
        }
        public string Answer()
        {
            try
            {
                if (Form1.answer != "")
                {
                    return Form1.answer;
                }
                else throw new Exception("There is no saved results");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return "";

        }
        public string Remainder(string str)
        {
            try
            {
                string[] operands = str.Split('%');
                if (operands.Length == 2) {
                    Form1.answer = (Double.Parse(operands[0]) % Double.Parse(operands[1])).ToString();
                    //Form1.listOfResults.Add((Double.Parse(operands[0]) % Double.Parse(operands[1])).ToString());

                    return Form1.answer; 
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return "";
        }
        public string WholePart(string str)
        {
            try
            {
                string[] op = new string[2];
                string[] operands = str.Split(new char[] { 'D', 'i', 'v' });
                int i = 0;
                foreach (string str4 in operands)
                {
                    if (str4 != "")
                    {
                        op[i] = str4;
                        i++;
                    }
                }
                if (i == 2)
                {
                    Form1.answer = Math.Truncate(Double.Parse(op[0]) / Double.Parse(op[1])).ToString();
                    //Form1.listOfResults.Add(Form1.answer);
                    return Form1.answer;
                }
                else
                    throw new Exception("Wrong Input!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return "";

        }
        public string DefaultEqually(string str)
        {
            string value = new DataTable().Compute(str, null).ToString();
            Form1.answer = value;
            //Form1.listOfResults.Add(value);
            return Form1.answer;

        }
    }
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
