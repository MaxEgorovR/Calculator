using System.Linq.Expressions;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public char action;

        public double firstNum;

        public Form1()
        {
            InitializeComponent();
        }

        public static double not_lirary_sqrt(double number)
        {
            double t;
            double squareRoot = number / 2;
            do
            {
                t = squareRoot;
                squareRoot = (t + (number / t)) / 2;
            } while ((t - squareRoot) != 0);
            return squareRoot;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "1";
            }
            else
            {
                textBox1.Text += '1';
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "2";
            }
            else
            {
                textBox1.Text += '2';
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "3";
            }
            else
            {
                textBox1.Text += '3';
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "4";
            }
            else
            {
                textBox1.Text += '4';
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "5";
            }
            else
            {
                textBox1.Text += '5';
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "6";
            }
            else
            {
                textBox1.Text += '6';
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "7";
            }
            else
            {
                textBox1.Text += '7';
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "8";
            }
            else
            {
                textBox1.Text += '8';
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "9";
            }
            else
            {
                textBox1.Text += '9';
            }
        }

        private void button0_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "0";
            }
            else if (textBox1.Text[textBox1.Text.Length-1] == '/')
            {
                return;
            }
            else
            {
                textBox1.Text += '0';
            }
        }

        public double Calculate(string expression)
        {
            expression = expression.Replace(" ", "");

            var values = new Stack<double>();
            var operations = new Stack<char>();

            for (int i = 0; i < expression.Length; i++)
            {
                if (char.IsDigit(expression[i]) || expression[i] == '.')
                {
                    string number = "";

                    while (i < expression.Length && (char.IsDigit(expression[i]) || expression[i] == '.'))
                    {
                        number += expression[i];
                        i++;
                    }
                    values.Push(double.Parse(number));
                    i--;
                }
                else if (expression[i] == '√')
                {
                    i++;
                    if (expression[i] == '(')
                    {
                        int startIdx = ++i;
                        int bracketCount = 1;

                        while (bracketCount > 0 && i < expression.Length)
                        {
                            if (expression[i] == '(') bracketCount++;
                            if (expression[i] == ')') bracketCount--;
                            i++;
                        }

                        double value = Calculate(expression.Substring(startIdx - 1, i - startIdx + 1));
                        values.Push(Math.Sqrt(value));
                        i--;
                    }
                    else
                    {
                        string number = "";

                        while (i < expression.Length && (char.IsDigit(expression[i]) || expression[i] == '.'))
                        {
                            number += expression[i];
                            i++;
                        }

                        double value = double.Parse(number);
                        values.Push(Math.Sqrt(value));
                        i--;
                    }
                }
                else if (expression[i] == '(')
                {
                    operations.Push('(');
                }
                else if (expression[i] == ')')
                {
                    while (operations.Count > 0 && operations.Peek() != '(')
                    {
                        double result = ApplyOperation(operations.Pop(), values.Pop(), values.Pop());
                        values.Push(result);
                    }
                    operations.Pop();
                }
                else
                {
                    while (operations.Count > 0 && GetPrecedence(operations.Peek()) >= GetPrecedence(expression[i]))
                    {
                        double result = ApplyOperation(operations.Pop(), values.Pop(), values.Pop());
                        values.Push(result);
                    }
                    operations.Push(expression[i]);
                }
            }

            while (operations.Count > 0)
            {
                double result = ApplyOperation(operations.Pop(), values.Pop(), values.Pop());
                values.Push(result);
            }

            return values.Pop();
        }

        public int GetPrecedence(char operation)
        {
            switch (operation)
            {
                case '+':
                case '-':
                    return 1;
                case '*':
                case '/':
                    return 2;
                default:
                    return 0;
            }
        }

        public double ApplyOperation(char operation, double b, double a)
        {
            switch (operation)
            {
                case '+':
                    return a + b;
                case '-':
                    return a - b;
                case '*':
                    return a * b;
                case '/':
                    if (b == 0) throw new InvalidOperationException("Деление на ноль.");
                    return a / b;
                default:
                    throw new InvalidOperationException("Недействительная операция.");
            }
        }

        private void buttonEqually_Click(object sender, EventArgs e)
        {
            string expression = textBox1.Text;
            if ((expression.Count(x => x == ')') != expression.Count(x => x == '('))|| textBox1.Text[textBox1.Text.Length - 1] == '/'|| textBox1.Text[textBox1.Text.Length - 1] == '*'|| textBox1.Text[textBox1.Text.Length - 1] == '+'|| textBox1.Text[textBox1.Text.Length - 1] == '-'|| textBox1.Text[textBox1.Text.Length - 1] == '√'|| textBox1.Text[textBox1.Text.Length - 1] == ',')
            {
                return;
            }

            double result = Calculate(expression);
            textBox1.Text = Convert.ToString(result);
        }

        private void buttonDivid_Click(object sender, EventArgs e)
        {
            if(textBox1.Text[textBox1.Text.Length - 1] == '/' || textBox1.Text[textBox1.Text.Length - 1] == '*' || textBox1.Text[textBox1.Text.Length - 1] == '+' || textBox1.Text[textBox1.Text.Length - 1] == '-' || textBox1.Text[textBox1.Text.Length - 1] == '√')
            {
                return ;
            }
            textBox1.Text += '/';
        }

        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            if (textBox1.Text[textBox1.Text.Length - 1] == '/' || textBox1.Text[textBox1.Text.Length - 1] == '*' || textBox1.Text[textBox1.Text.Length - 1] == '+' || textBox1.Text[textBox1.Text.Length - 1] == '-' || textBox1.Text[textBox1.Text.Length - 1] == '√')
            {
                return;
            }
            textBox1.Text += '*';
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            if (textBox1.Text[textBox1.Text.Length - 1] == '/' || textBox1.Text[textBox1.Text.Length - 1] == '*' || textBox1.Text[textBox1.Text.Length - 1] == '+' || textBox1.Text[textBox1.Text.Length - 1] == '-' || textBox1.Text[textBox1.Text.Length - 1] == '√')
            {
                return;
            }
            textBox1.Text += '-';
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            if (textBox1.Text[textBox1.Text.Length - 1] == '/' || textBox1.Text[textBox1.Text.Length - 1] == '*' || textBox1.Text[textBox1.Text.Length - 1] == '+' || textBox1.Text[textBox1.Text.Length - 1] == '-' || textBox1.Text[textBox1.Text.Length - 1] == '√')
            {
                return;
            }
            textBox1.Text += '+';
        }

        private void buttonPoint_Click(object sender, EventArgs e)
        {
            if (textBox1.Text[textBox1.Text.Length - 1] == '/' || textBox1.Text[textBox1.Text.Length - 1] == '*' || textBox1.Text[textBox1.Text.Length - 1] == '+' || textBox1.Text[textBox1.Text.Length - 1] == '-' || textBox1.Text[textBox1.Text.Length - 1] == '√' || textBox1.Text[textBox1.Text.Length-1] == ',')
            {
                return;
            }
            textBox1.Text += ',';

        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox1.Text[textBox1.Text.Length - 1] == '√')
            {
                return;
            }
            textBox1.Text += '√';
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Count(x => x == ')') == textBox1.Text.Count(x => x == '('))
            {
                if (textBox1.Text[textBox1.Text.Length-1] <48 || textBox1.Text[textBox1.Text.Length - 1] >57)
                textBox1.Text += '(';
            }
            else
            {
                textBox1.Text += ')';
            }
        }
    }
}
