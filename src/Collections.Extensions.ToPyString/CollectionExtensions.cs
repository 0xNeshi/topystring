namespace Collections.Extensions.ToPyString
{
    public static class CollectionExtensions
    {
        public static string ToPyString(this object source)
        {
            var stringConverter = PyStringConverterFactory.Create(source);

            return stringConverter.Convert();
        }
    }
}
