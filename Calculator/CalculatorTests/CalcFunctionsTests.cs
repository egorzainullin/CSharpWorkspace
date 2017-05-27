using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Calculator.Tests
{
    [TestClass]
    public class CalcFunctionsTests
    {
        [TestMethod]
        public void CalculateCurrentAnswerTest()
        {
            double currentAnswer = 123.4;
            string currentInput = "1";
            string previousOperator = "+";
            currentAnswer = CalcFunctions.CalculateCurrentAnswer(currentAnswer, currentInput, previousOperator).Item2;
            Assert.AreEqual(124.4, currentAnswer);
            currentInput = "1,4";
            previousOperator = "-";
            currentAnswer = CalcFunctions.CalculateCurrentAnswer(currentAnswer, currentInput, previousOperator).Item2;
            Assert.AreEqual(123, currentAnswer);
            currentInput = "2";
            previousOperator = "*";
            currentAnswer = CalcFunctions.CalculateCurrentAnswer(currentAnswer, currentInput, previousOperator).Item2;
            Assert.AreEqual(246, currentAnswer);
            currentInput = "2";
            previousOperator = "/";
            currentAnswer = CalcFunctions.CalculateCurrentAnswer(currentAnswer, currentInput, previousOperator).Item2;
            Assert.AreEqual(123, currentAnswer);
        }

        [TestMethod]
        [ExpectedException(typeof(SyntaxErrorException))]
        public void CalculateCurrentAnswerSyntaxErrorTest()
        {
            double currentAnswer = 123.4;
            string currentInput = "1,54,";
            string previousOperator = "+";
            CalcFunctions.CalculateCurrentAnswer(currentAnswer, currentInput, previousOperator);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void CalculateCurrentAnswerDivideByZeroTest()
        {
            double currentAnswer = 123.4;
            string currentInput = "0";
            string previousOperator = "/";
            CalcFunctions.CalculateCurrentAnswer(currentAnswer, currentInput, previousOperator);
        }
    }
}