using System.Collections.Generic;

namespace Collections.Extensions.ToPyString
{
    internal abstract class BaseStringConverter : IStringConverter
    {
        protected BaseStringConverter(string prefix)
        {
            Prefix = prefix;
        }

        protected BaseStringConverter(object source, string prefix)
        {
            Source = source;
            Prefix = prefix;
        }

        protected BaseStringConverter(object source, IEnumerable<object> sourceContainers, string prefix)
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
