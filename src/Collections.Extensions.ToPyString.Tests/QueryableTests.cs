using System.Collections.Generic;
using System.Linq;

using Xunit;

namespace Collections.Extensions.ToPyString.Tests
{
    public class QueryableTests
    {
        [Fact]
        public void Prints_Queryable_Of_Ints()
        {
            var queryable = new List<int> { 1, 2, -3, 100 }.AsQueryable();
            var expectedResult = "[1, 2, -3, 100]";

            var result = queryable.ToPyString();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Prints_Queryable_Of_Strings()
        {
            var queryable = new List<string> { "john", "doe", "test" }.AsQueryable();
            var expectedResult = "['john', 'doe', 'test']";

            var result = queryable.ToPyString();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Prints_Queryable_Of_Objects()
        {
            var someClassNoToString = new SomeClassNoToString { SomeIntProperty = 22, SomeStringProperty = "prop" };
            var someClassWithToString = new SomeClassWithToString { SomeIntProperty = 22, SomeStringProperty = "prop" };

            var queryable = new List<object> { "john", 1, someClassNoToString, someClassWithToString }.AsQueryable();
            var expectedResult = $"['john', 1, {typeof(SomeClassNoToString).FullName}, {someClassWithToString}]";

            var result = queryable.ToPyString();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Prints_Empty_Queryable()
        {
            var queryable = new List<object>().AsQueryable();
            var expectedResult = "[]";

            var result = queryable.ToPyString();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Prints_Queryable_Of_Queryables()
        {
            var queryable = new List<List<int>> { new List<int> { 1, 2, 3 }, new List<int> { 88, -1, -4 } }.AsQueryable();
            var expectedResult = "[[1, 2, 3], [88, -1, -4]]";

            var result = queryable.ToPyString();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Prints_Queryable_Containing_Dictionary()
        {
            var dict = new Dictionary<object, object> { ["key1"] = 1, [2] = "value2" };
            var queryable = new List<object> { 1, 2, dict }.AsQueryable();
            var expectedResult = "[1, 2, {'key1': 1, 2: 'value2'}]";

            var result = queryable.ToPyString();

            Assert.Equal(expectedResult, result);
        }
    }
}
