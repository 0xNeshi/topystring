namespace Collections.Extensions.ToPyString
{
    public static class CollectionExtensions
    {
        public static string ToPyString<T>(this T source)
        {
            var stringConverter = PyStringConverterFactory.Create(source);

            return stringConverter.GetConvertedValue();
        }
    }
}
