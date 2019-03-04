using System;
using System.Collections;
using System.Text.RegularExpressions;

namespace Calc
{
    public class Solver
    {
        private ArrayList functionList = new ArrayList(new string[] { "abs", "acos", "asin", "atan", "ceil", "cos", "cosh", "exp", "floor", "ln", "log", "sign", "sin", "sinh", "sqrt", "tan", "tanh" });
        private double factor = 1.0;

        public void RadFactor()
        {
            factor = 1.0;
        }

        public void DegFactor()
        {
            factor = 2.0 * Math.PI / 360.0;
        }

        public void GradFactor()
        {
            factor = 2.0 * Math.PI / 400.0;
        }

        /// <summary>
        /// Решение функций из листа FuctionList
        /// </summary>
        /// <param name="expression">Выражение</param>
        /// <returns>Выражение с вычисленными функциями из листа FunctionList</returns>
        private string SolveAbc(string expression)
        {
            /* Расшифровка шаблона Regex
             * ([a-z]{2,}) - 2 и более букв подряд
             * ([\+-]?\d+,*\d*[eE][\+-]*\d+|[\+-]?\d+,*\d*) - один из знаков + -, цифры, запятая, цифры, e или E(*10^X),один из знаков + -, цифры
             */
            Regex regEx = new Regex(@"([a-z]{2,})([\+-]?\d+,*\d*[eE][\+-]*\d+|[\+-]?\d+,*\d*)", RegexOptions.IgnoreCase);
            Match m = regEx.Match(expression);
            while (m.Success && functionList.IndexOf(m.Groups[1].Value.ToLower()) > -1)
            {
                switch (m.Groups[1].Value.ToLower())
                {
                    case "abs":
                        expression = expression.Replace(m.Groups[0].Value, Math.Abs(Convert.ToDouble(m.Groups[2].Value)).ToString());
                        m = regEx.Match(expression);
                        continue;
                    case "acos":
                        expression = expression.Replace(m.Groups[0].Value, Math.Acos(factor * Convert.ToDouble(m.Groups[2].Value)).ToString());
                        m = regEx.Match(expression);
                        continue;
                    case "asin":
                        expression = expression.Replace(m.Groups[0].Value, Math.Asin(factor * Convert.ToDouble(m.Groups[2].Value)).ToString());
                        m = regEx.Match(expression);
                        continue;
                    case "atan":
                        expression = expression.Replace(m.Groups[0].Value, Math.Atan(factor * Convert.ToDouble(m.Groups[2].Value)).ToString());
                        m = regEx.Match(expression);
                        continue;
                    case "cos":
                        expression = expression.Replace(m.Groups[0].Value, Math.Cos(factor * Convert.ToDouble(m.Groups[2].Value)).ToString());
                        m = regEx.Match(expression);
                        continue;
                    case "ceil":
                        expression = expression.Replace(m.Groups[0].Value, Math.Ceiling(Convert.ToDouble(m.Groups[2].Value)).ToString());
                        m = regEx.Match(expression);
                        continue;
                    case "cosh":
                        expression = expression.Replace(m.Groups[0].Value, Math.Cosh(factor * Convert.ToDouble(m.Groups[2].Value)).ToString());
                        m = regEx.Match(expression);
                        continue;
                    case "exp":
                        expression = expression.Replace(m.Groups[0].Value, Math.Exp(Convert.ToDouble(m.Groups[2].Value)).ToString());
                        m = regEx.Match(expression);
                        continue;
                    case "floor":
                        expression = expression.Replace(m.Groups[0].Value, Math.Floor(Convert.ToDouble(m.Groups[2].Value)).ToString());
                        m = regEx.Match(expression);
                        continue;
                    case "ln":
                        expression = expression.Replace(m.Groups[0].Value, Math.Log(Convert.ToDouble(m.Groups[2].Value), Math.Exp(1.0)).ToString());
                        m = regEx.Match(expression);
                        continue;
                    case "log":
                        expression = expression.Replace(m.Groups[0].Value, Math.Log10(Convert.ToDouble(m.Groups[2].Value)).ToString());
                        m = regEx.Match(expression);
                        continue;
                    case "sign":
                        expression = expression.Replace(m.Groups[0].Value, Math.Sign(Convert.ToDouble(m.Groups[2].Value)).ToString());
                        m = regEx.Match(expression);
                        continue;
                    case "sin":
                        expression = expression.Replace(m.Groups[0].Value, Math.Sin(this.factor * Convert.ToDouble(m.Groups[2].Value)).ToString());
                        m = regEx.Match(expression);
                        continue;
                    case "sinh":
                        expression = expression.Replace(m.Groups[0].Value, Math.Sinh(this.factor * Convert.ToDouble(m.Groups[2].Value)).ToString());
                        m = regEx.Match(expression);
                        continue;
                    case "sqrt":
                        expression = expression.Replace(m.Groups[0].Value, Math.Sqrt(Convert.ToDouble(m.Groups[2].Value)).ToString());
                        m = regEx.Match(expression);
                        continue;
                    case "tan":
                        expression = expression.Replace(m.Groups[0].Value, Math.Tan(this.factor * Convert.ToDouble(m.Groups[2].Value)).ToString());
                        m = regEx.Match(expression);
                        continue;
                    case "tanh":
                        expression = expression.Replace(m.Groups[0].Value, Math.Tanh(this.factor * Convert.ToDouble(m.Groups[2].Value)).ToString());
                        m = regEx.Match(expression);
                        continue;
                }
            }
            return expression;
        }

