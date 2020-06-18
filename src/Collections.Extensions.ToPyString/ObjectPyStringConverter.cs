namespace Collections.Extensions.ToPyString
{
    class ObjectPyStringConverter : BaseStringConverter<object>
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
