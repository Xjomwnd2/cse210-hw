using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Resumes Project!");
        Console.WriteLine("Please enter your name:");
        string name = Console.ReadLine();

        Console.WriteLine("Enter your email:");
        string email = Console.ReadLine();

        Console.WriteLine("Enter your phone number:");
        string phone = Console.ReadLine();

        Console.WriteLine("Enter your education details:");
        string education = Console.ReadLine();

        Console.WriteLine("Enter your work experience:");
        string experience = Console.ReadLine();

        Console.WriteLine("Enter your skills:");
        string skills = Console.ReadLine();

        Console.WriteLine("\nHere is your resume:\n");
        Console.WriteLine("------------------------------------");
        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"Email: {email}");
        Console.WriteLine($"Phone: {phone}");
        Console.WriteLine($"Education: {education}");
        Console.WriteLine($"Work Experience: {experience}");
        Console.WriteLine($"Skills: {skills}");
        Console.WriteLine("------------------------------------");
    }
}
