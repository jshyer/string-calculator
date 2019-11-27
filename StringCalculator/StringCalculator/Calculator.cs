using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class Calculator
    {
        public static void Main(string[] args)
        {
        }
        public static int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }
            else
            {
                char[] delimiters = { ',', '\n' };
                string[] ints = numbers.Split(delimiters);
                List<int> numberList = new List<int>();

                foreach(var i in ints)
                {
                    if(int.TryParse(i, out int number))
                    {
                        numberList.Add(number);
                    }
                }
                DenyNegativeNumbers(numberList);
                return numberList.Sum();
            }

        }
        private static void DenyNegativeNumbers(List<int> numberList)
        {
            if (numberList.Any(x => x < 0))
            {
                throw new NoNegativeNumbersException(numberList);
            }
        }
    }
}
