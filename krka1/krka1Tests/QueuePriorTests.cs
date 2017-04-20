using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace QueueP.Tests
{
    [TestClass]
    public class QueuePriorTests
    {
        QueuePrior queue;

        [TestInitialize]
        public void InitializingTest()
        {
            queue = new QueuePrior();
            queue.Enqueue(1, 1);
            queue.Enqueue(3, 3);
            queue.Enqueue(2, 2);
            queue.Enqueue(4, 4);
        }

        [TestMethod]
        public void EnqueueTest()
        {
            queue.Enqueue(0, 0);
            queue.Enqueue(5, 5);
            Assert.AreEqual(6, queue.Length);
        }

        [TestMethod]
        public void DequeueTest()
        {
            queue.Enqueue(0, 0);
            queue.Enqueue(5, 1);
            Assert.AreEqual(4, queue.Dequeue());
            Assert.AreEqual(3, queue.Dequeue());
            Assert.AreEqual(2, queue.Dequeue());
            Assert.AreEqual(5, queue.Dequeue());
            Assert.AreEqual(1, queue.Dequeue());
            Assert.AreEqual(0, queue.Dequeue());
        }

        [TestMethod]
        [ExpectedException(typeof(QueueEmptyException))]
        public void EmptyExceptionTest()
        {
            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
        }
    }
}