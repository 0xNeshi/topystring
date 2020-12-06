using System.Collections.Generic;

using Xunit;

namespace Collections.Extensions.ToPyString.Tests
{
    public class ListTests
    {
        [Fact]
        public void Prints_List_Of_Ints()
        {
            var list = new List<int> { 1, 2, -3, 100 };
            var expectedResult = "[1, 2, -3, 100]";

            var result = list.ToPyString();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Prints_List_Of_Chars()
        {
            var list = new List<char> { 'a', 'b', 'c' };
            var expectedResult = "['a', 'b', 'c']";

            var result = list.ToPyString();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Prints_List_Of_Strings()
        {
            var list = new List<string> { "john", "doe", "test" };
            var expectedResult = "['john', 'doe', 'test']";

            var result = list.ToPyString();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Prints_List_Of_Chars()
        {
            var list = new List<char> { 'a', 'b', 'c' };
            var expectedResult = "['a', 'b', 'c']";

            var result = list.ToPyString();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Prints_List_With_Null()
        {
            var list = new List<object> { 1, new object(), null };
            var expectedResult = "[1, System.Object, null]";

            var result = list.ToPyString();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Prints_List_Of_Objects()
        {
            var someClassNoToString = new SomeClassNoToString { SomeIntProperty = 22, SomeStringProperty = "prop" };
            var someClassWithToString = new SomeClassWithToString { SomeIntProperty = 22, SomeStringProperty = "prop" };

            var list = new List<object> { "john", 1, someClassNoToString, someClassWithToString };
            var expectedResult = $"['john', 1, {typeof(SomeClassNoToString).FullName}, {someClassWithToString}]";

            var result = list.ToPyString();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Prints_Empty_List()
        {
            var list = new List<object>();
            var expectedResult = "[]";

            var result = list.ToPyString();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Prints_List_Of_Lists()
        {
            var list = new List<List<int>> { new List<int> { 1, 2, 3 }, new List<int> { 88, -1, -4 } };
            var expectedResult = "[[1, 2, 3], [88, -1, -4]]";

            var result = list.ToPyString();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Prints_List_Containing_Itself()
        {
            var list = new List<object> { 1, 2, "test", new object() };
            list.Add(list);
            var expectedResult = "[1, 2, 'test', System.Object, [...]]";

            var result = list.ToPyString();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Prints_List_Containing_Dictionary()
        {
            var dict = new Dictionary<object, object> { ["key1"] = 1, [2] = "value2" };
            var list = new List<object> { 1, 2, dict };
            var expectedResult = "[1, 2, {'key1': 1, 2: 'value2'}]";

            var result = list.ToPyString();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Prints_List_Containing_Dictionary_Containing_Parent_List()
        {
            var dict = new Dictionary<object, object> { ["key1"] = 1, [2] = "value2" };
            var list = new List<object> { 1, 2, dict };
            dict["parent"] = list;

            var expectedResult = "[1, 2, {'key1': 1, 2: 'value2', 'parent': [...]}]";

            var result = list.ToPyString();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Prints_List_Of_List_ChildList2_Contains_ChildList1()
        {
            var childList1 = new List<object> { "asd" };
            var childList2 = new List<object> { 2, childList1 };
            var list = new List<object> { childList1, childList2 };

            var expectedResult = "[['asd'], [2, ['asd']]]";

            var result = list.ToPyString();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Prints_List_Of_List_ChildLists_Contain_Each_Other()
        {
            var childList1 = new List<object> { "asd" };
            var childList2 = new List<object> { 2, childList1 };
            childList1.Add(childList2);
            var list = new List<object> { childList1, childList2 };

            var expectedResult = "[['asd', [2, [...]]], [2, ['asd', [...]]]]";

            var result = list.ToPyString();

            Assert.Equal(expectedResult, result);
        }
    }
}
