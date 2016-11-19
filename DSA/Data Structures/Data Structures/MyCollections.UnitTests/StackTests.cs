using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

using MyStack = MyCollections.Stack<int>;

namespace MyCollections.UnitTests
{
    [TestFixture]
    public class StackTests
    {
        [Test]
        public void Peek_WhenEmptyStack_ShouldThrowsException()
        {
            var stack = new MyStack();

            Assert.Throws<InvalidOperationException>(() => stack.Peek());
        }

        [Test]
        public void Peek_WhenOneElementInStack_ShouldReturnTheElement()
        {
            var stack = new MyStack();
            var expected = 5;
            stack.Push(5);

            var actual = stack.Peek();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Peek_WhenFiveElementsInStack_ShouldTheLastOne()
        {
            var stack = new MyStack();
            var expected = 5;
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);

            var actual = stack.Peek();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Peek_ShouldNotRemoveAnElement()
        {
            var stack = new MyStack();
            int expectedCount = 1;
            stack.Push(5);

            stack.Peek();

            int actualCount = stack.Count;
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void Pop_WhenStackIsEmpty_ShouldThrowException()
        {
            var stack = new MyStack();

            Assert.Throws<InvalidOperationException>(() => stack.Pop());
        }

        [Test]
        public void Pop_WhenOneElementInStack_ShouldReturnTheElement()
        {
            var stack = new MyStack();
            stack.Push(5);
            var expectedElement = 5;

            var actualElement = stack.Pop();

            Assert.AreEqual(expectedElement, actualElement);
        }

        [Test]
        public void Pop_WhenOneElementInStack_ShouldReduceElementsCountToZero()
        {
            var stack = new MyStack();
            stack.Push(5);
            var expectedCount = 0;

            stack.Pop();

            var actualCount = stack.Count;
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void Pop_WhenOneElementInStackAndPopingTwoElements_ShouldThrowsException()
        {
            var stack = new MyStack();
            stack.Push(5);

            stack.Pop();

            Assert.Throws<InvalidOperationException>(() => stack.Pop());
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(5)]
        public void Push_WhenElementsAdded_ShouldReturnCorrectCount(int elementsCount)
        {
            var stack = new MyStack();
            for (int i = 0; i < elementsCount; i++)
            {
                stack.Push(i);
            }

            Assert.AreEqual(stack.Count, elementsCount);
        }

        [Test]
        public void Push_WhenOneElement_ShouldBeAdded()
        {
            var stack = new MyStack();
            var expectedElement = 5;
            stack.Push(5);

            var actualElement = stack.First();

            Assert.AreEqual(expectedElement, actualElement);
        }
    }
}
