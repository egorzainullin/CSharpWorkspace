//todo expception divide by zero
//to do tooomany symbol handler

using System;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calc : Form
    {
        private double currentValue = 0;
        private string currentInput = "";
        private double currentAnswer = 0;
        private string previousOperator = "";

        public Calc()
        {
            InitializeComponent();
            KeyPreview = true;
        }

        private void OnNumberLabelClick(object sender, EventArgs e)
        {
            if (previousOperator == "=")
            {
                previousOperator = "";
                currentValue = 0;
                UpdateScreen();
            }
            var label = sender as Label;
            int value = Int32.Parse(label.Text);
            UpdateInput(value);
            UpdateScreen();
        }

        private void UpdateScreen()
        {
            operatorLabel.Text = previousOperator;
            answerLabel.Text = currentInput != "" ? currentInput : "0";
        }

        private void OnOperatorButtonClick(object sender, EventArgs e)
        {
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
                case ":":
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
        }

        private void OnGetAnswerClick(object sender, EventArgs e)
        {
            operatorLabel.Text = "=";
            if (previousOperator == "=")
            {
                answerLabel.Text = currentAnswer.ToString();
                return;
            }
            else
            {
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
            }
            previousOperator = "=";
            currentValue = 0;
            currentInput = "";
            if (currentAnswer.ToString().Length <= 8)
            {
                answerLabel.Text = currentAnswer.ToString();
            }
            else
            {
                answerLabel.Text = "Не влез";
            }
        }

        private void OnClearButtonClick(object sender, EventArgs e)
        {
            previousOperator = "";
            currentValue = 0;
            currentAnswer = 0;
            currentInput = "";
            UpdateScreen();
        }

        private void OnBackspaceButtonClick(object sender, EventArgs e)
        {
            if (currentInput.Length > 0)
            {
                currentInput = currentInput.Substring(0, currentInput.Length - 1);
            }
            UpdateScreen();
        }

        private void UpdateInput(string value)
        {
            if (currentInput.ToString().Length >= 8)
            {
                return;
            }
            currentInput = currentInput + value;
            UpdateScreen();
        }

        private void UpdateInput(int value)
        {
            string convertedValue = value.ToString();
            UpdateInput(convertedValue);
        }

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

        private void OnDotButtonClick(object sender, EventArgs e)
        {
            UpdateInput(",");
            UpdateScreen();
        }
    }
}

