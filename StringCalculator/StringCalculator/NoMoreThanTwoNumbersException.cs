using System;
using System.Collections.Generic;
using System.Text;

namespace StringCalculator
{
    public class NoMoreThanTwoNumbersException : Exception
    {
        public NoMoreThanTwoNumbersException(string numbers)
            : base("No More Than Two Numbers Allowed")
        {

        }
    }
}
