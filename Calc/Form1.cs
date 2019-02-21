using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calc
{
    public partial class Form1 : Form
    {
        private string memory = "0";
        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ExampleTextBox.Text = "0";
            AnswerTextBox.Text = "0";
        }

        private void AnswerTextBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void ExampleTextBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void ExpButton_Click(object sender, EventArgs e)
        {
            ExampleTextBox.Text += "exp";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            ExampleTextBox.Text += "1";
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            ExampleTextBox.Text += "2";
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            ExampleTextBox.Text += "3";
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            ExampleTextBox.Text += "4";
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            ExampleTextBox.Text += "5";
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            ExampleTextBox.Text += "6";
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            ExampleTextBox.Text += "7";
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            ExampleTextBox.Text += "8";
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            ExampleTextBox.Text += "9";
        }

        private void PlusButton_Click(object sender, EventArgs e)
        {
            ExampleTextBox.Text += "+";
        }

        private void MinusButton_Click(object sender, EventArgs e)
        {
            ExampleTextBox.Text += "-";
        }

        private void DivButton_Click(object sender, EventArgs e)
        {
            ExampleTextBox.Text += "/";
        }

        private void MultiplButton_Click(object sender, EventArgs e)
        {
            ExampleTextBox.Text += "*";
        }

        private void EqualButton_Click(object sender, EventArgs e)
        {
            var result = new Parser().Evaluate(ExampleTextBox.Text);
            AnswerTextBox.Text = result.ToString();
        }

        private void BackSpaceButton_Click(object sender, EventArgs e)
        {
            var expression = ExampleTextBox.Text;
            var newExpression = expression.Remove(expression.Length - 1);
            ExampleTextBox.Text = newExpression;
        }

        private void DelButton_Click(object sender, EventArgs e)
        {
            AnswerTextBox.Text = "0";
        }

        private void DelAllButton_Click(object sender, EventArgs e)
        {
            ExampleTextBox.Text = "0";
            AnswerTextBox.Text = "0";
        }

        private void SqrtButton_Click(object sender, EventArgs e)
        {
            ExampleTextBox.Text += "sqrt";
        }

        private void InvolButton_Click(object sender, EventArgs e)
        {
            ExampleTextBox.Text += "^";
        }

        private void Button0_Click(object sender, EventArgs e)
        {
            ExampleTextBox.Text += "0";
        }

        private void ButtonDot_Click(object sender, EventArgs e)
        {
            ExampleTextBox.Text += ",";
        }

        private void SinButton_Click(object sender, EventArgs e)
        {
            ExampleTextBox.Text += "sin";
        }

        private void CosButton_Click(object sender, EventArgs e)
        {
            ExampleTextBox.Text += "cos";
        }

        private void TanButton_Click(object sender, EventArgs e)
        {
            ExampleTextBox.Text += "tan";
        }

        private void ArcSinButton_Click(object sender, EventArgs e)
        {
            ExampleTextBox.Text += "asin";
        }

        private void ArcCosButton_Click(object sender, EventArgs e)
        {
            ExampleTextBox.Text += "acos";
        }

        private void ArcTanButton_Click(object sender, EventArgs e)
        {
            ExampleTextBox.Text += "atan";
        }

        private void SinHypButton_Click(object sender, EventArgs e)
        {
            ExampleTextBox.Text += "sinh";
        }

        private void CosHypButton_Click(object sender, EventArgs e)
        {
            ExampleTextBox.Text += "cosh";
        }

        private void TanHypButton_Click(object sender, EventArgs e)
        {
            ExampleTextBox.Text += "tanh";
        }

        private void LogButton_Click(object sender, EventArgs e)
        {
            ExampleTextBox.Text += "log";
        }

        private void LnButton_Click(object sender, EventArgs e)
        {
            ExampleTextBox.Text += "ln";
        }

        private void FactorButton_Click(object sender, EventArgs e)
        {
            ExampleTextBox.Text += "!";
        }

        private void DelXButton_Click(object sender, EventArgs e)
        {
            ExampleTextBox.Text += "1/";
        }

        private void MemDelButton_Click(object sender, EventArgs e)
        {
            MemoryNumberLabel.Text = "0";
        }

        private void MemPlusButton_Click(object sender, EventArgs e)
        {
            ExampleTextBox.Text += memory;
        }

        private void MemMinusButton_Click(object sender, EventArgs e)
        {
        }

        private void MemRemButton_Click(object sender, EventArgs e)
        {
            memory = AnswerTextBox.Text;
            MemoryNumberLabel.Text = memory;
        }

        private void OpenBraketButton_Click(object sender, EventArgs e)
        {
            ExampleTextBox.Text += "(";
        }

        private void CloseBraketButton_Click(object sender, EventArgs e)
        {
            ExampleTextBox.Text += ")";
        }
    }
}