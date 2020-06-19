using System;
using System.Collections;
using System.Collections.Generic;

namespace Collections.Extensions.ToPyString
{
    static class PyStringConverterFactory
    {
        internal static IStringConverter Create(object source, IEnumerable<object> sourceContainers = default, string prefix = "")
        {
            if (TryCastToDictionaryEntry(source, out var dictionaryEntry))
            {
                return new DictionaryEntryPyStringConverter(dictionaryEntry, sourceContainers, prefix);
            }

            switch (source)
            {
                case null:
                    return new NullPyStringConverter(prefix);
                case char _:
                case string _:
                    return new StringPyStringConverter(source.ToString(), sourceContainers, prefix);
                case decimal _:
                case float _:
                case double _:
                    return new DecimalPyStringConverter(Convert.ToDecimal(source), prefix);
                case DictionaryEntry dictEntry:
                    return new DictionaryEntryPyStringConverter(dictEntry, sourceContainers, prefix);
                case IDictionary dictionary:
                    return new DictionaryPyStringConverter(dictionary, sourceContainers, prefix);
                case IEnumerable enumerable:
                    return new EnumerablePyStringConverter(enumerable, sourceContainers, prefix);
                default:
                    return new ObjectPyStringConverter(source, prefix);
            };
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
