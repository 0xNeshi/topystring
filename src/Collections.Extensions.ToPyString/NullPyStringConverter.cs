namespace Collections.Extensions.ToPyString
{
    class NullPyStringConverter : BasePyStringConverter
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
