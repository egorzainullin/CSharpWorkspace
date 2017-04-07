//todo expception divide by zero
//to do tooomany symbol handler

using System;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calc : Form
    {
        private int currentValue = 0;
        private int currentAnswer = 0;
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
            UpdateValue(value);
            UpdateScreen();
        }

        private void UpdateScreen()
        {
            operatorLabel.Text = previousOperator;
            answerLabel.Text = currentValue.ToString();
        }

        private void OnOperatorButtonClick(object sender, EventArgs e)
        {
            var button = sender as Button;
            string currentOperator = button.Text;
            if (previousOperator == "")
            {
                currentAnswer = currentValue;
            }
            try
            {
                CalculateCurrentAnswer();
                currentValue = 0;
                previousOperator = currentOperator;
                UpdateScreen();
            }
            catch (DivideByZeroException)
            {
                answerLabel.Text = "Дел ноль";
                currentValue = 0;
            }
        }

        private void CalculateCurrentAnswer()
        {
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
            if (previousOperator == "")
            {
                currentAnswer = currentValue;
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
                    return;
                }
            }
            previousOperator = "=";
            currentValue = 0;
            answerLabel.Text = currentAnswer.ToString();
        }

        private void OnClearButtonClick(object sender, EventArgs e)
        {
            previousOperator = "";
            currentValue = 0;
            currentAnswer = 0;
            UpdateScreen();
        }

        private void OnBackspaceButtonClick(object sender, EventArgs e)
        {
            if (currentValue > 0)
            {
                currentValue = currentValue / 10;
            }
            UpdateScreen();
        }

        private void UpdateValue(int value)
        {
            currentValue = currentValue * 10 + value;
            UpdateScreen();
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
                    UpdateValue(1);
                    break;
                case Keys.D2:
                    UpdateValue(2);
                    break;
                case Keys.D3:
                    UpdateValue(3);
                    break;
                case Keys.D4:
                    UpdateValue(4);
                    break;
                case Keys.D5:
                    UpdateValue(5);
                    break;
                case Keys.D6:
                    UpdateValue(6);
                    break;
                case Keys.D7:
                    UpdateValue(7);
                    break;
                case Keys.D8:
                    UpdateValue(8);
                    break;
                case Keys.D9:
                    UpdateValue(9);
                    break;
                case Keys.D0:
                    UpdateValue(0);
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
                case Keys.Enter:
                    OnGetAnswerClick(getAnswerButton, EventArgs.Empty);
                    break;
                case Keys.OemMinus:
                    OnOperatorButtonClick(minusButton, EventArgs.Empty);
                    break;
                default:
                    break;
            }
        }

        private void OnAntiEnterKeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}

