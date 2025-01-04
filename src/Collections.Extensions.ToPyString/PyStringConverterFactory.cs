using System;
using System.Collections;
using System.Collections.Generic;

namespace Collections.Extensions.ToPyString
{
    static class PyStringConverterFactory
    {
        internal static IPyStringConverter Create<T>(T source, IEnumerable<object> sourceContainers = default, string prefix = "")
        {
            if (PyStringConverterFactory.TryCastToDictionaryEntry(source, out var dictionaryEntry))
            {
                return new DictionaryEntryPyStringConverter(dictionaryEntry, sourceContainers, prefix);
            }

            switch (source)
            {
                case char ch:
                    return new StringPyStringConverter(ch, sourceContainers, prefix);
                case string str:
                    return new StringPyStringConverter(str, sourceContainers, prefix);
                case decimal dec:
                    return new DecimalPyStringConverter(dec, sourceContainers, prefix);
                case float fl:
                    return new DecimalPyStringConverter(fl, sourceContainers, prefix);
                case double doub:
                    return new DecimalPyStringConverter(doub, sourceContainers, prefix);
#if NET6_0_OR_GREATER
                case PriorityQueue<TElement, TPriority> pq:
                    return new PriorityQueuePyStringConverter<TElement, TPriority>(pq, sourceContainers, prefix);
#endif
                case DictionaryEntry dictEntry:
                    return new DictionaryEntryPyStringConverter(dictEntry, sourceContainers, prefix);
                case IDictionary dictionary:
                    return new DictionaryPyStringConverter(dictionary, sourceContainers, prefix);
                case Array array when array.Rank > 1:
                    return new MultidimensionalArrayPyStringConverter(array, sourceContainers, prefix);
                case IEnumerable enumerable:
                    return new EnumerablePyStringConverter(enumerable, sourceContainers, prefix);
                default:
                    return new ObjectPyStringConverter(source, sourceContainers, prefix);
            }
        }

        private static bool TryCastToDictionaryEntry(object source, out DictionaryEntry dictionaryEntry)
        {
            dictionaryEntry = default;

            if (source == null)
            {
                return false;
            }

            var sourceType = source.GetType();

            if (sourceType.IsGenericType
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
