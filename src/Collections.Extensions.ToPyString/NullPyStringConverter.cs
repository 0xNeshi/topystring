using System.Collections.Generic;

namespace Collections.Extensions.ToPyString
{
    class NullPyStringConverter : BasePyStringConverter<object>
    {
        internal NullPyStringConverter(object source, IEnumerable<object> sourceContainers, string prefix)
            : base(source, sourceContainers, prefix)
        {
        }

        public override string GetConvertedValue()
        {
            return Prefix + "null";
        }
    }
}
