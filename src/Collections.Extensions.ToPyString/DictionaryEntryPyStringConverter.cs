using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Collections.Extensions.ToPyString
{
    class DictionaryEntryPyStringConverter : BasePyStringConverter<DictionaryEntry>
    {
        internal DictionaryEntryPyStringConverter(DictionaryEntry source, IEnumerable<object> sourceContainers)
            : base(source, sourceContainers)
        {
        }

        public override string GetConvertedValue()
        {
            var newSourceContainers = SourceContainers.Append(Source);
            var keyConverter = PyStringConverterFactory.Create(Source.Key, newSourceContainers);
            var valueConverter = PyStringConverterFactory.Create(Source.Value, newSourceContainers);

            var key = keyConverter.GetConvertedValue();
            var value = valueConverter.GetConvertedValue();

            return $"{key}: {value}";
        }
    }
}
