using System.Globalization;

using Xunit;

namespace Collections.Extensions.ToPyString.Tests
{
    public class PrimitiveTypesTests
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
    }
}
