using System;
using Xunit;
using StringCalculator;

namespace StringCalculatorTest
{
    public class CalculatorTest
    {
        [Fact]
        public void Return0_GivenEmptyString()
        {
            int result = Calculator.Add("");
            Assert.Equal(0, result);
        }

        [Theory]
        [InlineData(20, "20")]
        public void ReturnNumber_GivenNumber(int expected, string input)
        {
            int result = Calculator.Add(input);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1, "1,")]
        public void ReturnNumber_GivenNumberAndEmptyNumber(int expected, string input)
        {
            int result = Calculator.Add(input);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(5, "5,tytyt")]
        public void Return0_GivenInvalidNumber(int expected, string input)
        {
            int result = Calculator.Add(input);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(78, "1,2,3,4,5,6,7,8,9,10,11,12")]
        public void ReturnSum_GivenMoreThanTwoNumbers(int expected, string input)
        {
            int result = Calculator.Add(input);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(6, "1\n2,3")]
        [InlineData(6, "1\n2\n3")]
        public void ReturnSum_GivenNonCommaDelimiter(int expected, string input)
        {
            int result = Calculator.Add(input);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(-3, "4,-3")]
        [InlineData(-1, "-11,10")]
        public void ReturnExceptionWithMessage_GivenNegativeNumbers(int expected, string input)
        {
            var calculator = new Calculator();
            var exception = Assert.Throws<NoNegativeNumbersException>(() => Calculator.Add(input));
            Assert.Contains(expected.ToString(), exception.Message);
        }

        [Theory]
        [InlineData(8, "2,1001,6")]
        public void ReturnSum_IgnoreNumbersAbove1000(int expected, string input)
        {
            int result = Calculator.Add(input);
            Assert.Equal(expected, result);
        }
    }
}
