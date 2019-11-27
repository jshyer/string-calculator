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
                string[] delimiters = GetDelimiters(numbers);
                string[] ints = numbers.Split(delimiters, StringSplitOptions.None);
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

        private static string[] GetDelimiters(string numbers)
        {
            var delimiters = new List<string> { "," , "\n" };
            if (numbers.StartsWith("//"))
            {
                string newDelimiter = numbers.Split('\n').First().Substring(2);
                if (newDelimiter.StartsWith("["))
                {
                    if(newDelimiter.Count(x => x == '[') > 2)
                    {
                        string[] multipleDelimiters = newDelimiter.Split('[', ']');
                        delimiters.AddRange(multipleDelimiters);
                    }
                    else
                    {
                        delimiters.Add(newDelimiter.Substring(1, newDelimiter.Length - 2));
                    }
                }
                else
                {
                    delimiters.Add(newDelimiter);
                }
            }
            return delimiters.ToArray();
        }
    }
}
