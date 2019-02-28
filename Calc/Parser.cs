using System;
using System.Collections;
using System.Text.RegularExpressions;

namespace Calc
{
    public enum Mode { RAD, DEG, GRAD };

    public class Parser
    {
        private string Value;

        public string Evaluate(string expression)
        {
            try
            {
                // Expression = "-(5 - 10)^(-1)  ( 3 + 2(    cos( 3 Pi )+( 2+ ln( exp(1) ) )    ^3))"
                // Убираются пробелы
                // -(5 - 10)^(-1)  ( 3 + 2(    cos( 3 Pi )+( 2+ ln( exp(1) ) )    ^3)) -> -(5-10)^(-1)(3+2(cos(3Pi)+(2+ln(exp(1)))^3))
                expression = expression.Replace(" ", "");
                // Добавление знака умножения, где он необходим для корректных вычислений
                //                                                             _    _      _
                // -(5-10)^(-1)(3+2(cos(3Pi)+(2+ln(exp(1)))^3)) -> -(5-10)^(-1)*(3+2*(cos(3*Pi)+(2+ln(exp(1)))^3))
                //             |   |     |
                /* Расшифровка шаблона Regex
                 * (?<=[\d\)]) если предшествует одна из цифр, закрывающая скобка
                 * (?=[a-df-z\(]) если последует одна из букв, открывающая скобка
                 * | или
                 * (?<=pi) если предшествует pi
                 * (?=[^\+\-\*\/\\^!)]) если последует ни один из символов
                 * | или
                 * (?<=\)) если  предшествует закрывающая скобка
                 * (?=\d) если последует одна из цифр
                 * | или
                 * (?<=[^\/\*\+\-]) если предшествует ни один из символов
                 * (?=exp) если последует exp
                 */
                Regex regEx = new Regex(@"(?<=[\d\)])(?=[a-df-z\(])|(?<=pi)(?=[^\+\-\*\/\\^!)])|(?<=\))(?=\d)|(?<=[^\/\*\+\-\(])(?=exp)", RegexOptions.IgnoreCase);
                expression = regEx.Replace(expression, "*");
                //Замена pi на 3,14
                //                                                                        ____
                // -(5-10)^(-1)*(3+2*(cos(3*Pi)+(2+ln(e))^3)) -> -(5-10)^(-1)*(3+2*(cos(3*3,14)+(2+ln(exp(1)))^3))
                //                          --
                regEx = new Regex("pi", RegexOptions.IgnoreCase);
                expression = regEx.Replace(expression, Math.PI.ToString());
                // Поиск и вычисление выражений в скобках
                //                                                       _____
                // -(5-10)^(-1)*(3+2*(cos(3*3,14)+(2+ln(exp(1)))^3)) -> -{-5}^(-1)*(3+2*(cos(3*3,14)+(2+ln(exp(1)))^3))
                //  |_____|
                //                                                          __
                // -{-5}^(-1)*(3+2*(cos(3*3,14)+(2+ln(exp(1)))^3)) -> -{-5}^-1*(3+2*(cos(3*3,14)+(2+ln(exp(1)))^3))
                //       |__|
                //                                                                    ____
                // -{-5}^-1*(3+2*(cos(3*3,14)+(2+ln(exp(1)))^3)) -> -{-5}^-1*(3+2*(cos9,42+(2+ln(exp(1)))^3))
                //                   |______|
                //                                                                              _
                // -{-5}^-1*(3+2*(cos9,72+(2+ln(exp(1)))^3)) -> -{-5}^-1*(3+2*(cos9,72+(2+ln(exp1))^3))
                //                                 |_|
                //                                                                        ____
                // -{-5}^-1*(3+2*(cos9,72+(2+ln(exp1))^3)) -> -{-5}^-1*(3+2*(cos9,72+(2+ln2,71)^3))
                //                             |____|
                //                                                                 ____
                // -{-5}^-1*(3+2*(cos9,72+(2+ln2,71)^3)) -> -{-5}^-1*(3+2*(cos9,72+{3}^3))
                //                        |_________|
                //                                                 __
                // -{-5}^-1*(3+2*(cos9,72+{3}^3)) -> -{-5}^-1*(3+2*26)
                //               |_____________|
                //                               __
                // -{-5}^-1*(3+2*26) -> -{-5}^-1*55
                //          |______|
                /*Расшифровка шаблона Regex
                 *([a-z]*) - одна из букв
                 * и
                 * \( открывающая скобка
                 * (([^\(\)]+)\) - не скобки
                 * \) закрывающая скобка
                 * и
                 * (\^|!?) - возведение в степень или факториал
                 */
                regEx = new Regex(@"([a-z]*)\(([^\(\)]+)\)(\^|!?)", RegexOptions.IgnoreCase);
                Match m = regEx.Match(expression);
                while (m.Success)
                {
                    if (m.Groups[3].Value.Length > 0)
                    {
                        expression = expression.Replace(m.Value, "{" + m.Groups[1].Value + new Solver().Solve(m.Groups[2].Value) + "}" + m.Groups[3].Value);
                    }
                    else expression = expression.Replace(m.Value, m.Groups[1].Value + new Solver().Solve(m.Groups[2].Value));
                    m = regEx.Match(expression);
                }
                // Если нет скобок, вычисление выражения
                //                __
                // -{-5}^-1*55 => 11
                // |_________|
                //
                Value = new Solver().Solve(expression);
                return Value;
            }
            catch
            {
                // Shit!
                return "error";
            }
        }
    }
}