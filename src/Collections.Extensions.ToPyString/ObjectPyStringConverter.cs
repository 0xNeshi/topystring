using System.Collections.Generic;

namespace Collections.Extensions.ToPyString
{
    class ObjectPyStringConverter : BasePyStringConverter<object>
    {
        internal ObjectPyStringConverter(object source, IEnumerable<object> sourceContainers)
            : base(source, sourceContainers)
        {
        }

        public override string GetConvertedValue()
        {
            return Source?.ToString() ?? "null";
        }
    }
}
