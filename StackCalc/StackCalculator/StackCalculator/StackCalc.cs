namespace StackCalculator
{
    /// <summary>
    /// Класс, реализующий стековый калькулятор
    /// </summary>
    public class StackCalc
    {
        /// <summary>
        /// Стек, необходимый для работы калькулятора
        /// </summary>
        private IStack stack;

        /// <summary>
        /// Конструктор, создающий экземпляр класса
        /// </summary>
        /// <param name="chosenStack">Класс, реализующий интерфейс стека</param>
        public StackCalc(IStack chosenStack)
        {
            stack = chosenStack;
            stack.Clear();
        }

        /// <summary>
        /// Сохраняет число из строки в стек
        /// </summary>
        /// <param name="number"></param>
        private void PushNumber(string number)
        {
            if (number != "")
            {
                stack.Push(System.Int32.Parse(number));
            }
        }

        /// <summary>
        /// Считает выражение в постфиксной форме
        /// </summary>
        /// <param name="expression">Выражение, которое нужно посчитать</param>
        /// <returns></returns>
        public int Calculate(string expression)
        {
            try
            {
                string number = "";
                for (int i = 0; i < expression.Length; i++)
                {
                    int firstOperand;
                    int secondOperand;
                    switch (expression[i])
                    {
                        case '+':
                            PushNumber(number);
                            number = "";
                            secondOperand = stack.Pop();
                            firstOperand = stack.Pop();
                            stack.Push(firstOperand + secondOperand);
                            break;
                        case '-':
                            PushNumber(number);
                            number = "";
                            secondOperand = stack.Pop();
                            firstOperand = stack.Pop();
                            stack.Push(firstOperand - secondOperand);
                            break;
                        case '/':
                            PushNumber(number);
                            number = "";
                            secondOperand = stack.Pop();
                            firstOperand = stack.Pop();
                            stack.Push(firstOperand / secondOperand);
                            break;
                        case '*':
                            PushNumber(number);
                            number = "";
                            secondOperand = stack.Pop();
                            firstOperand = stack.Pop();
                            stack.Push(firstOperand * secondOperand);
                            break;
                        case ' ':
                            PushNumber(number);
                            number = "";
                            break;
                        default:
                            if (expression[i] > '9' || expression[i] < '0')
                            {
                                throw new System.ArgumentException("Некорректный символ");
                            }
                            number += expression[i];
                            break;
                    }
                }
                if (number != "")
                {
                    PushNumber(number);
                    number = "";
                }
                int result = stack.Pop();
                if (!stack.IsEmpty())
                {
                    throw new System.ArgumentException("Некорректное выражение");
                }
                return result;
            }
            catch (EmptyStackException)
            {
                throw new System.ArgumentException("Некорректное выражение");
            }
            catch (System.IndexOutOfRangeException)
            {
                throw new System.ArgumentException("Слишком длинное выражение");
            }

            catch (System.DivideByZeroException)
            {
                throw new System.ArgumentException("Деление на ноль");
            }
        }

    }
}
