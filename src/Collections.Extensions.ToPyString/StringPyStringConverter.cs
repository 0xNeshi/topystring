using System.Collections.Generic;
using System.Linq;

namespace Collections.Extensions.ToPyString
{
    class StringPyStringConverter : BasePyStringConverter<string>
    {
        internal StringPyStringConverter(string source, IEnumerable<object> sourceContainers, string prefix)
            : base(source, sourceContainers, prefix)
        {
        }

        public override string GetConvertedValue()
        {
            return Prefix + (SourceContainers.Any() ? $"'{Source}'" : Source);
        }
    }
}
