using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterviewQuestions.Implementations
{
    class NumbersDemo
    {
        public static void Run()
        {

            Console.WriteLine(" *--------------*");
            Console.WriteLine(" | Numbers Demo |");
            Console.WriteLine(" *--------------*");

            Console.WriteLine("\nFind the missing number in the range...");
            Random random = new Random();
            int rangeStart = random.Next(5000);
            int rangeEnd=0;
            while (rangeEnd - rangeStart <= 2)
            {
                rangeEnd = rangeStart + random.Next(50);
            }

            int missingNumber = random.Next(rangeStart, rangeEnd);


            int[] rangeOfNumbers = Enumerable.Range(rangeStart, rangeEnd).Where(x => x != missingNumber).ToArray();
            Console.WriteLine("Range ({0}, {1})", rangeStart, rangeEnd);
            Console.WriteLine("Expected missing number: {0}", missingNumber);
            int result = Numbers.MissingInRange(rangeOfNumbers);
            Console.WriteLine("Missing number is: {0}", result);
        }
    }
}
