using System;
using System.Windows.Forms;

namespace Calculator
{
    /// <summary>
    /// Форма, реализующая калькулятор
    /// </summary>
    public partial class Calc : Form
    {
        /// <summary>
        /// Значение, введенное с клавиатуры
        /// </summary>
        private double currentValue = 0;

        /// <summary>
        /// Ввод пользователя
        /// </summary>
        private string currentInput = "";

        /// <summary>
        /// Ответ на данный момент
        /// </summary>
        private double currentAnswer = 0;

        /// <summary>
        /// Предыдущий оператор
        /// </summary>
        private string previousOperator = "";

        /// <summary>
        /// Было нажато равно
        /// </summary>
        private bool wasLastPressedGetAnswer = false;

        /// <summary>
        /// Инициализирует форму
        /// </summary>
        public Calc()
        {
            InitializeComponent();
            KeyPreview = true;
        }

        /// <summary>
        /// Обработчик нажатия на какую-то из клавиш циферок
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnNumberLabelClick(object sender, EventArgs e)
        {
            if (wasLastPressedGetAnswer)
            {
                Reset();
            }
            var label = sender as Label;
            int value = Int32.Parse(label.Text);
            UpdateInput(value);
            UpdateScreen();
        }

        /// <summary>
        /// Выводит значения на экран
        /// </summary>
        private void UpdateScreen()
        {
            operatorLabel.Text = previousOperator;
            answerLabel.Text = currentInput != "" ? currentInput : "0";
        }

        /// <summary>
        /// Обработчик нажатия на клавишу-оператор
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnOperatorButtonClick(object sender, EventArgs e)
        {
            if (wasLastPressedGetAnswer)
            {
                wasLastPressedGetAnswer = false;
                previousOperator = "=";
            }
            var button = sender as Button;
            string currentOperator = button.Text;
            try
            {
                CalculateCurrentAnswer();
                currentValue = 0;
                currentInput = "";
                previousOperator = currentOperator;
                UpdateScreen();
            }
            catch (DivideByZeroException)
            {
                answerLabel.Text = "Дел ноль";
                currentValue = 0;
                currentInput = "";
            }
            catch (SyntaxErrorException)
            {
                answerLabel.Text = "ошибка ввода";
                currentValue = 0;
                currentInput = "";
            }
        }

        /// <summary>
        /// Промежуточный подсчет ответа
        /// </summary>
        private void CalculateCurrentAnswer()
        {
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
                    currentAnswer /= currentValue;
                    break;
                case "":
                    currentAnswer = currentValue;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Обработчик события нажатия на равно
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnGetAnswerClick(object sender, EventArgs e)
        {
            wasLastPressedGetAnswer = true;
            operatorLabel.Text = "=";
            try
            {
                CalculateCurrentAnswer();
            }
            catch (DivideByZeroException)
            {
                answerLabel.Text = "Дел ноль";
                currentValue = 0;
                currentInput = "";
                return;
            }
            catch (SyntaxErrorException)
            {
                answerLabel.Text = "ошибка ввода";
                currentValue = 0;
                currentInput = "";
                return;
            }
            string toPrint = currentAnswer.ToString();
            int index = toPrint.IndexOf(',');
            if (index > 0 && ((index + 2) < toPrint.Length))
            {
                toPrint = toPrint.Substring(0, index + 3);
            }
            if (toPrint.Length <= 8)
            {
                answerLabel.Text = toPrint;
            }
            else
            {
                answerLabel.Text = "Не влез";
            }
        }

        /// <summary>
        /// Обработчик события нажатия на клавишу C, то есть очистка текущих значений и экрана
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClearButtonClick(object sender, EventArgs e)
        {
            Reset();
        }

        /// <summary>
        /// Нажатие на клавишу backspace
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnBackspaceButtonClick(object sender, EventArgs e)
        {
            if (wasLastPressedGetAnswer)
            {
                Reset();
            }
            if (currentInput.Length > 0)
            {
                currentInput = currentInput.Substring(0, currentInput.Length - 1);
            }
            UpdateScreen();
        }

        /// <summary>
        /// Запись ввода пользователя
        /// </summary>
        /// <param name="value">Последний символ, введенный пользователем</param>
        private void UpdateInput(string value)
        {
            if (wasLastPressedGetAnswer)
            {
                Reset();
            }
            if (currentInput.ToString().Length >= 8)
            {
                return;
            }
            currentInput = currentInput + value;
            UpdateScreen();
        }

        /// <summary>
        /// Восстановить начальные значения
        /// </summary>
        private void Reset()
        {
            wasLastPressedGetAnswer = false;
            previousOperator = "";
            currentValue = 0;
            currentAnswer = 0;
            currentInput = "";
            UpdateScreen();
        }

        /// <summary>
        /// Запись ввода пользователя
        /// </summary>
        /// <param name="value">последняя цифра, введенная пользователем</param>
        private void UpdateInput(int value)
        {
            string convertedValue = value.ToString();
            UpdateInput(convertedValue);
        }

        /// <summary>
        /// Обработчик нажатий клавиатуры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCalcKeyUp(object sender, KeyEventArgs e)
        {
            var key = e.KeyCode;
            if (e.Shift)
            {
                switch (key)
                {
                    case Keys.D8:
                        OnOperatorButtonClick(multiplyButton, EventArgs.Empty);
                        break;
                    case Keys.Oemplus:
                        OnOperatorButtonClick(plusButton, EventArgs.Empty);
                        break;
                    case Keys.D6:
                        OnOperatorButtonClick(divideButton, EventArgs.Empty);
                        break;
                    default:
                        break;
                }
                return;
            }
            switch (key)
            {
                case Keys.D1:
                    UpdateInput(1);
                    break;
                case Keys.D2:
                    UpdateInput(2);
                    break;
                case Keys.D3:
                    UpdateInput(3);
                    break;
                case Keys.D4:
                    UpdateInput(4);
                    break;
                case Keys.D5:
                    UpdateInput(5);
                    break;
                case Keys.D6:
                    UpdateInput(6);
                    break;
                case Keys.D7:
                    UpdateInput(7);
                    break;
                case Keys.D8:
                    UpdateInput(8);
                    break;
                case Keys.D9:
                    UpdateInput(9);
                    break;
                case Keys.D0:
                    UpdateInput(0);
                    break;
                case Keys.Back:
                    OnBackspaceButtonClick(backspaceButton, EventArgs.Empty);
                    break;
                case Keys.C:
                    OnClearButtonClick(clearButton, EventArgs.Empty);
                    break;
                case Keys.Oemplus:
                    OnGetAnswerClick(getAnswerButton, EventArgs.Empty);
                    break;
                case Keys.OemMinus:
                    OnOperatorButtonClick(minusButton, EventArgs.Empty);
                    break;
                case Keys.Oemcomma:
                    OnDotButtonClick(dotButton, EventArgs.Empty);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Обработчик нажатия на запятую
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnDotButtonClick(object sender, EventArgs e)
        {
            UpdateInput(",");
            UpdateScreen();
        }
    }
}