        /// <summary>
        /// Нахождение факториала
        /// </summary>
        /// <param name="expression">Выражение</param>
        /// <returns>Выражение с вычисленным факториалом</returns>
        private string SolveFactorial(string expression)
        {
            // Шаблон Regex для {x}!
            Regex regEx = new Regex(@"\{(.+)\}!");
            Match m = regEx.Match(expression);
            while (m.Success)
            {
                double n = Convert.ToDouble(m.Groups[1].Value);
                if ((n < 0) || (n != Math.Round(n)))
                {
                    expression = "factorial solve error";
                    break;
                    // Если значение отрицательное или не целое - выдать ошибку
                }
                expression = regEx.Replace(expression, Fact(Convert.ToDouble(m.Groups[1].Value)).ToString(), 1);
                m = regEx.Match(expression);
            }

            // Расшифровка шаблона Regex  - цифры, запятая, цифры, e или E(*10^X),один из знаков + -, цифры, знак факториала
            /*
             */
            regEx = new Regex(@"(\d|[a-z]|[\(\)])*([\+\-\*\/\(\)])*(\d+,*\d*[eE][\+-]?\d+|\d+,*\d*)!");
            m = regEx.Match(expression);
            while (m.Success)
            {
                if (m.Groups[1].Value.Length == 0)
                {
                    if (m.Groups[2].Value == "-")
                    {
                        expression = "factorial solve error";
                        break;
                    }
                }

                double n = Convert.ToDouble(m.Groups[3].Value);
                if ((n < 0) || (n != Math.Round(n)))
                {
                    expression = "factorial solve error";
                    break;
                    // Если значение отрицательное или не целое - выдать ошибку
                }
                else
                {
                    expression = regEx.Replace(expression, m.Groups[1].Value + m.Groups[2].Value + Fact(Convert.ToDouble(m.Groups[3].Value)).ToString(), 1);
                    m = regEx.Match(expression);
                }
            }
            return expression;
        }

        // Вычисление факториала
        private double Fact(double n)
        {
            return n == 0.0 ? 1.0 : n * Fact(n - 1.0);
        }

        /// <summary>
        /// Вычисление степени
        /// </summary>
        /// <param name="expression"></param>
        /// <returns>Выражение с числами возведенными в степень</returns>
        public string SolvePower(string expression)
        {
            /* Расшифровка шаблона Regex для варианта {-x}^-y
             * \{(.+)\}\ - цифры в фигурных скобках
             * (-?\d+,*\d*[eE][\+-]?\d+|-?\d+,*\d*) - знак -, цифры, запятая, цифры,  e или E(*10^X),один из знаков + -, цифры или знак -, цифры, запятая, цифры
             */
            Regex regEx = new Regex(@"\{(.+)\}\^(-?\d+,*\d*[eE][\+-]?\d+|-?\d+,*\d*)");
            Match m = regEx.Match(expression, 0);
            while (m.Success)
            {
                expression = expression.Replace(m.Value, Math.Pow(Convert.ToDouble(m.Groups[1].Value), Convert.ToDouble(m.Groups[2].Value)).ToString());
                m = regEx.Match(expression);
            }
            /* Расшифровка шаблона Regex для варианта x^-y
             * (\d+,*\d*e[\+-]?\d+|\d+,*\d*) - цифры, запятая, цифры, е, один из знаков +-, цифры или цифры, запятая, цифры
             * (-?\d+,*\d*[eE][\+-]?\d+|-?\d+,*\d*) - знак -, цифры, запятая, цифры, один из е Е, один из знаков + -, цифры или знак -,цифры,запятая,цифры
             */
            regEx = new Regex(@"(-?\d+,*\d*e[\+-]?\d+|-?\d+,*\d*)\^(-?\d+,*\d*[eE][\+-]?\d+|-?\d+,*\d*)");
            m = regEx.Match(expression, 0);
            while (m.Success)
            {
                expression = regEx.Replace(expression, Math.Pow(Convert.ToDouble(m.Groups[1].Value), Convert.ToDouble(m.Groups[2].Value)).ToString(), 1);
                m = regEx.Match(expression);
            }
            return expression;
        }

