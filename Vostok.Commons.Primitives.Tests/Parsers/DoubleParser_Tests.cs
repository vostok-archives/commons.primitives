using System;
using FluentAssertions;
using NUnit.Framework;
using Vostok.Commons.Primitives.Parsers;

namespace Vostok.Commons.Primitives.Tests.Parsers
{
    [TestFixture]
    public class DoubleParser_Tests
    {
        [TestCase("1.23", true, 1.23d)]
        [TestCase("1,23", true, 1.23d)]
        [TestCase(" -1 000,23 ", true, -1000.23d)]
        [TestCase("5,12e2", true, 512d)]
        [TestCase("5'12e-2", true, 0.0512d)]
        [TestCase("abc", false, 0d)]
        public void Should_TryParse(string input, bool boolRes, double val)
        {
            var x = DoubleParser.TryParse(input, out var res);
            x.Should().Be(boolRes && Math.Abs(res - val) < 0.00000001);
        }

        [Test]
        public void Should_throw_FormatException_on_Parse_wrong_format()
        {
            new Action(() => DoubleParser.Parse(@"cba")).Should().Throw<FormatException>();
        }
    }
}