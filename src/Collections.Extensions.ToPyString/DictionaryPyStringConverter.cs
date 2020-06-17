using System;
using System.Collections;
using System.Collections.Generic;

namespace Collections.Extensions.ToPyString
{
    internal class DictionaryPyStringConverter : BaseCollectionStringConverter
    {
        internal DictionaryPyStringConverter(IDictionary source, IEnumerable<object> sourceContainers, string prefix)
            : base(source, sourceContainers, prefix, BracketType.Braces)
        {
        }
    }
}
