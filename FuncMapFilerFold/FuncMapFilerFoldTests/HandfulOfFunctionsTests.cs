using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace FuncMapFilerFold.Tests
{
    [TestClass()]
    public class HandfulOfFunctionsTests
    {
        private List<int> list;

        private HandfulOfFunctions functions;

        [TestInitialize()]
        public void InitTest()
        {
            list = new List<int> { 1, 2, 3 };
            functions = new HandfulOfFunctions();
        }

        [TestMethod()]
        public void MapTest()
        {
            int[] array = functions.Map(list, x => x * 2).ToArray();
            Assert.AreEqual(2, array[0]);
            Assert.AreEqual(4, array[1]);
            Assert.AreEqual(6, array[2]);
        }

        [TestMethod()]
        public void FilterTest()
        {
            int[] array = functions.Filter(list, x => x % 2 == 0).ToArray();
            Assert.AreEqual(2, array[0]);
        }

        [TestMethod()]
        public void FoldTest()
        {
            int res = functions.Fold(list, 1, (acc, elem) => acc* elem);
            Assert.AreEqual(6, res);
        }
    }
}