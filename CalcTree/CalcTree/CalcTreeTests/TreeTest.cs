using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculationTree;

namespace CalcTreeTests
{
    [TestClass]
    public class TreeTests
    {
        [TestMethod]
        public void CalcExpressionTest1()
        {
            var calcTree = new CalcTree("(* (+ 1 1) 2)");
            Assert.AreEqual(4, calcTree.Calculate());
        }

        [TestMethod]
        public void CalcExpressionTest2()
        {
            var calcTree = new CalcTree("(* (- 2 1) (+ 1 1))");
            Assert.AreEqual(2, calcTree.Calculate());
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void InvalidFormatTest()
        {
            var calcTree = new CalcTree("(*(+ 1 1) 2)");
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivideByZeroTest()
        {
            var calcTree = new CalcTree("(/ 1 0)");
            calcTree.Calculate();
        }

        [TestMethod]
        public void PrintTest()
        {
            var calcTree = new CalcTree("(* (+ 1 1) 2)");
            Assert.AreEqual("(* (+ 1 1) 2)", calcTree.Print());
        }                    
    }
}

