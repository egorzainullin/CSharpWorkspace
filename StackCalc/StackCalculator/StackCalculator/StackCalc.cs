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
        private void PushNumber(ref string number)
        {
            if (number != "")
            {
                stack.Push(System.Int32.Parse(number));
            }
            number = "";
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
                            PushNumber(ref number);
                            secondOperand = stack.Pop();
                            firstOperand = stack.Pop();
                            stack.Push(firstOperand + secondOperand);
                            break;
                        case '-':
                            PushNumber(ref number);
                            secondOperand = stack.Pop();
                            firstOperand = stack.Pop();
                            stack.Push(firstOperand - secondOperand);
                            break;
                        case '/':
                            PushNumber(ref number);
                            secondOperand = stack.Pop();
                            firstOperand = stack.Pop();
                            stack.Push(firstOperand / secondOperand);
                            break;
                        case '*':
                            PushNumber(ref number);
                            secondOperand = stack.Pop();
                            firstOperand = stack.Pop();
                            stack.Push(firstOperand * secondOperand);
                            break;
                        case ' ':
                            PushNumber(ref number);
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
                    PushNumber(ref number);
                }
            }
            catch (EmptyStackException)
            {
                throw new System.ArgumentException("Некорректное выражение");
            }
            return stack.Pop();
        }

    }
}
