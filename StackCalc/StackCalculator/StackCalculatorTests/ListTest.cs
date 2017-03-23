using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StackCalculator;

namespace HashTableTests
{
    [TestClass]
    // тестирование класса Список

    public class ListTest
    {
        private List list;
        [TestInitialize]
        public void InitializeList()
        {
            list = new List();
            list.Add(1);
            list.Add(2);
            list.Add(3);
        }

        [TestMethod]
        public void PopTest1()
        {
            Assert.AreEqual(3, list.Pop());
            Assert.AreEqual(2, list.Pop());
        }

       [TestMethod]
        public void PeekTest1()
        {
            Assert.AreEqual(3, list.Peek());
            Assert.AreEqual(3, list.Peek());
        }

        [TestMethod]
        public void AddTest1()
        {
            Assert.AreEqual(3, list.Length);
            Assert.AreEqual(3, list.Peek());
        }

        [TestMethod]
        public void IsEmptyTest()
        {
            var list = new List();
            Assert.AreEqual(true, list.IsEmpty());
            list.Add(1);
            Assert.AreEqual(false, list.IsEmpty());
        }

        [TestMethod]
        public void ClearTest()
        {
            list.Clear();
            Assert.AreEqual(true, list.IsEmpty());
        }

        [TestMethod]
        public void DeleteFromHeadTest()
        {
            list.DeleteFromHead();
            Assert.AreEqual(2, list.Pop());
        }

        [TestMethod]
        public void IsContainingTest1()
        {
            Assert.AreEqual(true, list.IsContaining(2));
            Assert.AreEqual(false, list.IsContaining(5));
        }

        [TestMethod]
        public void RemoveTest()
        { 
            list.Remove(1);
            Assert.AreEqual(false, list.IsContaining(1));
        }

        [TestMethod]
        public void LengthTest()
        {
            Assert.AreEqual(3, list.Length);
        }

        [TestMethod]
        [ExpectedException(typeof(EmptyStackException))]
        public void EmptyStackExceptionTest1()
        {
            var list = new ArrayList();
            list.Pop();
        }

        [TestMethod]
        [ExpectedException(typeof(EmptyStackException))]
        public void EmptyStackExceptionTest2()
        {
            var list = new ArrayList();
            list.Peek();
        }
    }
}
