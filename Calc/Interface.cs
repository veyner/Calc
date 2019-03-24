using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Text.RegularExpressions;

namespace Calc
{
    public partial class Interface : Form
    {
        private string[] functionList = new string[] { "abs", "acos", "asin", "atan", "ceil", "cos", "cosh", "exp", "floor", "ln", "log", "sign", "sin", "sinh", "sqrt", "tan", "tanh" };
        private string[] operationList = new string[] { "+", "-", "/", "*", "^", "," };
        private string memory = "0";
        private Solver solver;
        private int openBracket = 0;

        public Interface()
        {
            InitializeComponent();
            solver = new Solver();
            RadRadioButton.Select();
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
            InsertFunction("exp", functionList);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //exampleTextBox.Text += "1";
            InsertSymbol("1");
            //var insertText = "1";
            //var selectionIndex = exampleTextBox.SelectionStart;
            //exampleTextBox.Text = exampleTextBox.Text.Insert(selectionIndex, insertText);
            //exampleTextBox.SelectionStart = selectionIndex + insertText.Length;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //exampleTextBox.Text += "2";
            InsertSymbol("2");
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            //exampleTextBox.Text += "3";
            InsertSymbol("3");
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            //exampleTextBox.Text += "4";
            InsertSymbol("4");
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            //exampleTextBox.Text += "5";
            InsertSymbol("5");
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            //exampleTextBox.Text += "6";
            InsertSymbol("6");
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            //exampleTextBox.Text += "7";
            InsertSymbol("7");
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            //exampleTextBox.Text += "8";
            InsertSymbol("8");
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            //exampleTextBox.Text += "9";
            InsertSymbol("9");
        }

        private void PlusButton_Click(object sender, EventArgs e)
        {
            //exampleTextBox.Text += "+";
            InsertFunction("+", operationList);
        }

        private void MinusButton_Click(object sender, EventArgs e)
        {
            //exampleTextBox.Text += "-";
            InsertFunction("-", operationList);
        }

        private void DivButton_Click(object sender, EventArgs e)
        {
            //exampleTextBox.Text += "/";
            InsertFunction("/", operationList);
        }

        private void MultiplButton_Click(object sender, EventArgs e)
        {
            //exampleTextBox.Text += "*";
            InsertFunction("*", operationList);
        }

        private void EqualButton_Click(object sender, EventArgs e)
        {
            var result = new Parser(solver).Evaluate(exampleTextBox.Text);

            var k = double.TryParse(result, out double a);
            if (!k)
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
            // возможность удалить символ по текущему положению курсора
            var selectionIndex = exampleTextBox.SelectionStart;
            var text = exampleTextBox.Text;
            string left = text.Substring(0, selectionIndex);
            string right = text.Substring(selectionIndex);
            if (!string.IsNullOrWhiteSpace(left))
            {
                left = left.Substring(0, left.Length - 1);
            }
            exampleTextBox.Text = left + right;
            exampleTextBox.SelectionStart = left.Length;
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
            InsertFunction("sqrt", functionList);
        }

        private void InvolButton_Click(object sender, EventArgs e)
        {
            //exampleTextBox.Text += "^";
            InsertFunction("^", operationList);
        }

        private void Button0_Click(object sender, EventArgs e)
        {
            //exampleTextBox.Text += "0";
            InsertSymbol("0");
        }

        private void ButtonDot_Click(object sender, EventArgs e)
        {
            //exampleTextBox.Text += ",";
            InsertFunction(",", operationList);
        }

        private void SinButton_Click(object sender, EventArgs e)
        {
            //exampleTextBox.Text += "sin";
            InsertFunction("sin", functionList);
        }

        private void CosButton_Click(object sender, EventArgs e)
        {
            //exampleTextBox.Text += "cos";
            InsertFunction("cos", functionList);
        }

        private void TanButton_Click(object sender, EventArgs e)
        {
            //exampleTextBox.Text += "tan";
            InsertFunction("tan", functionList);
        }

        private void ArcSinButton_Click(object sender, EventArgs e)
        {
            //exampleTextBox.Text += "asin";
            InsertFunction("asin", functionList);
        }

        private void ArcCosButton_Click(object sender, EventArgs e)
        {
            //exampleTextBox.Text += "acos";
            InsertFunction("acos", functionList);
        }

        private void ArcTanButton_Click(object sender, EventArgs e)
        {
            //exampleTextBox.Text += "atan";
            InsertFunction("atan", functionList);
        }

