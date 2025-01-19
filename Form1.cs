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
            else
            {
                textBox1.Text += '0';
            }
        }

        private void buttonEqually_Click(object sender, EventArgs e)
        {
            switch (action)
            {
                case '/':
                    if (!(textBox1.Text == "0"))
                    {
                        textBox1.Text = Convert.ToString(firstNum / Convert.ToDouble(textBox1.Text));
                    }
                    break;
                case '*':
                    textBox1.Text = Convert.ToString(Convert.ToDouble(textBox1.Text) * firstNum);
                    break;
                case '-':
                    textBox1.Text = Convert.ToString(firstNum - Convert.ToDouble(textBox1.Text));
                    break;
                case '+':
                    textBox1.Text = Convert.ToString(Convert.ToDouble(textBox1.Text) + firstNum);
                    break;
            }
        }

        private void buttonDivid_Click(object sender, EventArgs e)
        {
            action = '/';
            firstNum = Convert.ToDouble(textBox1.Text);
            textBox1.Text = "0";
        }

        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            action = '*';
            firstNum = Convert.ToDouble(textBox1.Text);
            textBox1.Text = "0";
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            action = '-';
            firstNum = Convert.ToDouble(textBox1.Text);
            textBox1.Text = "0";
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            action = '+';
            firstNum = Convert.ToDouble(textBox1.Text);
            textBox1.Text = "0";
        }

        private void buttonPoint_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Contains(","))
            {
                textBox1.Text += ',';
            }

        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
