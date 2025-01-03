using System.Globalization;

using Xunit;

namespace Collections.Extensions.ToPyString.Tests
{
    public class PrimitiveTypesTests
    {
        [Fact]
        public void Prints_Int128()
        {
            Int128 value = 42;
            var expectedResult = value.ToString(CultureInfo.InvariantCulture);

            var result = value.ToPyString();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Prints_UInt128()
        {
            UInt128 value = 42;
            var expectedResult = value.ToString(CultureInfo.InvariantCulture);

            var result = value.ToPyString();

            Assert.Equal(expectedResult, result);
        }
    }
}
