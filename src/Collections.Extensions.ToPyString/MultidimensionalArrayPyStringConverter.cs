using System;
using System.Collections;
using System.Collections.Generic;

namespace Collections.Extensions.ToPyString
{
    class MultidimensionalArrayPyStringConverter : BaseCollectionPyStringConverter<Array>
    {
        internal MultidimensionalArrayPyStringConverter(Array source, IEnumerable<object> sourceContainers, string prefix)
            : base(source, sourceContainers, prefix, BracketType.Square)
        {
            var enumerator = source.GetEnumerator();
            Source = GetArray(source, 1, enumerator);
        }

        private Array GetArray(Array source, int rank, IEnumerator enumerator)
        {
            var length = source.GetLength(rank - 1);
            var array = new object[length];
            
            if (source.Rank == rank)
            {
                for (var i = 0; i < length; i++)
                {
                    enumerator.MoveNext();
                    array[i] = enumerator.Current;
                }
            }
            else
            {
                for (var i = 0; i < length; i++)
                {
                    array[i] = GetArray(source, rank + 1, enumerator);
                }
            }

            return array;
        }
    }
}
