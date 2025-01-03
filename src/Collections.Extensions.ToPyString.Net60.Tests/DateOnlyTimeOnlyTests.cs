using System.Globalization;

using Xunit;

namespace Collections.Extensions.ToPyString.Tests
{
    public class DateOnlyTimeOnlyTests
    {
        [Fact]
        public void Prints_DateOnly()
        {
            var value = new DateOnly(2024, 1, 3);
            var expectedResult = value.ToString(CultureInfo.InvariantCulture);

            var result = value.ToPyString();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Prints_TimeOnly()
        {
            var value = new TimeOnly(13, 45, 30);
            var expectedResult = value.ToString(CultureInfo.InvariantCulture);

            var result = value.ToPyString();

            Assert.Equal(expectedResult, result);
        }
    }
}
