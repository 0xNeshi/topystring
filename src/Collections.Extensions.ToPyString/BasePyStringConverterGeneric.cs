using System.Collections.Generic;

namespace Collections.Extensions.ToPyString
{
    internal abstract class BaseStringConverter<T> : BasePyStringConverter
    {
        protected BaseStringConverter(string prefix)
            : base(prefix)
        {
        }

        protected BaseStringConverter(T source, string prefix)
            : base(source, prefix)
        {
            Source = source;
        }

        protected BaseStringConverter(T source, IEnumerable<object> sourceContainers, string prefix)
            : base(source, sourceContainers, prefix)
        {
            Source = source;
        }

        internal new T Source { get; }
    }
}
