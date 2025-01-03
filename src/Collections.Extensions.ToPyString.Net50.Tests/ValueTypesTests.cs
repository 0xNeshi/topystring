using System.Globalization;

using Xunit;

namespace Collections.Extensions.ToPyString.Tests
{
    public class Net50ValueTypesTests
    {
        [Fact]
        public void Prints_Half()
        {
            Half value = (Half)1.5f;
            var expectedResult = value.ToString(CultureInfo.InvariantCulture);

            var result = value.ToPyString();

            Assert.Equal(expectedResult, result);
        }
        
        [Fact]
        public void Prints_NativeInt()
        {
            nint value = 42;
            var expectedResult = value.ToString(CultureInfo.InvariantCulture);

            var result = value.ToPyString();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Prints_NativeUInt()
        {
            nuint value = 42;
            var expectedResult = value.ToString(CultureInfo.InvariantCulture);

            var result = value.ToPyString();

            Assert.Equal(expectedResult, result);
        }
        
        [Fact]
        public void Prints_Record()
        {
            var value = new TestRecord("John", 42);
            var expectedResult = value.ToString();

            var result = value.ToPyString();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Prints_Init_Only_Record()
        {
            var value = new TestInitRecord { Name = "John", Age = 42 };
            var expectedResult = value.ToString();

            var result = value.ToPyString();

            Assert.Equal(expectedResult, result);
        }
    }
}
