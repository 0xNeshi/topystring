using System;
using System.Collections;
using System.Collections.Generic;

namespace Collections.Extensions.ToPyString
{
    /// <summary>
    /// Class <c>MultidimensionalArrayPyStringConverter</c> is a special handler that converts multidimensional arrays
    /// like `int[,]` into a format that can be stringified by <c>BaseCollectionPyStringConverter</c>.
    /// </summary>
    class MultidimensionalArrayPyStringConverter : BaseCollectionPyStringConverter<Array>
    {
        internal MultidimensionalArrayPyStringConverter(Array source, IEnumerable<object> sourceContainers)
            : base(source, sourceContainers, BracketType.Square)
        {
            var enumerator = source.GetEnumerator();
            Source = GetArray(source, 1, enumerator);
        }

        private Array GetArray(Array original, int rank, IEnumerator enumerator)
        {
            var length = original.GetLength(rank - 1);
            var array = new object[length];
            
            if (original.Rank == rank)
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
                    array[i] = GetArray(original, rank + 1, enumerator);
                }
            }

            return array;
        }
    }
}
