using System;
using System.Collections;
using System.Collections.Generic;

namespace Collections.Extensions.ToPyString
{
#if NET6_0_OR_GREATER
    class PriorityQueuePyStringConverter<TElement, TPriority> : BaseCollectionPyStringConverter<PriorityQueue<TElement, TPriority>>
    {
        internal PriorityQueuePyStringConverter(PriorityQueue<TElement, TPriority> source, IEnumerable<object> sourceContainers, string prefix)
            : base(source, sourceContainers, prefix, BracketType.Square)
        {
            Source = ConvertPriorityQueueToArray(source);
        }

        private object[] ConvertPriorityQueueToArray(PriorityQueue<TElement, TPriority> priorityQueue)
        {
            var list = new List<object>();

            // We need to extract all elements and their priorities
            while (priorityQueue.Count > 0)
            {
                // Dequeue the element with the highest priority
                var element = priorityQueue.Dequeue();
                list.Add(element);
            }

            return list.ToArray();
        }
    }
#endif
}
