using System.Globalization;
using System;
using System.Runtime.Intrinsics;
using Xunit;

namespace Collections.Extensions.ToPyString.Tests
{
    public class Net70ValueTypesTests
    {
        [Fact]
        public void Prints_Vector512()
        {
            var value = Vector512.Create(1.0f);
            var expectedResult = value.ToString();

            var result = value.ToPyString();

            Assert.Equal(expectedResult, result);
        }
    }
}
