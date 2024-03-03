using System;
using System.Collections.Generic;
using System.Linq;

namespace NumberAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();

            Console.WriteLine("Enter a list of numbers, type 0 when finished.");

            int num;
            do
            {
                Console.Write("Enter number: ");
                num = Convert.ToInt32(Console.ReadLine());
                if (num != 0)
                {
                    numbers.Add(num);
                }
            } while (num != 0);

            if (numbers.Count == 0)
            {
                Console.WriteLine("No numbers entered.");
                return;
            }

            // Core Requirements
            int sum = numbers.Sum();
            double average = numbers.Average();
            int max = numbers.Max();

            Console.WriteLine($"The sum is: {sum}");
            Console.WriteLine($"The average is: {average}");
            Console.WriteLine($"The largest number is: {max}");

            // Stretch Challenge
            List<int> positiveNumbers = numbers.Where(n => n > 0).ToList();
            if (positiveNumbers.Count > 0)
            {
                int minPositive = positiveNumbers.Min();
                Console.WriteLine($"The smallest positive number is: {minPositive}");
            }
            else
            {
                Console.WriteLine("No positive numbers entered.");
            }

            List<int> sortedNumbers = numbers.OrderBy(n => n).ToList();
            Console.WriteLine("The sorted list is:");
            foreach (int n in sortedNumbers)
            {
                Console.WriteLine(n);
            }
        }
    }
}
