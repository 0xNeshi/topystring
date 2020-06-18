using Xunit;

namespace Collections.Extensions.ToPyString.Tests
{
    public class ObjectTests
    {
        [Fact]
        public void Prints_Object_Type()
        {
            var someClassNoToString = new SomeClassNoToString { SomeIntProperty = 22, SomeStringProperty = "prop" };
            var expectedResult = typeof(SomeClassNoToString).FullName;

            var result = someClassNoToString.ToPyString();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Prints_Object_ToString()
        {
            var someClassWithToString = new SomeClassWithToString { SomeIntProperty = 22, SomeStringProperty = "prop" };
            var expectedResult = someClassWithToString.ToString();

            var result = someClassWithToString.ToPyString();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Prints_Null()
        {
            object nullObj = null;
            var expectedResult = "null";

            var result = nullObj.ToPyString();

            Assert.Equal(expectedResult, result);
        }
    }
}
