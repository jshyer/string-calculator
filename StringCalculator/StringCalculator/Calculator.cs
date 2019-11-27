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
                char[] delimiters = GetDelimiters(numbers);
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
                numberList.RemoveAll(x => x > 1000);
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

        private static char[] GetDelimiters(string numbers)
        {
            var delimiters = new List<char> { ',' , '\n' };
            if (numbers.StartsWith("//"))
            {
                string newDelimiter = numbers.Split('\n').First();
                char delimiter = newDelimiter.Substring(2, 1)[0];
                delimiters.Add(delimiter);
            }
            return delimiters.ToArray();
        }
    }
}
