using System;

using Xunit;

namespace Collections.Extensions.ToPyString.Tests
{
    public class ArrayTests
    {
        [Fact]
        public void Prints_Array_Of_Ints()
        {
            var array = new int[] { 1, 2, -3, 100 };
            var expectedResult = "[1, 2, -3, 100a]";

            var result = array.ToPyString();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Prints_Array_Of_Strings()
        {
            var array = new string[] { "john", "doe", "test" };
            var expectedResult = "['john', 'doe', 'test']";

            var result = array.ToPyString();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Prints_Array_Of_Objects()
        {
            var someClassNoToString = new SomeClassNoToString { SomeIntProperty = 22, SomeStringProperty = "prop" };
            var someClassWithToString = new SomeClassWithToString { SomeIntProperty = 22, SomeStringProperty = "prop" };

            var array = new object[] { "john", 1, someClassNoToString, someClassWithToString };
            var expectedResult = $"['john', 1, {typeof(SomeClassNoToString).FullName}, {someClassWithToString}]";

            var result = array.ToPyString();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Prints_Empty_Array()
        {
            var array = Array.Empty<object>();
            var expectedResult = "[]";

            var result = array.ToPyString();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Prints_Array_Of_Arrays()
        {
            var array = new int[][] { new int[] { 1, 2, 3 }, new int[] { 88, -1, -4 } };
            var expectedResult = "[[1, 2, 3], [88, -1, -4]]";

            var result = array.ToPyString();

            Assert.Equal(expectedResult, result);
        }
    }
}
