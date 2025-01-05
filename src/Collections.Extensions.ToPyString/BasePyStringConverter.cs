using System.Collections.Generic;

namespace Collections.Extensions.ToPyString
{
    abstract class BasePyStringConverter<T> : IPyStringConverter
    {
        protected BasePyStringConverter(T source, IEnumerable<object> sourceContainers)
        {
            Source = source;
            SourceContainers = sourceContainers ?? new List<object>();
        }

        internal virtual T Source { get; set; }
        internal IEnumerable<object> SourceContainers { get; }

        public abstract string GetConvertedValue();
    }
}
