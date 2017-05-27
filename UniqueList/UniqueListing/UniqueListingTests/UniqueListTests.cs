using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UniqueListing.Tests
{
    [TestClass]
    public class UniqueListTests
    {
        private UniqueList list;

        [TestInitialize]
        public void InitTest()
        {
            list = new UniqueList();
        }

        [TestMethod]
        public void AddTest()
        {
            list.Add(2);
            list.Add(3);
            Assert.AreEqual(3, list.Peek());
        }

        [TestMethod]
        [ExpectedException(typeof(AlreadyInListException))]
        public void AddFailTest()
        {
            list.Add(2);
            list.Add(2);
        }

        [TestMethod]
        public void RemoveTest()
        {
            list.Add(2);
            list.Remove(2);
            Assert.AreEqual(0, list.Length);
        }

        [TestMethod]
        [ExpectedException(typeof(IsNotContainingInListException))]
        public void RemoveFailTest()
        {
            list.Add(2);
            list.Remove(3);
        }

}
}