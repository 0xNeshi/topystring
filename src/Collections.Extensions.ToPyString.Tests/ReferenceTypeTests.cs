using Xunit;

namespace Collections.Extensions.ToPyString.Tests
{
    public class ReferenceTypeTests
    {
        [Fact]
        public void Prints_Object_Type_Missing_ToString_Override()
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

        [Fact]
        public void Prints_String()
        {
            var value = "some string";
            var expectedResult = "'some string'";

            var result = value.ToPyString();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Prints_Empty_String()
        {
            var value = string.Empty;
            var expectedResult = "''";

            var result = value.ToPyString();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Prints_Non_ASCII_String()
        {
            var value = "ciào";
            var expectedResult = "'ciào'";

            var result = value.ToPyString();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Prints_Dynamic()
        {
            dynamic dyn = new { field1 = 1};
            var expectedResult = "{ field1 = 1 }";

            var result = Extensions.ToPyString(dyn);

            Assert.Equal(expectedResult, result);
        }
    }
}
