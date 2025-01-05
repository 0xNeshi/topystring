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
                case object pq when IsPriorityQueue(pq):
                    return new BaseCollectionPyStringConverter<IEnumerable>(ConvertPriorityQueueToList(source), sourceContainers, prefix, BracketType.Square);
#endif
                case DictionaryEntry dictEntry:
                    return new DictionaryEntryPyStringConverter(dictEntry, sourceContainers, prefix);
                case IDictionary dictionary:
                    return new BaseCollectionPyStringConverter<IDictionary>(dictionary, sourceContainers, prefix, BracketType.Braces);
                case object set when IsSet(set):
                    return new BaseCollectionPyStringConverter<IEnumerable>((IEnumerable) set, sourceContainers, prefix, BracketType.Braces);
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
        
        private static bool IsSet(object source)
        {
            var type = source.GetType();
            return type.IsGenericType && type.GetInterface("ISet`1") != null;
        }

#if NET6_0_OR_GREATER
        private static bool IsPriorityQueue(object source)
        {
            var type = source.GetType();
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(PriorityQueue<,>);
        }
        
        private static IList<TElement> ConvertPriorityQueueToList(PriorityQueue<TElement, TPriority> priorityQueue)
        {
            var list = new List<TElement>();

            // We need to extract all elements and their priorities
            while (priorityQueue.Count > 0)
            {
                // Dequeue the element with the highest priority
                var element = priorityQueue.Dequeue();
                list.Add(element);
            }

            return list;
        }
#endif
    }
}
