using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HashTableProject;

namespace HashTableTests
{
    [TestClass]
    public class HashTableTest
    {
        [TestMethod]
        public void HashTableAddTest()
        {
            var hashTable = new HashTable();
            hashTable.Add(1);
            hashTable.Add(2);
            hashTable.Add(5);
            hashTable.Add(1);
            Assert.AreEqual(3, hashTable.NumberOfElements);
        }

        [TestMethod]
        public void HashTableRemoveTest()
        {
            var hashTable = new HashTable();
            hashTable.Add(1);
            hashTable.Add(2);
            hashTable.Add(3);
            hashTable.Remove(2);
            Assert.AreEqual(2, hashTable.NumberOfElements);
        }

        [TestMethod]
        public void HashTableIsContainingTest()
        {
            var hashTable = new HashTable();
            hashTable.Add(1);
            hashTable.Add(2);
            hashTable.Add(3);
            hashTable.Remove(2);
            Assert.AreEqual(false, hashTable.isContaining(2));
            Assert.AreEqual(true, hashTable.isContaining(3));
        }

        [TestMethod]
        public void HashTableConstructorTest()
        {
            var hashTable = new HashTable(new StandartHashFunction());
            hashTable.Add(1);
            hashTable.Add(2);
            hashTable.Add(3);
            hashTable.Remove(2);
            Assert.AreEqual(false, hashTable.isContaining(2));
            Assert.AreEqual(true, hashTable.isContaining(3));
        }
    }
}
