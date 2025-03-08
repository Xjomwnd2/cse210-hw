using System;

class Program
{
    static void Main(string[] args)
    {
        // Declare variables
        string name;
        int age;
        double height;
        
        // Get user input
        Console.Write("Enter your name: ");
        name = Console.ReadLine();
        
        Console.Write("Enter your age: ");
        age = Convert.ToInt32(Console.ReadLine());
        
        Console.Write("Enter your height in meters: ");
        height = Convert.ToDouble(Console.ReadLine());
        
        // Display output
        Console.WriteLine("\nHello, " + name + "!");
        Console.WriteLine("You are " + age + " years old.");
        Console.WriteLine("You are " + height + " meters tall.");
        
        // Using string interpolation (more modern approach)
        Console.WriteLine($"\nHello, {name}!");
        Console.WriteLine($"You are {age} years old.");
        Console.WriteLine($"You are {height} meters tall.");
        
        Console.ReadKey();

        Console.WriteLine("Great! Success");
    }
}