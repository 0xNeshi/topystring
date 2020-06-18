using System;

namespace Collections.Extensions.ToPyString
{
    class NullPyStringConverter : BaseStringConverter
    {
        internal NullPyStringConverter(string prefix) : base(prefix)
        {
        }

        public override string Convert()
        {
            return Prefix + "null";
        }
    }
}
