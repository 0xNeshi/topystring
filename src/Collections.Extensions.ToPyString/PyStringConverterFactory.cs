﻿using System;
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
#if NET6_0_OR_GREATER
                case object pq when IsPriorityQueue(pq):
                    return new BaseCollectionPyStringConverter<IEnumerable>(ConvertPriorityQueueToList(pq), sourceContainers, prefix, BracketType.Square);
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
        
        private static IEnumerable ConvertPriorityQueueToList(object pq)
        {
            var type = pq.GetType();
            var count = (int)type.GetProperty("Count").GetValue(pq);
            var elementType = type.GetGenericArguments()[0];

            // Create array with known size and correct element type
            var array = Array.CreateInstance(elementType, count);
            var dequeueMethod = type.GetMethod("Dequeue");

            // Dequeue elements into array
            for (int i = 0; i < count; i++)
            {
                array.SetValue(dequeueMethod.Invoke(pq, null), i);
            }

            return array;
        }
#endif
    }
}
