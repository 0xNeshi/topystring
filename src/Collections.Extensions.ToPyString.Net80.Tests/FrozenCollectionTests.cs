using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using Xunit;

namespace Collections.Extensions.ToPyString.Tests
{
    public class ModernCollectionTests
    {
        [Fact]
        public void ToPyString_FrozenDictionary_ReturnsCorrectFormat()
        {
            var dictionary = new Dictionary<string, int>
            {
                ["one"] = 1,
                ["two"] = 2,
                ["three"] = 3
            };
            var frozen = dictionary.ToFrozenDictionary();

            var result = frozen.ToPyString();

            Assert.Equal("{'one': 1, 'two': 2, 'three': 3}", result);
        }

        [Fact]
        public void ToPyString_FrozenSet_ReturnsCorrectFormat()
        {
            var set = new HashSet<int> { 1, 2, 3 };
            var frozen = set.ToFrozenSet();

            var result = frozen.ToPyString();

            Assert.Equal("{1, 2, 3}", result);
        }

        [Fact]
        public void ToPyString_EmptyFrozenSet_ReturnsCorrectFormat()
        {
            var set = new HashSet<int>();
            var frozen = set.ToFrozenSet();

            var result = frozen.ToPyString();

            Assert.Equal("{}", result);
        }

        [Fact]
        public void ToPyString_EmptyFrozenDictionary_ReturnsCorrectFormat()
        {
            var dictionary = new Dictionary<string, int>();
            var frozen = dictionary.ToFrozenDictionary();

            var result = frozen.ToPyString();

            Assert.Equal("{}", result);
        }

        [Fact]
        public void ToPyString_NestedFrozenCollections_ReturnsCorrectFormat()
        {
            var dict = new Dictionary<string, ISet<int>>
            {
                ["numbers"] = new HashSet<int> { 1, 2, 3 }.ToFrozenSet(),
                ["more"] = new HashSet<int> { 4, 5, 6 }.ToFrozenSet()
            };
            var frozen = dict.ToFrozenDictionary();

            var result = frozen.ToPyString();

            Assert.Equal("{'numbers': {1, 2, 3}, 'more': {4, 5, 6}}", result);
        }
    }
}