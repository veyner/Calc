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
    public partial class Interface : Form
    {
        private string memory = "0";
        private Solver solver;

        public Interface()
        {
            InitializeComponent();
            solver = new Solver();
        }

        private void Interface_Load(object sender, EventArgs e)
        {
            answerTextBox.Text = "0";
        }

        private void AnswerTextBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void ExampleTextBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void ExpButton_Click(object sender, EventArgs e)
        {
            exampleTextBox.Text += "exp";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            exampleTextBox.Text += "1";
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            exampleTextBox.Text += "2";
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            exampleTextBox.Text += "3";
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            exampleTextBox.Text += "4";
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            exampleTextBox.Text += "5";
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            exampleTextBox.Text += "6";
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            exampleTextBox.Text += "7";
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            exampleTextBox.Text += "8";
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            exampleTextBox.Text += "9";
        }

        private void PlusButton_Click(object sender, EventArgs e)
        {
            exampleTextBox.Text += "+";
        }

        private void MinusButton_Click(object sender, EventArgs e)
        {
            exampleTextBox.Text += "-";
        }

        private void DivButton_Click(object sender, EventArgs e)
        {
            exampleTextBox.Text += "/";
        }

        private void MultiplButton_Click(object sender, EventArgs e)
        {
            exampleTextBox.Text += "*";
        }

        private void EqualButton_Click(object sender, EventArgs e)
        {
            var result = new Parser(solver).Evaluate(exampleTextBox.Text);
            answerTextBox.Text = result.ToString();
        }

        private void BackSpaceButton_Click(object sender, EventArgs e)
        {
            var expression = exampleTextBox.Text;
            string newExpression = "";
            if (expression.Length > 0)
            {
                newExpression = expression.Remove(expression.Length - 1);
            }
            if (expression.Length == 0)
            {
                newExpression = expression;
            }
            exampleTextBox.Text = newExpression;
        }

        private void DelButton_Click(object sender, EventArgs e)
        {
            answerTextBox.Text = "0";
        }

        private void DelAllButton_Click(object sender, EventArgs e)
        {
            exampleTextBox.Text = null;
            answerTextBox.Text = "0";
        }

        private void SqrtButton_Click(object sender, EventArgs e)
        {
            exampleTextBox.Text += "sqrt";
        }

        private void InvolButton_Click(object sender, EventArgs e)
        {
            exampleTextBox.Text += "^";
        }

        private void Button0_Click(object sender, EventArgs e)
        {
            exampleTextBox.Text += "0";
        }

        private void ButtonDot_Click(object sender, EventArgs e)
        {
            exampleTextBox.Text += ",";
        }

        private void SinButton_Click(object sender, EventArgs e)
        {
            exampleTextBox.Text += "sin";
        }

        private void CosButton_Click(object sender, EventArgs e)
        {
            exampleTextBox.Text += "cos";
        }

        private void TanButton_Click(object sender, EventArgs e)
        {
            exampleTextBox.Text += "tan";
        }

        private void ArcSinButton_Click(object sender, EventArgs e)
        {
            exampleTextBox.Text += "asin";
        }

        private void ArcCosButton_Click(object sender, EventArgs e)
        {
            exampleTextBox.Text += "acos";
        }

        private void ArcTanButton_Click(object sender, EventArgs e)
        {
            exampleTextBox.Text += "atan";
        }

        private void SinHypButton_Click(object sender, EventArgs e)
        {
            exampleTextBox.Text += "sinh";
        }

        private void CosHypButton_Click(object sender, EventArgs e)
        {
            exampleTextBox.Text += "cosh";
        }

        private void TanHypButton_Click(object sender, EventArgs e)
        {
            exampleTextBox.Text += "tanh";
        }

        private void LogButton_Click(object sender, EventArgs e)
        {
            exampleTextBox.Text += "log";
        }

        private void LnButton_Click(object sender, EventArgs e)
        {
            exampleTextBox.Text += "ln";
        }

        private void FactorButton_Click(object sender, EventArgs e)
        {
            exampleTextBox.Text += "!";
        }

        private void DelXButton_Click(object sender, EventArgs e)
        {
            exampleTextBox.Text += "1/";
        }

        private void MemDelButton_Click(object sender, EventArgs e)
        {
            memoryNumberLabel.Text = "0";
        }

        private void MemPlusButton_Click(object sender, EventArgs e)
        {
            exampleTextBox.Text += memory;
        }

        private void MemMinusButton_Click(object sender, EventArgs e)
        {
        }

        private void MemRemButton_Click(object sender, EventArgs e)
        {
            memory = answerTextBox.Text;
            memoryNumberLabel.Text = memory;
        }

        private void OpenBraketButton_Click(object sender, EventArgs e)
        {
            exampleTextBox.Text += "(";
        }

        private void CloseBraketButton_Click(object sender, EventArgs e)
        {
            exampleTextBox.Text += ")";
        }

        private void RadButton_Click(object sender, EventArgs e)
        {
            modLabel.Text = "Rad";
            solver.RadFactor();
        }

        private void DegButton_Click(object sender, EventArgs e)
        {
            modLabel.Text = "Deg";
            solver.DegFactor();
        }

        private void GradButton_Click(object sender, EventArgs e)
        {
            modLabel.Text = "Grad";
            solver.GradFactor();
        }
    }
}