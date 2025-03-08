using System;

class Program
{
    static void Main(string[] args)
    {
        // If-else statement example
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());
        
        if (number > 0)
        {
            Console.WriteLine("The number is positive.");
        }
        else if (number < 0)
        {
            Console.WriteLine("The number is negative.");
        }
        else
        {
            Console.WriteLine("The number is zero.");
        }
        
        // Switch statement example
        Console.Write("\nEnter a day number (1-7): ");
        int day = Convert.ToInt32(Console.ReadLine());
        
        switch (day)
        {
            case 1:
                Console.WriteLine("Monday");
                break;
            case 2:
                Console.WriteLine("Tuesday");
                break;
            case 3:
                Console.WriteLine("Wednesday");
                break;
            case 4:
                Console.WriteLine("Thursday");
                break;
            case 5:
                Console.WriteLine("Friday");
                break;
            case 6:
                Console.WriteLine("Saturday");
                break;
            case 7:
                Console.WriteLine("Sunday");
                break;
            default:
                Console.WriteLine("Invalid day number");
                break;
        }
        
        Console.ReadKey();

        Console.WriteLine("Hello World! This is the Journal Project.");
    }
}