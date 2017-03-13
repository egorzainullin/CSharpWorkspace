using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HashTable;

namespace ListArrayTests
{
    [TestClass]
    // тестирование класса Список
    public class ListTest
    {
        [TestMethod]
        public void ArrayPopTest1()
        {
            var list = new ArrayList();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            Assert.AreEqual(3, list.Pop());
            Assert.AreEqual(2, list.Pop());
        }

        [TestMethod]
        public void ArrayPeekTest1()
        {
            var list = new ArrayList();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            Assert.AreEqual(3, list.Peek());
            Assert.AreEqual(3, list.Peek());
        }

        [TestMethod]
        public void ArrayAddTest1()
        {
            var list = new ArrayList();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            Assert.AreEqual(3, list.Length);
            Assert.AreEqual(3, list.Peek());
        }

        [TestMethod]
        public void ArrayisEmptyTest()
        {
            var list = new ArrayList();
            Assert.AreEqual(true, list.isEmpty());
            list.Add(1);
            Assert.AreEqual(false, list.isEmpty());
        }

        [TestMethod]
        public void ArrayArrayClearTest()
        {
            var list = new ArrayList();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Clear();
            Assert.AreEqual(true, list.isEmpty());
        }

        [TestMethod]
        public void ArrayDeleteFromHeadTest()
        {
            var list = new ArrayList();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.DeleteFromHead();
            Assert.AreEqual(2, list.Pop());
        }

        [TestMethod]
        public void ArrayisContainingTest1()
        {
            var list = new ArrayList();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            Assert.AreEqual(true, list.IsContaining(2));
            Assert.AreEqual(false, list.IsContaining(5));
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
    }
}
