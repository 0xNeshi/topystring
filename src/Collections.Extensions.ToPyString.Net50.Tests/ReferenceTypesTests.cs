using System.Globalization;

using Xunit;

namespace Collections.Extensions.ToPyString.Tests
{
    public class Net50ReferenceTypesTests
    {
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
    
    public record TestRecord(string Name, int Age);

    public record TestInitRecord
    {
        public string Name { get; init; }
        public int Age { get; init; }
    }
}