        private void SinHypButton_Click(object sender, EventArgs e)
        {
            //exampleTextBox.Text += "sinh";
            InsertFunction("sinh", functionList);
        }

        private void CosHypButton_Click(object sender, EventArgs e)
        {
            //exampleTextBox.Text += "cosh";
            InsertFunction("cosh", functionList);
        }

        private void TanHypButton_Click(object sender, EventArgs e)
        {
            //exampleTextBox.Text += "tanh";
            InsertFunction("tanh", functionList);
        }

        private void LogButton_Click(object sender, EventArgs e)
        {
            //exampleTextBox.Text += "log";
            InsertFunction("log", functionList);
        }

        private void LnButton_Click(object sender, EventArgs e)
        {
            //exampleTextBox.Text += "ln";
            InsertFunction("ln", functionList);
        }

        private void FactorButton_Click(object sender, EventArgs e)
        {
            //exampleTextBox.Text += "!";
            InsertSymbol("!");
        }

        private void DelXButton_Click(object sender, EventArgs e)
        {
            exampleTextBox.Text = "1/" + exampleTextBox.Text;
        }

        private void MemDelButton_Click(object sender, EventArgs e)
        {
            memoryNumberLabel.Text = "0";
            memory = "0";
        }

        private void MemPlusButton_Click(object sender, EventArgs e)
        {
            var k = double.TryParse(answerTextBox.Text, out double a);
            if (k)
            {
                memory = (int.Parse(memory) + int.Parse(answerTextBox.Text)).ToString();
                memoryNumberLabel.Text = memory;
            }
        }

        private void MemMinusButton_Click(object sender, EventArgs e)
        {
            var k = double.TryParse(answerTextBox.Text, out double a);
            if (k)
            {
                memory = (int.Parse(memory) - int.Parse(answerTextBox.Text)).ToString();
                memoryNumberLabel.Text = memory;
            }
        }

        private void MemRemButton_Click(object sender, EventArgs e)
        {
            InsertSymbol(memory);
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
            InsertSymbol("(");
            openBracket++;
            openBraketButton.Text = "( " + openBracket;
        }

        private void CloseBraketButton_Click(object sender, EventArgs e)
        {
            //exampleTextBox.Text += ")";
            if (openBracket > 0)
            {
                InsertSymbol(")");
                openBracket--;
                openBraketButton.Text = "( " + openBracket;
                if (openBracket == 0)
                {
                    openBraketButton.Text = "( ";
                }
            }
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

        /// <summary>
        /// Проверка последних введенных символов в строку (там где стоит курсор)
        /// если там стояла функция, то произойдет замена на введенную функцию
        /// </summary>
        /// <param name="example">строка, где нужно проверить/заменить функцию</param>
        /// <param name="function">текущая введенная функция</param>
        /// <param name="functions">лист функций</param>
        /// <returns></returns>
        private string ChangeFunction(string example, string function, string[] functions)
        {
            string newExample = example;
            foreach (string func in functions)
            {
                if (example.EndsWith(func))
                {
                    newExample = example.Substring(0, example.Length - func.Length);
                    break;
                }
            }
            return newExample + function;
        }

        /// <summary>
        /// Метод для ввода функции в строку
        /// </summary>
        /// <param name="func">введенная функция</param>
        /// <param name="functions">лист функций для метода проверки и замены функций</param>
        private void InsertFunction(string func, string[] functions)
        {
            var selectionIndex = exampleTextBox.SelectionStart; //текущее положение курсора, который разделяет строку на 2 части
            var text = exampleTextBox.Text;
            //Разделение строки - возможность ввести функцию или символ по текущему положению курсора и для проверки и замены повторно введенной функции
            string left = text.Substring(0, selectionIndex); // левая часть строки
            string right = text.Substring(selectionIndex); // правая часть строки
            left = ChangeFunction(left, func, functions);
            exampleTextBox.Text = left + right;
            exampleTextBox.SelectionStart = left.Length; // установка курсора в место, где он должен находиться после подстановки функции в строку
        }

        /// <summary>
        /// ввод символов в строку
        /// </summary>
        /// <param name="symbol">текущий введенный символ</param>
        private void InsertSymbol(string symbol)
        {
            var selectionIndex = exampleTextBox.SelectionStart;
            var text = exampleTextBox.Text;
            string left = text.Substring(0, selectionIndex);
            string right = text.Substring(selectionIndex);
            left += symbol;
            exampleTextBox.Text = left + right;
            exampleTextBox.SelectionStart = left.Length;
        }
    }
}