using System;
using System.Collections.Generic;
using Xunit;

namespace Collections.Extensions.ToPyString.Tests
{
    public class ArrayTests
    {
        [Fact]
        public void Prints_Array_Of_Ints()
        {
            var array = new int[] { 1, 2, -3, 100 };
            var expectedResult = "[1, 2, -3, 100]";

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
        public void Prints_Twodimensional_Arrays()
        {
            var array = new int[,] { { 1, 2, 3 }, { 88, -1, -4 } };
            var expectedResult = "[[1, 2, 3], [88, -1, -4]]";

            var result = array.ToPyString();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Prints_Threedimensional_Arrays()
        {
            var array = new int[,,] { { { 1, 2, 3 }, { 88, -1, -4 } }, { { 1, 2, 3 }, { -88, 90, -1 } } };
            var expectedResult = "[[[1, 2, 3], [88, -1, -4]], [[1, 2, 3], [-88, 90, -1]]]";

            var result = array.ToPyString();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Prints_Fourdimensional_Arrays()
        {
            var array = new int[,,,] { { { { 1, 2, 3 } } } };
            var expectedResult = "[[[[1, 2, 3]]]]";

            var result = array.ToPyString();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Prints_Empty_Multidimensional_Arrays()
        {
            var array = new int[,,] { };
            var expectedResult = "[]";

            var result = array.ToPyString();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Prints_Jagged_Arrays()
        {
            var array = new int[][] { new int[] { 1, 2, 3, -2 }, new int[] { 88, -1, -4 }, Array.Empty<int>(), new int[] { -100 } };
            var expectedResult = "[[1, 2, 3, -2], [88, -1, -4], [], [-100]]";

            var result = array.ToPyString();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Prints_Array_Containing_Dictionary()
        {
            var dict = new Dictionary<object, object> { ["key1"] = 1, [2] = "value2" };
            var list = new object[] { 1, 2, dict };
            var expectedResult = "[1, 2, {'key1': 1, 2: 'value2'}]";

            var result = list.ToPyString();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Prints_Array_Containing_Dictionary_Containing_Parent_Array()
        {
            var dict = new Dictionary<object, object> { ["key1"] = 1, [2] = "value2" };
            var array = new object[] { 1, 2, dict };
            dict["parent"] = array;

            var expectedResult = "[1, 2, {'key1': 1, 2: 'value2', 'parent': [...]}]";

            var result = array.ToPyString();

            Assert.Equal(expectedResult, result);
        }
    }
}
