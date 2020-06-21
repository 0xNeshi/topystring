using System.Collections;
using System.Collections.Generic;

namespace Collections.Extensions.ToPyString
{
    class EnumerablePyStringConverter : BaseCollectionPyStringConverter
    {
        internal EnumerablePyStringConverter(IEnumerable source, IEnumerable<object> sourceContainers, string prefix)
            : base(source, sourceContainers, prefix, BracketType.Square)
        {
        }
    }
}
