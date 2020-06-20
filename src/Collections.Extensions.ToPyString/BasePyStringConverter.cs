using System.Collections.Generic;

namespace Collections.Extensions.ToPyString
{
    internal abstract class BasePyStringConverter : IPyStringConverter
    {
        protected BasePyStringConverter(string prefix)
        {
            Prefix = prefix;
        }

        protected BasePyStringConverter(object source, string prefix)
        {
            Source = source;
            Prefix = prefix;
        }

        protected BasePyStringConverter(object source, IEnumerable<object> sourceContainers, string prefix)
        {
            Source = source;
            SourceContainers = sourceContainers ?? new List<object>();
            Prefix = prefix;
        }

        internal virtual object Source { get; }
        internal IEnumerable<object> SourceContainers { get; } = new List<object>();
        internal string Prefix { get; }

        public abstract string Convert();
    }
}
