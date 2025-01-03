using System.Globalization;
using System;
using Xunit;

namespace Collections.Extensions.ToPyString.Tests
{
    public class Net60ValueTypesTests
    {
        // TODO: add support for DateTime, DateOnly, and TimeOnly
        // [Fact]
        // public void Prints_DateOnly()
        // {
        //     var value = new DateOnly(2024, 1, 3);
        //     var expectedResult = value.ToString(CultureInfo.InvariantCulture);

        //     var result = value.ToPyString();

        //     Assert.Equal(expectedResult, result);
        // }

        // [Fact]
        // public void Prints_TimeOnly()
        // {
        //     var value = new TimeOnly(13, 45, 30);
        //     var expectedResult = value.ToString(CultureInfo.InvariantCulture);

        //     var result = value.ToPyString();

        //     Assert.Equal(expectedResult, result);
        // }

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
