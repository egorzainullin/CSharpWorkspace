using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StackCalculator;

namespace ListArrayTests
{
    [TestClass]
    // тестирование класса Список

    public class ListTest
    {
        private ArrayList list;

        [TestInitialize]
        public void InitializeList()
        {
            list = new ArrayList();
            list.Add(1);
            list.Add(2);
            list.Add(3);
        }

        [TestMethod]
        public void ArrayPopTest1()
        {
            Assert.AreEqual(3, list.Pop());
            Assert.AreEqual(2, list.Pop());
        }

        [TestMethod]
        public void ArrayPeekTest1()
        {
            Assert.AreEqual(3, list.Peek());
            Assert.AreEqual(3, list.Peek());
        }

        [TestMethod]
        public void ArrayAddTest1()
        {
            Assert.AreEqual(3, list.Length);
            Assert.AreEqual(3, list.Peek());
        }

        [TestMethod]
        public void ArrayIsEmptyTest()
        {
            var list = new ArrayList();
            Assert.AreEqual(true, list.IsEmpty());
            list.Add(1);
            Assert.AreEqual(false, list.IsEmpty());
        }

        [TestMethod]
        public void ArrayClearTest()
        {
            list.Clear();
            Assert.IsTrue(list.IsEmpty());
        }

        [TestMethod]
        public void ArrayDeleteFromHeadTest()
        {
            list.DeleteFromHead();
            Assert.AreEqual(2, list.Pop());
        }

        [TestMethod]
        public void ArrayIsContainingTest1()
        {
            Assert.IsTrue(list.IsContaining(2));
            Assert.IsFalse(list.IsContaining(5));
        }

        [TestMethod]
        public void ArrayRemoveTest()
        {
            var list = new ArrayList();
            list.Add(1);
            list.Add(1);
            list.Add(2);
            list.Add(1);
            list.Add(3);
            list.Remove(1);
            Assert.AreEqual(false, list.IsContaining(1));
            Assert.AreEqual(2, list.Length);
        }

        [TestMethod]
        public void ArrayLengthTest()
        {
            var list = new ArrayList();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            Assert.AreEqual(3, list.Length);
        }

        [TestMethod]
        [ExpectedException(typeof(EmptyStackException))]
        public void ArrayEmptyStackExceptionTest1()
        {
            var list = new ArrayList();
            list.Pop();
        }

        [TestMethod]
        [ExpectedException(typeof(EmptyStackException))]
        public void ArrayEmptyStackExceptionTest2()
        {
            var list = new ArrayList();
            list.Peek();
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void OutOfRangeStackExceptionTest2()
        {
            var list = new ArrayList();
            for (int i = 0; i <1001; i++)
            {
                list.Add(1);
            }
        }
    }
}
