﻿using System.Globalization;
using System;
using System.Runtime.Intrinsics;
using Xunit;

namespace Collections.Extensions.ToPyString.Tests
{
    public class Net70ValueTypesTests
    {
        [Fact]
        public void Prints_Int128()
        {
            Int128 value = 42;
            var expectedResult = value.ToString();

            var result = value.ToPyString();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Prints_UInt128()
        {
            UInt128 value = 42;
            var expectedResult = value.ToString();

            var result = value.ToPyString();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Prints_Vector128()
        {
            var value = Vector128.Create(1.0f, 2.0f, 3.0f, 4.0f);
            var expectedResult = value.ToString();

            var result = value.ToPyString();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Prints_Vector256()
        {
            var value = Vector256.Create(1.0f, 2.0f, 3.0f, 4.0f, 5.0f, 6.0f, 7.0f, 8.0f);
            var expectedResult = value.ToString();

            var result = value.ToPyString();

            Assert.Equal(expectedResult, result);
        }
    }
}
