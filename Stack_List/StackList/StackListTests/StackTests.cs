using Microsoft.VisualStudio.TestTools.UnitTesting;
using StackList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackList.Tests
{
    [TestClass]
    public class StackTests
    {
        private Stack<int> stack;

        [TestInitialize]
        public void InitializeTest()
        {
            stack = new Stack<int>();
        }

        [TestMethod]
        public void PushTest()
        {
            stack.Push(2);
            Assert.AreEqual(2, stack.Peek());
            stack.Push(2);
            Assert.AreEqual(2, stack.Length);
        }

        [TestMethod]
        public void PopTest()
        {
            stack.Push(3);
            Assert.AreEqual(3, stack.Pop());
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void PopErrorTest()
        {
            stack.Pop();
        }

        [TestMethod]
        public void PeekTest()
        {
            stack.Push(3);
            Assert.AreEqual(3, stack.Peek());
            Assert.AreEqual(1, stack.Length);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void PeekErrorTest()
        {
            stack.Peek();
        }

        [TestMethod]
        public void IsEmptyTest()
        {
            Assert.IsTrue(stack.IsEmpty());
        }

        [TestMethod]
        public void ClearTest()
        {
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Clear();
            Assert.IsTrue(stack.IsEmpty());
            Assert.AreEqual(0, stack.Length);
        }
    }
}