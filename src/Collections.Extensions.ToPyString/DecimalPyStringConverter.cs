using System;
using System.Collections.Generic;
using System.Globalization;

namespace Collections.Extensions.ToPyString
{
    class DecimalPyStringConverter : BasePyStringConverter<decimal>
    {
        internal DecimalPyStringConverter(decimal source, IEnumerable<object> sourceContainers, string prefix)
            : base(source, sourceContainers, prefix)
        {
        }

        internal DecimalPyStringConverter(float source, IEnumerable<object> sourceContainers, string prefix)
            : base(Convert.ToDecimal(source), sourceContainers, prefix)
        {
        }

        internal DecimalPyStringConverter(double source, IEnumerable<object> sourceContainers, string prefix)
            : base(Convert.ToDecimal(source), sourceContainers, prefix)
        {
        }

        public override string GetConvertedValue()
        {
            var value = Source.ToString(CultureInfo.InvariantCulture);
            return Prefix + value;
        }
    }
}
