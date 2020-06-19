using System.Collections.Generic;

using Microsoft.CSharp.RuntimeBinder;

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
        public void Extension_On_Dynamic_Throws()
        {
            dynamic dynObject = new { SomeField = 1 };

            var result = Record.Exception(() => dynObject.ToPyString());

            Assert.NotNull(result);
            Assert.IsType<RuntimeBinderException>(result);
        }

        [Fact]
        public void Prints_Dynamic()
        {
            dynamic dynObject = new { SomeField = 1 };
            var expectedResult = "{ SomeField = 1 }";

            var result = Extensions.ToPyString(dynObject);

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Prints_List_Containing_Dynamic()
        {
            dynamic dynObject = new { SomeField = 1 };
            var list = new List<object> { 11, "some string", dynObject };
            var expectedResult = "[11, 'some string', { SomeField = 1 }]";

            var result = list.ToPyString();

            Assert.Equal(expectedResult, result);
        }
    }
}
