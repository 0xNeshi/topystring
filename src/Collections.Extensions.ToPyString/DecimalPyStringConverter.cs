using System.Globalization;

namespace Collections.Extensions.ToPyString
{
    class DecimalPyStringConverter : BasePyStringConverter<decimal>
    {
        internal DecimalPyStringConverter(decimal source, string prefix) : base(source, prefix)
        {
        }

        public override string GetConvertedValue()
        {
            var value = Source.ToString(CultureInfo.InvariantCulture);
            return Prefix + value;
        }
    }
}
