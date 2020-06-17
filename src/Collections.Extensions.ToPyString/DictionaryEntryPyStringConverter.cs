using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Collections.Extensions.ToPyString
{
    internal class DictionaryEntryPyStringConverter : BaseStringConverter<DictionaryEntry>
    {
        internal DictionaryEntryPyStringConverter(DictionaryEntry source, IEnumerable<object> sourceContainers, string prefix)
            : base(source, sourceContainers, prefix)
        {
        }

        public override string Convert()
        {
            var newSourceContainers = SourceContainers.Append(Source);
            var keyConverter = PyStringConverterFactory.Create(Source.Key, newSourceContainers);
            var valueConverter = PyStringConverterFactory.Create(Source.Value, newSourceContainers);
            return $"{Prefix}{keyConverter.Convert()}: {valueConverter.Convert()}";
        }
    }
}
