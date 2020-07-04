using Xunit;
using System.Collections.Generic;

namespace NumbersToWords.UnitTests
{
    public class UnitTests
    {
        private readonly NumbersToText _sut;
        public UnitTests()
        {
            _sut = new NumbersToText();
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void NumbersToText_InputIs0_ReturnWords(string words, float number)
        {
            var result = _sut.DollarRepresentation(number);
            Assert.Equal(words, result);
        }

        public static IEnumerable<object[]> TestData()
        {
            yield return new object[] { "zero dollars", 0 };
            yield return new object[] { "twelve cents", 0.12 };
            yield return new object[] { "ten dollars and fifty five cents", 10.55 };
            yield return new object[] { "one hundred and twenty dollars", 120 };
            yield return new object[] { "negative one hundred and twenty three dollars and forty five cents", -123.45 };
            yield return new object[] { "one hundred and twenty dollars and ten cents", 120.0965 };
            yield return new object[] { "nine hundred and ninety nine thousand nine hundred and ninety nine dollars", 999999 };
            yield return new object[] { "negative nine hundred and ninety nine thousand nine hundred and ninety nine dollars", -999999 };
        }
    }
}