        /// <summary>
        /// Вычисление умножения и деления
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        private string SolveMultiDivis(string expression)
        {
            /* Расшифровка шаблона Regex
             * ([\+-]?\d+,*\d*[eE][\+-]?\d+|[\-\+]?\d+,*\d*) - один из знаков + -, цифры, запятая, цифры, один из е Е, один из знаков + -, цифры или один из знаков + -,цифры,запятая,цифры
             * ([\/\*]) - один из знаков * /
             * (-?\d+,*\d*[eE][\+-]?\d+|-?\d+,*\d*) - знак -, цифры, запятая, цифры, один из е Е, один из знаков + -, цифры или знак -,цифры,запятая,цифры
             */
            Regex regEx = new Regex(@"([\+-]?\d+,*\d*[eE][\+-]?\d+|[\-\+]?\d+,*\d*)([\/\*])(-?\d+,*\d*[eE][\+-]?\d+|-?\d+,*\d*)");
            Match m = regEx.Match(expression, 0);
            while (m.Success)
            {
                double result;
                switch (m.Groups[2].Value)
                {
                    case "*":
                        result = Convert.ToDouble(m.Groups[1].Value) * Convert.ToDouble(m.Groups[3].Value);
                        if ((result < 0) || (m.Index == 0))
                        {
                            expression = regEx.Replace(expression, result.ToString(), 1);
                        }
                        else
                        {
                            expression = expression.Replace(m.Value, "+" + result);
                        }
                        m = regEx.Match(expression);
                        continue;
                    case "/":
                        result = Convert.ToDouble(m.Groups[1].Value) / Convert.ToDouble(m.Groups[3].Value);
                        if ((result < 0) || (m.Index == 0))
                        {
                            expression = regEx.Replace(expression, result.ToString(), 1);
                        }
                        else
                        {
                            expression = regEx.Replace(expression, "+" + result, 1);
                        }
                        m = regEx.Match(expression);
                        continue;
                }
            }
            return expression;
        }

        /// <summary>
        /// Вычисление суммы и разности
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        private string SolveAddSubtract(string expression)
        {
            /* Расшифровка шаблоа Regex
             * ([\+-]?\d+,*\d*[eE][\+-]?\d+|[\-\+]?\d+,*\d*) - один из знаков + -, цифры, запятая, цифры, один из е Е, один из знаков + -, цифры или один из знаков + -,цифры,запятая,цифры
             * ([\+-]) - один из знаков + -
             * (-?\d+,*\d*[eE][\+-]?\d+|-?\d+,*\d*) - знак -, цифры, запятая, цифры, один из е Е, один из знаков + -, цифры или знак -,цифры,запятая,цифры
             */
            Regex regEx = new Regex(@"([\+-]?\d+,*\d*[eE][\+-]?\d+|[\+-]?\d+,*\d*)([\+-])(-?\d+,*\d*[eE][\+-]?\d+|-?\d+,*\d*)");
            Match m = regEx.Match(expression, 0);
            while (m.Success)
            {
                double result;
                switch (m.Groups[2].Value)
                {
                    case "+":
                        result = Convert.ToDouble(m.Groups[1].Value) + Convert.ToDouble(m.Groups[3].Value);
                        if ((result < 0) || (m.Index == 0))
                        {
                            expression = regEx.Replace(expression, result.ToString(), 1);
                        }
                        else
                        {
                            expression = regEx.Replace(expression, "+" + result, 1);
                        }
                        m = regEx.Match(expression);
                        continue;
                    case "-":
                        result = Convert.ToDouble(m.Groups[1].Value) - Convert.ToDouble(m.Groups[3].Value);
                        if ((result < 0) || (m.Index == 0))
                        {
                            expression = regEx.Replace(expression, result.ToString(), 1);
                        }
                        else
                        {
                            expression = regEx.Replace(expression, "+" + result, 1);
                        }
                        m = regEx.Match(expression);
                        continue;
                }
            }
            return expression;
        }

        public string Solve(string expression)
        {
            expression = SolveAbc(expression);
            expression = SolveFactorial(expression);
            expression = SolvePower(expression);
            expression = SolveMultiDivis(expression);
            expression = SolveAddSubtract(expression);

            if (expression.StartsWith("--")) expression = expression.Substring(2);
            return expression;
        }
    }
}