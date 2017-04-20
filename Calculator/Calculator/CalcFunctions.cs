using System;

namespace Calculator
{
    /// <summary>
    /// Класс, реализующий бизнес-логику калькулятора
    /// </summary>
    public class CalcFunctions
    {
        /// <summary>
        /// Посчитать значение 
        /// </summary>
        /// <param name="currentAnswer">Ответ на данный момент</param>
        /// <param name="currentInput">Ввод пользователя</param>
        /// <param name="previousOperator">Предыдущий оператор</param>
        /// <returns>Возвращает новые значение, ответ </returns>
        public static Tuple<double, double> CalculateCurrentAnswer(double currentAnswer, string currentInput, string previousOperator)
        {
            double currentValue;
            if (currentInput == "")
            {
                currentValue = 0;
            }
            else if (!Double.TryParse(currentInput, out currentValue))
            {
                throw new SyntaxErrorException();
            }
            switch (previousOperator)
            {
                case "+":
                    currentAnswer += currentValue;
                    break;
                case "-":
                    currentAnswer -= currentValue;
                    break;
                case "*":
                    currentAnswer *= currentValue;
                    break;
                case "/":
                    if (currentValue == 0)
                    {
                        throw new DivideByZeroException("Деление на ноль");
                    }
                    currentAnswer /= currentValue;
                    break;
                case "=":
                    currentValue = currentAnswer;
                    break;
                case "":
                    currentAnswer = currentValue;
                    break;
                default:
                    break;
            }
            return Tuple.Create(currentValue, currentAnswer);
        }
    }
}