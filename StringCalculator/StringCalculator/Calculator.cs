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
                if (numbers.Contains(","))
                {
                    string[] ints = numbers.Split(",");
                    List<int> numberList = new List<int>();

                    foreach(var i in ints)
                    {
                        if(int.TryParse(i, out int number))
                        {
                            numberList.Add(number);
                        }
                    }
                    return numberList.Sum();
                }
                return int.Parse(numbers);
            }
        }
    }
}
