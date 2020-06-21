using System.Collections.Generic;

namespace Collections.Extensions.ToPyString
{
    abstract class BasePyStringConverter<T> : IPyStringConverter
    {
        protected BasePyStringConverter(T source, IEnumerable<object> sourceContainers, string prefix)
        {
            Source = source;
            SourceContainers = sourceContainers ?? new List<object>();
            Prefix = prefix;
        }

        internal virtual T Source { get; set; }
        internal IEnumerable<object> SourceContainers { get; }
        internal string Prefix { get; }

        public abstract string GetConvertedValue();
    }
}
