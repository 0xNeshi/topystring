using System;
using System.Collections;
using System.Collections.Generic;

namespace Collections.Extensions.ToPyString
{
#if NET6_0_OR_GREATER
    class PriorityQueuePyStringConverter<TElement, TPriority> : BaseCollectionPyStringConverter<IList<TElement>>
    {
        internal PriorityQueuePyStringConverter(PriorityQueue<TElement, TPriority> source, IEnumerable<object> sourceContainers, string prefix)
            : base(ConvertPriorityQueueToList(source), sourceContainers, prefix, BracketType.Square)
        {
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
    }
#endif
}
