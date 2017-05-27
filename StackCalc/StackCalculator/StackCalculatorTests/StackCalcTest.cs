using System;
using StackCalculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StackCalculatorTests
{
    [TestClass]
    public class StackCalcTest
    {
        private StackCalc stackCalc;

        [TestInitialize]
        public void StackCalcInitialize()
        {
            stackCalc = new StackCalc(new List());
        }

        [TestMethod]
        public void CalculateTestMethod1()
        {
            stackCalc.Calculate("1");
            Assert.AreEqual(1, stackCalc.Calculate("1"));

            Assert.AreEqual(2, stackCalc.Calculate("1 1 +"));
        }

        [TestMethod]
        public void CalculateTestMethod2()
        {
            Assert.AreEqual(1, stackCalc.Calculate("1 1 *"));
            Assert.AreEqual(2, stackCalc.Calculate("2 1 /"));
            Assert.AreEqual(2, stackCalc.Calculate("1 2 + 2 3 - +"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CalculateInvalidArgTest()
        {
            stackCalc.Calculate("lololo");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CalculateInvalidExpressionTest()
        {
            stackCalc.Calculate("1+");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CalculateInvalidExpressionTest2()
        {
            stackCalc.Calculate("1 0 /");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CalculateInvalidExpressionTest3()
        {
            stackCalc.Calculate("1  /");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CalculateTooLongExpressionTest()
        {
            stackCalc = new StackCalc(new ArrayList());
            string expression = "";
            for (int i = 0; i < 1001; ++i)
            {
                expression += "1 ";
            }
            for (int i = 0; i < 1000; ++i)
            {
                expression += "+ ";
            }
            stackCalc.Calculate(expression);
        }
    }
}
