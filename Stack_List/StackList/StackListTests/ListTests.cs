using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace StackList.Tests
{
    [TestClass]
    public class ListTests
    {
        private List<int> list;

        [TestInitialize]
        public void InitializeTest()
        {
            list = new List<int>();
        }

        [TestMethod]
        public void PushTest()
        {
            list.Add(2);
            Assert.AreEqual(2, list.Peek());
            list.Add(2);
            Assert.AreEqual(2, list.Length);
        }

        [TestMethod]
        public void PopTest()
        {
            list.Add(3);
            Assert.AreEqual(3, list.Pop());
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void PopErrorTest()
        {
            list.Pop();
        }

        [TestMethod]
        public void PeekTest()
        {
            list.Add(3);
            Assert.AreEqual(3, list.Peek());
            Assert.AreEqual(1, list.Length);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void PeekErrorTest()
        {
            list.Peek();
        }

        [TestMethod]
        public void IsEmptyTest()
        {
            Assert.IsTrue(list.IsEmpty());
        }

        [TestMethod]
        public void ClearTest()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Clear();
            Assert.IsTrue(list.IsEmpty());
            Assert.AreEqual(0, list.Length);
        }

        [TestMethod]
        public void DeleteFromHeadTest()
        {
            list.Add(1);
            list.Add(2);
            list.DeleteFromHead();
            Assert.AreEqual(1, list.Length);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void DeleteFromHeadExceptionTest()
        {
            list.DeleteFromHead();
        }

        [TestMethod]
        public void IsContainingTest()
        {
            list.Add(1);
            list.Add(2);
            Assert.IsTrue(list.IsContaining(1));
            Assert.IsFalse(list.IsContaining(3));
        }

        [TestMethod]
        public void RemoveTest()
        {
            list.Add(1);
            list.Remove(1);
            list.Add(2);
            list.Add(3);
            list.Add(3);
            list.Remove(2);
            Assert.IsFalse(list.IsContaining(2));
            list.Remove(3);
            Assert.IsFalse(list.IsContaining(3));
            Assert.AreEqual(0, list.Length);
        }

        [TestMethod]
        public void Enumeratortest()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);
            int j = 0;
            foreach(var i in list)
            {
                ++j;   
            }
            Assert.AreEqual(3, j);
        }
    }
}