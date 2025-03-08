using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        
        while (true)
        {
            Console.Write("Enter number: ");
            int number = int.Parse(Console.ReadLine());
            
            if (number == 0)
                break;
            
            numbers.Add(number);
        }

        // Compute the sum
        int sum = numbers.Sum();
        Console.WriteLine($"The sum is: {sum}");
        
        // Compute the average
        double average = numbers.Average();
        Console.WriteLine($"The average is: {average}");
        
        // Find the maximum number
        int maxNumber = numbers.Max();
        Console.WriteLine($"The largest number is: {maxNumber}");
        
        // Stretch challenge: Find the smallest positive number
        int? smallestPositive = numbers.Where(n => n > 0).DefaultIfEmpty(int.MaxValue).Min();
        if (smallestPositive != int.MaxValue)
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        
        // Stretch challenge: Sort and display the list
        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }
    }
}

