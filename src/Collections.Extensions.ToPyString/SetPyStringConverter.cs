using System.Collections;
using System.Collections.Generic;

namespace Collections.Extensions.ToPyString
{
    class SetPyStringConverter<T> : BaseCollectionPyStringConverter<ISet<T>>
    {
        internal SetPyStringConverter(ISet<T> source, IEnumerable<object> sourceContainers, string prefix)
            : base(source, sourceContainers, prefix, BracketType.Braces)
        {
        }
    }
}
