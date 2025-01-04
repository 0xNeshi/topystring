using System.Collections;
using System.Collections.Generic;

namespace Collections.Extensions.ToPyString
{
    class SetPyStringConverter : BaseCollectionPyStringConverter<ISet>
    {
        internal SetPyStringConverter(ISet source, IEnumerable<object> sourceContainers, string prefix)
            : base(source, sourceContainers, prefix, BracketType.Braces)
        {
        }
    }
}
