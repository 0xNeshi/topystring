using System.Collections.Generic;
using System.Linq;

namespace Collections.Extensions.ToPyString
{
    class StringPyStringConverter : BasePyStringConverter<string>
    {
        internal StringPyStringConverter(string source, IEnumerable<object> sourceContainers)
            : base(source, sourceContainers)
        {
        }

        public override string GetConvertedValue()
        {
            return SourceContainers.Any() ? $"'{Source}'" : Source;
        }
    }
}
