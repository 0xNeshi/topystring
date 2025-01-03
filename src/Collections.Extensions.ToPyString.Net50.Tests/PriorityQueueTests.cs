using System.Collections.Generic;
using Xunit;

namespace Collections.Extensions.ToPyString.Tests
{
    public class PriorityQueueTests
    {
        [Fact]
        public void Prints_PriorityQueue_Of_Ints()
        {
            var queue = new PriorityQueue<int, int>();
            queue.Enqueue(1, 1);
            queue.Enqueue(2, 2);
            queue.Enqueue(-3, 3);
            queue.Enqueue(100, 0);
            var expectedResult = "[100, 1, 2, -3]";

            var result = queue.ToPyString();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Prints_PriorityQueue_Of_Strings()
        {
            var queue = new PriorityQueue<string, int>();
            queue.Enqueue("john", 2);
            queue.Enqueue("doe", 1);
            queue.Enqueue("test", 0);
            var expectedResult = "['test', 'doe', 'john']";

            var result = queue.ToPyString();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Prints_PriorityQueue_Of_Objects()
        {
            var someClassNoToString = new SomeClassNoToString { SomeIntProperty = 22, SomeStringProperty = "prop" };
            var someClassWithToString = new SomeClassWithToString { SomeIntProperty = 22, SomeStringProperty = "prop" };

            var queue = new PriorityQueue<object, int>();
            queue.Enqueue("john", 3);
            queue.Enqueue(1, 2);
            queue.Enqueue(someClassNoToString, 1);
            queue.Enqueue(someClassWithToString, 0);
            
            var expectedResult = $"[{someClassWithToString}, {typeof(SomeClassNoToString).FullName}, 1, 'john']";

            var result = queue.ToPyString();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Prints_Empty_PriorityQueue()
        {
            var queue = new PriorityQueue<object, int>();
            var expectedResult = "[]";

            var result = queue.ToPyString();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Prints_PriorityQueue_With_Custom_Priority_Type()
        {
            var queue = new PriorityQueue<string, string>();
            queue.Enqueue("first", "high");
            queue.Enqueue("second", "medium");
            queue.Enqueue("third", "low");
            var expectedResult = "['first', 'second', 'third']";

            var result = queue.ToPyString();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Prints_PriorityQueue_Containing_Lists()
        {
            var queue = new PriorityQueue<List<int>, int>();
            queue.Enqueue(new List<int> { 1, 2, 3 }, 1);
            queue.Enqueue(new List<int> { 88, -1, -4 }, 0);
            var expectedResult = "[[88, -1, -4], [1, 2, 3]]";

            var result = queue.ToPyString();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Prints_PriorityQueue_Containing_Dictionary()
        {
            var dict = new Dictionary<object, object> { ["key1"] = 1, [2] = "value2" };
            var queue = new PriorityQueue<object, int>();
            queue.Enqueue(1, 2);
            queue.Enqueue(2, 1);
            queue.Enqueue(dict, 0);
            var expectedResult = "[{'key1': 1, 2: 'value2'}, 2, 1]";

            var result = queue.ToPyString();

            Assert.Equal(expectedResult, result);
        }
    }
}