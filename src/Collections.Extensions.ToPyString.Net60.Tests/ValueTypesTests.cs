using System.Globalization;

using Xunit;

namespace Collections.Extensions.ToPyString.Tests
{
    public class ValueTypesTests
    {
        [Fact]
        public void Prints_Record_Struct()
        {
            var value = new TestRecordStruct("John", 42);
            var expectedResult = value.ToString();

            var result = value.ToPyString();

            Assert.Equal(expectedResult, result);
        }
    }
    
    public record struct TestRecordStruct(string Name, int Age);
}
