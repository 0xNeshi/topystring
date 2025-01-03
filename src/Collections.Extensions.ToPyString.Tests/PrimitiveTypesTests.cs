using System.Globalization;

using Xunit;

namespace Collections.Extensions.ToPyString.Tests
{
    public class PrimitiveTypesTests
    {
        [Fact]
        public void Prints_Bool()
        {
            bool value = true;
            var expectedResult = value.ToString(CultureInfo.InvariantCulture);

            var result = value.ToPyString();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Prints_SByte()
        {
            sbyte value = 0x7F;
            var expectedResult = "127";

            var result = value.ToPyString();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Prints_Byte()
        {
            byte value = 0xA1;
            var expectedResult = "161";

            var result = value.ToPyString();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Prints_Char()
        {
            var value = 'b';
            var expectedResult = "b";

            var result = value.ToPyString();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Prints_Int()
        {
            var value = 1;
            var expectedResult = "1";

            var result = value.ToPyString();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Prints_Uint()
        {
            uint value = 1;
            var expectedResult = "1";

            var result = value.ToPyString();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Prints_Int_Hexadecimal()
        {
            var value = 0xFF;
            var expectedResult = "255";

            var result = value.ToPyString();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Prints_Long()
        {
            var value = 1L;
            var expectedResult = "1";

            var result = value.ToPyString();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Prints_ULong()
        {
            ulong value = 1;
            var expectedResult = "1";

            var result = value.ToPyString();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Prints_Short()
        {
            short value = 1;
            var expectedResult = "1";

            var result = value.ToPyString();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Prints_UShort()
        {
            ushort value = 1;
            var expectedResult = "1";

            var result = value.ToPyString();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Prints_Decimal()
        {
            var value = 1m;
            var expectedResult = "1";

            var result = value.ToPyString();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Prints_Float()
        {
            var value = 1f;
            var expectedResult = value.ToString(CultureInfo.InvariantCulture);

            var result = value.ToPyString();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Prints_Float_With_Decimals()
        {
            var value = 1.02f;
            var expectedResult = value.ToString(CultureInfo.InvariantCulture);

            var result = value.ToPyString();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Prints_Double()
        {
            var value = 1d;
            var expectedResult = value.ToString(CultureInfo.InvariantCulture);

            var result = value.ToPyString();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Prints_Double_With_Decimals()
        {
            var value = 1.012d;
            var expectedResult = value.ToString(CultureInfo.InvariantCulture);

            var result = value.ToPyString();

            Assert.Equal(expectedResult, result);
        }
    }
}
