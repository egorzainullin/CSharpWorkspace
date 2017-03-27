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
        [ExpectedException(typeof(System.ArgumentException))]
        public void CalculateInvalidArgTest()
        {
            stackCalc.Calculate("you have been successfully kicked from university");
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void CalculateInvalidExpressionTest()
        {
            stackCalc.Calculate("1+");
        }
    }
}
