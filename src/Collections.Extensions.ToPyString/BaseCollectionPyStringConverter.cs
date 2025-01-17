﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Collections.Extensions.ToPyString
{
    class BaseCollectionPyStringConverter<T> : BasePyStringConverter<T> where T : IEnumerable
    {
        private readonly IDictionary<BracketType, BracketPair> _bracketPairsDictionary = new Dictionary<BracketType, BracketPair>
        {
            [BracketType.Parantheses] = new BracketPair("(", ")"),
            [BracketType.Square] = new BracketPair("[", "]"),
            [BracketType.Braces] = new BracketPair("{", "}"),
        };

        private readonly BracketPair _bracketPair;

        internal BaseCollectionPyStringConverter(T source, IEnumerable<object> sourceContainers, BracketType bracketType)
            : base(source, sourceContainers)
        {
            _bracketPair = _bracketPairsDictionary[bracketType];
        }

        public override string GetConvertedValue()
        {
            if (SourceContainers.Contains(Source))
            {
                return CollectionReferenceLoopToString();
            }

            var en = Source.GetEnumerator();
            var sb = new StringBuilder(_bracketPair.OpeningBracket);
            if (en.MoveNext())
            {
                var newSourceContainers = SourceContainers.Append(Source);
                var firstConverter = PyStringConverterFactory.Create(en.Current, newSourceContainers);
                sb.Append(firstConverter.GetConvertedValue());
                while (en.MoveNext())
                {
                    var converter = PyStringConverterFactory.Create(en.Current, newSourceContainers);
                    sb.Append(", ");
                    sb.Append(converter.GetConvertedValue());
                }
            }

            sb.Append(_bracketPair.ClosingBracket);

            return sb.ToString();
        }

        private string CollectionReferenceLoopToString()
        {
            return _bracketPair.OpeningBracket + "..." + _bracketPair.ClosingBracket;
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
        None = 0,
        Parantheses,
        Square,
        Braces
    }
}
