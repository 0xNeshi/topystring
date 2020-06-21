using System.Collections.Generic;

namespace Collections.Extensions.ToPyString
{
    class ObjectPyStringConverter : BasePyStringConverter<object>
    {
        internal ObjectPyStringConverter(object source, IEnumerable<object> sourceContainers, string prefix)
            : base(source, sourceContainers, prefix)
        {
        }

        public override string GetConvertedValue()
        {
            return Prefix + Source.ToString();
        }
    }
}
