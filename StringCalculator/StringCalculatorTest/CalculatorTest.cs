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
        [InlineData(5001, "1,5000")]
        [InlineData(1, "4,-3")]
        public void ReturnSum_GivenTwoNumbers(int expected, string input)
        {
            int result = Calculator.Add(input);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1, "4,-3")]
        public void ReturnDifference_GivenOnePositiveAndOneNegativeNumber(int expected, string input)
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
    }
}
