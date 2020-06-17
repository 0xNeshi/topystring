namespace Collections.Extensions.ToPyString
{
    internal class ObjectPyStringConverter : BaseStringConverter<object>
    {
        internal ObjectPyStringConverter(object source, string prefix) : base(source, prefix)
        {
        }

        public override string Convert()
        {
            return Prefix + Source.ToString();
        }
    }
}
