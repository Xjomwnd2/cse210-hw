using System;
using System.Collections.Generic;

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
        
        if (numbers.Count > 0)
        {
            int sum = 0;
            int maxNumber = numbers[0];
            int? minPositive = null;
            
            foreach (int num in numbers)
            {
                sum += num;
                if (num > maxNumber)
                    maxNumber = num;
                if (num > 0 && (minPositive == null || num < minPositive))
                    minPositive = num;
            }
            
            double average = (double)sum / numbers.Count;
            numbers.Sort();
            
            Console.WriteLine($"The sum is: {sum}");
            Console.WriteLine($"The average is: {average}");
            Console.WriteLine($"The largest number is: {maxNumber}");
            if (minPositive.HasValue)
                Console.WriteLine($"The smallest positive number is: {minPositive}");
            
            Console.WriteLine("The sorted list is:");
            foreach (int num in numbers)
            {
                Console.WriteLine(num);
            }
        }
        else
        {
            Console.WriteLine("No numbers were entered.");
        }
    }
}
