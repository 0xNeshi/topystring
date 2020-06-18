using System;
using System.Globalization;

namespace Collections.Extensions.ToPyString
{
    class DecimalPyStringConverter : BaseStringConverter<decimal>
    {
        internal DecimalPyStringConverter(decimal source, string prefix) : base(source, prefix)
        {
        }

        public override string Convert()
        {
            string v = Source.ToString(CultureInfo.InvariantCulture);
            return Prefix + v;
        }
    }
}
