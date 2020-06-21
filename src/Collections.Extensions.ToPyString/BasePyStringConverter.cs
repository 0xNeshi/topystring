using System.Collections.Generic;

namespace Collections.Extensions.ToPyString
{
    internal abstract class BasePyStringConverter<T> : IPyStringConverter
    {
        protected BasePyStringConverter(T source, string prefix)
        {
            Source = source;
            Prefix = prefix;
        }

        protected BasePyStringConverter(T source, IEnumerable<object> sourceContainers, string prefix)
        {
            Source = source;
            SourceContainers = sourceContainers ?? new List<object>();
            Prefix = prefix;
        }

        internal virtual T Source { get; }
        internal IEnumerable<object> SourceContainers { get; } = new List<object>();
        internal string Prefix { get; }

        public abstract string Convert();
    }
}
