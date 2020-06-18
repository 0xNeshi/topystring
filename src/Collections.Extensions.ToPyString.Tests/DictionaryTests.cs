using System.Collections.Generic;

using Xunit;

namespace Collections.Extensions.ToPyString.Tests
{
    public class DictionaryTests
    {
        [Fact]
        public void Prints_Dictionary_Of_Ints()
        {
            var dictionary = new Dictionary<int, int> { [1] = 1, [2] = 2, [-3] = -3, [100] = 100 };
            var expectedResult = "{1: 1, 2: 2, -3: -3, 100: 100}";

            var result = dictionary.ToPyString();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Prints_Dictionary_Of_Strings()
        {
            var dictionary = new Dictionary<string, string> { ["john"] = "john", ["doe"] = "doe", ["test"] = "test" };
            var expectedResult = "{'john': 'john', 'doe': 'doe', 'test': 'test'}";

            var result = dictionary.ToPyString();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Prints_Dictionary_Of_Objects()
        {
            var someClassNoToString = new SomeClassNoToString { SomeIntProperty = 22, SomeStringProperty = "prop" };
            var someClassWithToString = new SomeClassWithToString { SomeIntProperty = 22, SomeStringProperty = "prop" };

            var dictionary = new Dictionary<object, object>
            {
                [1] = "john",
                ["key2"] = 2,
                ["key for object with no ToString"] = someClassNoToString,
                ["key for object with ToString override"] = someClassWithToString,
                [someClassNoToString] = "value for object with no ToString",
                [someClassWithToString] = "value for object with ToString override",
                [1.02] = new Dictionary<string, string> { ["subdict key1"] = "subdict value1" }
            };
            var expectedResult = $"" +
                $"{{" +
                    $"1: 'john', " +
                    $"'key2': 2, " +
                    $"'key for object with no ToString': {typeof(SomeClassNoToString).FullName}, " +
                    $"'key for object with ToString override': {someClassWithToString}, " +
                    $"{typeof(SomeClassNoToString).FullName}: 'value for object with no ToString', " +
                    $"{someClassWithToString}: 'value for object with ToString override', " +
                    $"1.02: {{'subdict key1': 'subdict value1'}}" +
                $"}}";

            var result = dictionary.ToPyString();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Prints_Empty_Dictionary()
        {
            var dictionary = new Dictionary<object, object>();
            var expectedResult = "{}";

            var result = dictionary.ToPyString();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Prints_Dictionary_Containing_Itself()
        {
            var dictionary = new Dictionary<object, object> { [1] = 1 };
            dictionary.Add("self", dictionary);
            var expectedResult = "{1: 1, 'self': {...}}";

            var result = dictionary.ToPyString();

            Assert.Equal(expectedResult, result);
        }
    }
}
