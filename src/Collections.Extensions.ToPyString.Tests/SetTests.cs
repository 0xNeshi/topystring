using System.Collections.Generic;

using Xunit;

namespace Collections.Extensions.ToPyString.Tests
{
    public class SetTests
    {
        [Fact]
        public void Prints_HashSet_Of_Ints()
        {
            var set = new HashSet<int> { 1, 2, -3, 100 };
            var expectedResult = "[1, 2, -3, 100]";

            var result = set.ToPyString();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Prints_HashSet_Of_Strings()
        {
            var set = new HashSet<string> { "john", "doe", "test" };
            var expectedResult = "['john', 'doe', 'test']";

            var result = set.ToPyString();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Prints_HashSet_Of_Objects()
        {
            var someClassNoToString = new SomeClassNoToString { SomeIntProperty = 22, SomeStringProperty = "prop" };
            var someClassWithToString = new SomeClassWithToString { SomeIntProperty = 22, SomeStringProperty = "prop" };

            var set = new HashSet<object> { "john", 1, someClassNoToString, someClassWithToString };
            var expectedResult = $"['john', 1, {typeof(SomeClassNoToString).FullName}, {someClassWithToString}]";

            var result = set.ToPyString();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Prints_Empty_HashSet()
        {
            var set = new HashSet<object>();
            var expectedResult = "[]";

            var result = set.ToPyString();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Prints_HashSet_Of_HashSets()
        {
            var set = new HashSet<HashSet<int>> { new HashSet<int> { 1, 2, 3 }, new HashSet<int> { 88, -1, -4 } };
            var expectedResult = "[[1, 2, 3], [88, -1, -4]]";

            var result = set.ToPyString();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Prints_HashSet_Containing_Itself()
        {
            var set = new HashSet<object> { 1, 2, "test", new object() };
            set.Add(set);
            var expectedResult = "[1, 2, 'test', System.Object, [...]]";

            var result = set.ToPyString();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Prints_HashSet_Containing_Dictionary()
        {
            var dict = new Dictionary<object, object> { ["key1"] = 1, [2] = "value2" };
            var set = new HashSet<object> { 1, 2, dict };
            var expectedResult = "[1, 2, {'key1': 1, 2: 'value2'}]";

            var result = set.ToPyString();

            Assert.Equal(expectedResult, result);
        }
    }
}
