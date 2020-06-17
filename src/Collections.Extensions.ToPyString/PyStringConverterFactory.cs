using System.Collections;
using System.Collections.Generic;

namespace Collections.Extensions.ToPyString
{
    internal static class PyStringConverterFactory
    {
        internal static IStringConverter Create(object source, IEnumerable<object> sourceContainers = default, string prefix = "")
        {
            switch (source)
            {
                case null:
                    return new NullPyStringConverter(prefix);
                case string str:
                    return new StringPyStringConverter(str, prefix);
                case KeyValuePair<object, object> keyValuePair:
                    var dictionaryEntry = new DictionaryEntry(keyValuePair.Key, keyValuePair.Value);
                    return new DictionaryEntryPyStringConverter(dictionaryEntry, sourceContainers, prefix);
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
    }
}
