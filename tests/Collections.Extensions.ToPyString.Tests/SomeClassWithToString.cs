namespace Collections.Extensions.ToPyString.Tests
{
    public class SomeClassWithToString
    {
        public int SomeIntProperty { get; set; }
        public string SomeStringProperty { get; set; }

        public override string ToString()
        {
            return $"SomeClass with int property = {SomeIntProperty} and string property = {SomeStringProperty}";
        }
    }
}
