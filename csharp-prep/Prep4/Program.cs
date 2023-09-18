using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    // This program will ask the user for a series of numbers,
    // When the user type 0.
    {
        List<int> numbers = new List<int>();
        int number;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        do
        {
            Console.Write("Enter number: ");
            if (int.TryParse(Console.ReadLine(), out number))
            {
                numbers.Add(number);
            }
        } while (number != 0);

        if (numbers.Count == 0)
        {
            Console.WriteLine("No numbers entered.");
        }
        else
        {
            int sum = numbers.Sum();
            float average = ((float)sum) / numbers.Count;
            int largest = numbers.Max();
            int smallestPositive = numbers.Where(x => x > 0).Min();
            List<int> sortedNumbers = numbers.OrderByDescending(x => x).ToList();

            Console.WriteLine($"The sum is: {sum}");
            Console.WriteLine($"The average is: {average}");
            Console.WriteLine($"The largest number is: {largest}");
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
            Console.WriteLine("The sorted list is:");
            foreach (int num in numbers)
            {
                Console.WriteLine(num);
            }
        }
    }
}


