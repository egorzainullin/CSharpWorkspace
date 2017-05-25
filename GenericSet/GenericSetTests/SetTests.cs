using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GenericSet.Tests
{
    [TestClass]
    public class SetTests
    {
        private Set<int> set1;

        private Set<int> set2;

        private Set<int> set3;

        [TestInitialize]
        public void InitializeTests()
        {
            set1 = new Set<int> { 1, 2, 3 };
            set2 = new Set<int> { 2, 3, 4, 5 };
            set3 = new Set<int>();
        }

        [TestMethod]
        public void CountTest()
        {
            Assert.AreEqual(3, set1.Count);
            Assert.AreEqual(4, set2.Count);
            Assert.AreEqual(0, set3.Count);
        }

        [TestMethod]
        public void GetEnumeratorTest()
        {
            int k = 0;
            foreach (var i in set1)
            {
                ++k;
            }
            Assert.AreEqual(3, k);
        }

        [TestMethod]
        public void AddTest()
        {
            set1.Add(4);
            Assert.AreEqual(4, set1.Count);
            Assert.IsFalse(set1.Add(4));
            Assert.AreEqual(4, set1.Count);
        }
            
        [TestMethod]
        public void IsContainingTest()
        {
            Assert.IsTrue(set1.IsContaining(2));
            Assert.IsFalse(set1.IsContaining(4));
        }

        [TestMethod]
        public void RemoveTest()
        {
            set1.Remove(3);
            Assert.AreEqual(2, set1.Count);
            Assert.IsFalse(set1.Remove(3));
            Assert.AreEqual(2, set1.Count);
        }

        [TestMethod]
        public void ClearTest()
        {
            set1.Clear();
            Assert.AreEqual(0, set1.Count);
        }

        [TestMethod]
        public void CombineTest()
        {
            var answer1 = Set<int>.Combine(set1, set2);
            Assert.AreEqual(5, answer1.Count);
            Assert.IsTrue(answer1.IsContaining(4));
            var answer2 = Set<int>.Combine(set1, set3);
            Assert.AreEqual(3, answer2.Count);
        }

        [TestMethod]
        public void IntersectTest()
        {
            var answer1 = Set<int>.Intersect(set1, set2);
            Assert.AreEqual(2, answer1.Count);
            Assert.IsTrue(answer1.IsContaining(2));
            Assert.IsFalse(answer1.IsContaining(1));
            var answer2 = Set<int>.Intersect(set1, set3);
            Assert.AreEqual(0, answer2.Count);
        }
    }
}