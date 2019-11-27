using System;
using System.Collections.Generic;
using System.Text;

namespace StringCalculator
{
    public class NoNegativeNumbersException : Exception
    {
        public NoNegativeNumbersException(List<int> negativeNumbers)
            : base($"Negative Numbers Not Allowed: {string.Join(",", negativeNumbers)}")
        {

        }
    }
}
