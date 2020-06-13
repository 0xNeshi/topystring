namespace Collections.Extensions.ToPyString
{
    internal class StringPyStringConverter : BaseStringConverter<string>
    {
        internal StringPyStringConverter(string source, string prefix) : base(source, prefix)
        {
        }

        public override string Convert()
        {
            return Prefix + $"'{Source}'";
        }
    }
}
