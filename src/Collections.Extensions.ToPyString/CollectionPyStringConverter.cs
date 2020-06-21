using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Collections.Extensions.ToPyString
{
    internal class CollectionPyStringConverter : BasePyStringConverter<IEnumerable>
    {
        private readonly IDictionary<BracketType, BracketPair> _bracketPairsDictionary = new Dictionary<BracketType, BracketPair>
        {
            [BracketType.Parantheses] = new BracketPair("(", ")"),
            [BracketType.Square] = new BracketPair("[", "]"),
            [BracketType.Braces] = new BracketPair("{", "}"),
        };

        private readonly BracketPair _bracketPair;

        public CollectionPyStringConverter(IEnumerable source, IEnumerable<object> sourceContainers, string prefix, BracketType bracketType)
            : base(source, sourceContainers, prefix)
        {
            _bracketPair = _bracketPairsDictionary[bracketType];
        }

        public override string Convert()
        {
            if (SourceContainers.Contains(Source))
            {
                return Prefix + _bracketPair.OpeningBracket + "..." + _bracketPair.ClosingBracket;
            }

            var en = Source.GetEnumerator();
            var sb = new StringBuilder(_bracketPair.OpeningBracket);
            if (en.MoveNext())
            {
                var newSourceContainers = SourceContainers.Append(Source);
                var converter = PyStringConverterFactory.Create(en.Current, newSourceContainers);
                sb.Append(converter.Convert());
                while (en.MoveNext())
                {
                    converter = PyStringConverterFactory.Create(en.Current, newSourceContainers, ", ");
                    sb.Append(converter.Convert());
                }
            }

            sb.Append(_bracketPair.ClosingBracket);

            return Prefix + sb.ToString();
        }

        private class BracketPair
        {
            internal BracketPair(string openingBracket, string closingBracket)
            {
                OpeningBracket = openingBracket;
                ClosingBracket = closingBracket;
            }

            internal string OpeningBracket { get; }
            internal string ClosingBracket { get; }
        }
    }

    internal enum BracketType
    {
        Parantheses = 0,
        Square,
        Braces
    }
}
