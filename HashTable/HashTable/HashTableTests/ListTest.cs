using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HashTable;

namespace HashTableTests
{
    [TestClass]
    // тестирование класса Список
    public class ListTest
    {
        [TestMethod]
        public void PopTest1()
        {
            var list = new List();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            Assert.AreEqual(3, list.Pop());
            Assert.AreEqual(2, list.Pop());
        }

        [TestMethod]
        public void PeekTest1()
        {
            var list = new List();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            Assert.AreEqual(3, list.Peek());
            Assert.AreEqual(3, list.Peek());
        }

        [TestMethod]
        public void AddTest1()
        {
            var list = new List();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            Assert.AreEqual(3, list.Length);
            Assert.AreEqual(3, list.Head.Value);
        }

        [TestMethod]
        public void isEmptyTest()
        {
            var list = new List();
            Assert.AreEqual(true, list.isEmpty());
            list.Add(1);
            Assert.AreEqual(false, list.isEmpty());
        }

        [TestMethod]
        public void ClearTest()
        {
            var list = new List();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Clear();
            Assert.AreEqual(null, list.Head);
        }

        [TestMethod]
        public void DeleteFromHeadTest()
        {
            var list = new List();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.DeleteFromHead();
            Assert.AreEqual(2, list.Pop());
        }

        [TestMethod]
        public void isContainingTest1()
        {
            var list = new List();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            Assert.AreEqual(true, list.IsContaining(2));
            Assert.AreEqual(false, list.IsContaining(5));
        }

        [TestMethod]
        public void RemoveTest()
        {
            var list = new List();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Remove(1);
            Assert.AreEqual(false, list.IsContaining(1));
        }
    }
}
