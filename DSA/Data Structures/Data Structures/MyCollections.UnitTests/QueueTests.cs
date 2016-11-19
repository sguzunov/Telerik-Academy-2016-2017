namespace MyCollections.UnitTests
{
    using NUnit.Framework;

    using MyQueue = MyCollections.Queue<int>;

    [TestFixture]
    public class QueueTests
    {
        [TestCase(1)]
        [TestCase(5)]
        [TestCase(10)]
        [TestCase(1000)]
        public void Enqueue_WhenElementsAdded_ShouldReturnCorrectElementsCount(int elementsCount)
        {
            var queue = new MyQueue();
            for (int i = 0; i < elementsCount; i++)
            {
                queue.Enqueue(i + 1);
            }

            Assert.AreEqual(elementsCount, queue.Count);
        }

        [TestCase(2, 3)]
        [TestCase(9, 10)]
        public void Enqueue_WhenOneMoreElementAddedThanCapacity_ShouldDoubleCapacity(int initCapacity, int elementsCount)
        {
            var queue = new MyQueue(initCapacity);
            for (int i = 0; i < elementsCount; i++)
            {
                queue.Enqueue(i + 1);
            }

            var expectedCapacity = initCapacity * 2;

            Assert.AreEqual(expectedCapacity, queue.Capacity);
        }

        [TestCase(8, 5)]
        [TestCase(100, 99)]
        public void Enqueue_WhenLessElementAddedThanCapacity_ShouldNotChangeCapacity(int initCapacity, int elementsCount)
        {
            var queue = new MyQueue(initCapacity);
            for (int i = 0; i < elementsCount; i++)
            {
                queue.Enqueue(i + 1);
            }

            Assert.AreEqual(initCapacity, queue.Capacity);
        }
    }
}
