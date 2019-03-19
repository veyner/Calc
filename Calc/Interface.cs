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
            exampleTextBox.SelectionStart = exampleTextBox.Text.Length;
        }

        private void ExpButton_Click(object sender, EventArgs e)
        {
            //exampleTextBox.Text += "exp";
            var insertText = "exp";
            var selectionIndex = exampleTextBox.SelectionStart;
            exampleTextBox.Text = exampleTextBox.Text.Insert(selectionIndex, insertText);
            exampleTextBox.SelectionStart = selectionIndex + insertText.Length;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //exampleTextBox.Text += "1";
            var insertText = "1";
            var selectionIndex = exampleTextBox.SelectionStart;
            exampleTextBox.Text = exampleTextBox.Text.Insert(selectionIndex, insertText);
            exampleTextBox.SelectionStart = selectionIndex + insertText.Length;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //exampleTextBox.Text += "2";
            var insertText = "2";
            var selectionIndex = exampleTextBox.SelectionStart;
            exampleTextBox.Text = exampleTextBox.Text.Insert(selectionIndex, insertText);
            exampleTextBox.SelectionStart = selectionIndex + insertText.Length;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            //exampleTextBox.Text += "3";
            var insertText = "3";
            var selectionIndex = exampleTextBox.SelectionStart;
            exampleTextBox.Text = exampleTextBox.Text.Insert(selectionIndex, insertText);
            exampleTextBox.SelectionStart = selectionIndex + insertText.Length;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            //exampleTextBox.Text += "4";
            var insertText = "4";
            var selectionIndex = exampleTextBox.SelectionStart;
            exampleTextBox.Text = exampleTextBox.Text.Insert(selectionIndex, insertText);
            exampleTextBox.SelectionStart = selectionIndex + insertText.Length;
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            //exampleTextBox.Text += "5";
            var insertText = "5";
            var selectionIndex = exampleTextBox.SelectionStart;
            exampleTextBox.Text = exampleTextBox.Text.Insert(selectionIndex, insertText);
            exampleTextBox.SelectionStart = selectionIndex + insertText.Length;
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            //exampleTextBox.Text += "6";
            var insertText = "6";
            var selectionIndex = exampleTextBox.SelectionStart;
            exampleTextBox.Text = exampleTextBox.Text.Insert(selectionIndex, insertText);
            exampleTextBox.SelectionStart = selectionIndex + insertText.Length;
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            //exampleTextBox.Text += "7";
            var insertText = "7";
            var selectionIndex = exampleTextBox.SelectionStart;
            exampleTextBox.Text = exampleTextBox.Text.Insert(selectionIndex, insertText);
            exampleTextBox.SelectionStart = selectionIndex + insertText.Length;
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            //exampleTextBox.Text += "8";
            var insertText = "8";
            var selectionIndex = exampleTextBox.SelectionStart;
            exampleTextBox.Text = exampleTextBox.Text.Insert(selectionIndex, insertText);
            exampleTextBox.SelectionStart = selectionIndex + insertText.Length;
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            //exampleTextBox.Text += "9";
            var insertText = "9";
            var selectionIndex = exampleTextBox.SelectionStart;
            exampleTextBox.Text = exampleTextBox.Text.Insert(selectionIndex, insertText);
            exampleTextBox.SelectionStart = selectionIndex + insertText.Length;
        }

        private void PlusButton_Click(object sender, EventArgs e)
        {
            //exampleTextBox.Text += "+";
            var insertText = "+";
            var selectionIndex = exampleTextBox.SelectionStart;
            exampleTextBox.Text = exampleTextBox.Text.Insert(selectionIndex, insertText);
            exampleTextBox.SelectionStart = selectionIndex + insertText.Length;
        }

        private void MinusButton_Click(object sender, EventArgs e)
        {
            //exampleTextBox.Text += "-";
            var insertText = "-";
            var selectionIndex = exampleTextBox.SelectionStart;
            exampleTextBox.Text = exampleTextBox.Text.Insert(selectionIndex, insertText);
            exampleTextBox.SelectionStart = selectionIndex + insertText.Length;
        }

        private void DivButton_Click(object sender, EventArgs e)
        {
            //exampleTextBox.Text += "/";
            var insertText = "/";
            var selectionIndex = exampleTextBox.SelectionStart;
            exampleTextBox.Text = exampleTextBox.Text.Insert(selectionIndex, insertText);
            exampleTextBox.SelectionStart = selectionIndex + insertText.Length;
        }

        private void MultiplButton_Click(object sender, EventArgs e)
        {
            //exampleTextBox.Text += "*";
            var insertText = "*";
            var selectionIndex = exampleTextBox.SelectionStart;
            exampleTextBox.Text = exampleTextBox.Text.Insert(selectionIndex, insertText);
            exampleTextBox.SelectionStart = selectionIndex + insertText.Length;
        }

        private void EqualButton_Click(object sender, EventArgs e)
        {
            var result = new Parser(solver).Evaluate(exampleTextBox.Text);

            var k = double.TryParse(result, out double a);
            if (k == false)
            {
                answerTextBox.Text = "error, incorrect expression";
            }
            else
            {
                answerTextBox.Text = result;
                exampleTextBox.Text = result;
            }
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
            //exampleTextBox.Text += "sqrt";
            var insertText = "sqrt";
            var selectionIndex = exampleTextBox.SelectionStart;
            exampleTextBox.Text = exampleTextBox.Text.Insert(selectionIndex, insertText);
            exampleTextBox.SelectionStart = selectionIndex + insertText.Length;
        }

        private void InvolButton_Click(object sender, EventArgs e)
        {
            //exampleTextBox.Text += "^";
            var insertText = "^";
            var selectionIndex = exampleTextBox.SelectionStart;
            exampleTextBox.Text = exampleTextBox.Text.Insert(selectionIndex, insertText);
            exampleTextBox.SelectionStart = selectionIndex + insertText.Length;
        }

        private void Button0_Click(object sender, EventArgs e)
        {
            //exampleTextBox.Text += "0";
            var insertText = "0";
            var selectionIndex = exampleTextBox.SelectionStart;
            exampleTextBox.Text = exampleTextBox.Text.Insert(selectionIndex, insertText);
            exampleTextBox.SelectionStart = selectionIndex + insertText.Length;
        }

        private void ButtonDot_Click(object sender, EventArgs e)
        {
            //exampleTextBox.Text += ",";
            var insertText = ",";
            var selectionIndex = exampleTextBox.SelectionStart;
            exampleTextBox.Text = exampleTextBox.Text.Insert(selectionIndex, insertText);
            exampleTextBox.SelectionStart = selectionIndex + insertText.Length;
        }

        private void SinButton_Click(object sender, EventArgs e)
        {
            //exampleTextBox.Text += "sin";
            var insertText = "sin";
            var selectionIndex = exampleTextBox.SelectionStart;
            exampleTextBox.Text = exampleTextBox.Text.Insert(selectionIndex, insertText);
            exampleTextBox.SelectionStart = selectionIndex + insertText.Length;
        }

        private void CosButton_Click(object sender, EventArgs e)
        {
            //exampleTextBox.Text += "cos";
            var insertText = "cos";
            var selectionIndex = exampleTextBox.SelectionStart;
            exampleTextBox.Text = exampleTextBox.Text.Insert(selectionIndex, insertText);
            exampleTextBox.SelectionStart = selectionIndex + insertText.Length;
        }

        private void TanButton_Click(object sender, EventArgs e)
        {
            //exampleTextBox.Text += "tan";
            var insertText = "tan";
            var selectionIndex = exampleTextBox.SelectionStart;
            exampleTextBox.Text = exampleTextBox.Text.Insert(selectionIndex, insertText);
            exampleTextBox.SelectionStart = selectionIndex + insertText.Length;
        }

        private void ArcSinButton_Click(object sender, EventArgs e)
        {
            //exampleTextBox.Text += "asin";
            var insertText = "asin";
            var selectionIndex = exampleTextBox.SelectionStart;
            exampleTextBox.Text = exampleTextBox.Text.Insert(selectionIndex, insertText);
            exampleTextBox.SelectionStart = selectionIndex + insertText.Length;
        }

        private void ArcCosButton_Click(object sender, EventArgs e)
        {
            //exampleTextBox.Text += "acos";
            var insertText = "acos";
            var selectionIndex = exampleTextBox.SelectionStart;
            exampleTextBox.Text = exampleTextBox.Text.Insert(selectionIndex, insertText);
            exampleTextBox.SelectionStart = selectionIndex + insertText.Length;
        }

        private void ArcTanButton_Click(object sender, EventArgs e)
        {
            //exampleTextBox.Text += "atan";
            var insertText = "atan";
            var selectionIndex = exampleTextBox.SelectionStart;
            exampleTextBox.Text = exampleTextBox.Text.Insert(selectionIndex, insertText);
            exampleTextBox.SelectionStart = selectionIndex + insertText.Length;
        }

        private void SinHypButton_Click(object sender, EventArgs e)
        {
            //exampleTextBox.Text += "sinh";
            var insertText = "sinh";
            var selectionIndex = exampleTextBox.SelectionStart;
            exampleTextBox.Text = exampleTextBox.Text.Insert(selectionIndex, insertText);
            exampleTextBox.SelectionStart = selectionIndex + insertText.Length;
        }

        private void CosHypButton_Click(object sender, EventArgs e)
        {
            //exampleTextBox.Text += "cosh";
            var insertText = "cosh";
            var selectionIndex = exampleTextBox.SelectionStart;
            exampleTextBox.Text = exampleTextBox.Text.Insert(selectionIndex, insertText);
            exampleTextBox.SelectionStart = selectionIndex + insertText.Length;
        }

        private void TanHypButton_Click(object sender, EventArgs e)
        {
            //exampleTextBox.Text += "tanh";
            var insertText = "tanh";
            var selectionIndex = exampleTextBox.SelectionStart;
            exampleTextBox.Text = exampleTextBox.Text.Insert(selectionIndex, insertText);
            exampleTextBox.SelectionStart = selectionIndex + insertText.Length;
        }

        private void LogButton_Click(object sender, EventArgs e)
        {
            //exampleTextBox.Text += "log";
            var insertText = "log";
            var selectionIndex = exampleTextBox.SelectionStart;
            exampleTextBox.Text = exampleTextBox.Text.Insert(selectionIndex, insertText);
            exampleTextBox.SelectionStart = selectionIndex + insertText.Length;
        }

        private void LnButton_Click(object sender, EventArgs e)
        {
            //exampleTextBox.Text += "ln";
            var insertText = "ln";
            var selectionIndex = exampleTextBox.SelectionStart;
            exampleTextBox.Text = exampleTextBox.Text.Insert(selectionIndex, insertText);
            exampleTextBox.SelectionStart = selectionIndex + insertText.Length;
        }

        private void FactorButton_Click(object sender, EventArgs e)
        {
            //exampleTextBox.Text += "!";
            var insertText = "!";
            var selectionIndex = exampleTextBox.SelectionStart;
            exampleTextBox.Text = exampleTextBox.Text.Insert(selectionIndex, insertText);
            exampleTextBox.SelectionStart = selectionIndex + insertText.Length;
        }

        private void DelXButton_Click(object sender, EventArgs e)
        {
            exampleTextBox.Text = "1/" + exampleTextBox.Text;
        }

        private void MemDelButton_Click(object sender, EventArgs e)
        {
            memoryNumberLabel.Text = "0";
        }

        private void MemPlusButton_Click(object sender, EventArgs e)
        {
            memory = (int.Parse(memory) + int.Parse(answerTextBox.Text)).ToString();
            memoryNumberLabel.Text = memory;
        }

        private void MemMinusButton_Click(object sender, EventArgs e)
        {
            memory = (int.Parse(memory) - int.Parse(answerTextBox.Text)).ToString();
            memoryNumberLabel.Text = memory;
        }

        private void MemRemButton_Click(object sender, EventArgs e)
        {
            var insertText = memory;
            var selectionIndex = exampleTextBox.SelectionStart;
            exampleTextBox.Text = exampleTextBox.Text.Insert(selectionIndex, insertText);
            exampleTextBox.SelectionStart = selectionIndex + insertText.Length;
        }

        private void MemSaveButton_Click(object sender, EventArgs e)
        {
            var k = double.TryParse(answerTextBox.Text, out double a);
            if (k)
            {
                memory = answerTextBox.Text;
                memoryNumberLabel.Text = memory;
            }
        }

        private void OpenBraketButton_Click(object sender, EventArgs e)
        {
            //exampleTextBox.Text += "(";
            var insertText = "(";
            var selectionIndex = exampleTextBox.SelectionStart;
            exampleTextBox.Text = exampleTextBox.Text.Insert(selectionIndex, insertText);
            exampleTextBox.SelectionStart = selectionIndex + insertText.Length;
        }

        private void CloseBraketButton_Click(object sender, EventArgs e)
        {
            //exampleTextBox.Text += ")";
            var insertText = ")";
            var selectionIndex = exampleTextBox.SelectionStart;
            exampleTextBox.Text = exampleTextBox.Text.Insert(selectionIndex, insertText);
            exampleTextBox.SelectionStart = selectionIndex + insertText.Length;
        }

        private void RadRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            solver.RadFactor();
        }

        private void DegRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            solver.DegFactor();
        }

        private void GradRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            solver.GradFactor();
        }
    }
}