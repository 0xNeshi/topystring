using System;
using System.Collections;
using System.Collections.Generic;

namespace Collections.Extensions.ToPyString
{
    static class PyStringConverterFactory
    {
        internal static IPyStringConverter Create<T>(T source, IEnumerable<object> sourceContainers = default, string prefix = "")
        {
            if (TryCastToDictionaryEntry(source, out var dictionaryEntry))
            {
                return new DictionaryEntryPyStringConverter(dictionaryEntry, sourceContainers, prefix);
            }

            IPyStringConverter converter = source switch
            {
                char ch => (IPyStringConverter)new StringPyStringConverter(ch, sourceContainers, prefix),
                string str => new StringPyStringConverter(str, sourceContainers, prefix),
                decimal dec => new DecimalPyStringConverter(dec, sourceContainers, prefix),
                float fl => new DecimalPyStringConverter(fl, sourceContainers, prefix),
                double doub => new DecimalPyStringConverter(doub, sourceContainers, prefix),
                DictionaryEntry dictEntry => new DictionaryEntryPyStringConverter(dictEntry, sourceContainers, prefix),
                IDictionary dictionary => new DictionaryPyStringConverter(dictionary, sourceContainers, prefix),
                Array array when array.Rank > 1 => new MultidimensionalArrayPyStringConverter(array, sourceContainers, prefix),
                IEnumerable enumerable => new EnumerablePyStringConverter(enumerable, sourceContainers, prefix),
                _ => new ObjectPyStringConverter(source, sourceContainers, prefix),
            };

            return converter;
        }

        private static bool TryCastToDictionaryEntry(object source, out DictionaryEntry dictionaryEntry)
        {
            var sourceType = source?.GetType();

            if (source != null
                && sourceType.IsGenericType
                && sourceType.GetGenericTypeDefinition() == typeof(KeyValuePair<,>))
            {
                var key = sourceType.GetProperty(nameof(KeyValuePair<object, object>.Key)).GetValue(source, null);
                var value = sourceType.GetProperty(nameof(KeyValuePair<object, object>.Value)).GetValue(source, null);
                dictionaryEntry = new DictionaryEntry(key, value);

                return true;
            }

            return false;
        }
    }
}
