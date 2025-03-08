using System;

class Program
{
    static void Main(string[] args)
    {
        // Ask user for their grade percentage
        Console.Write("Enter your grade percentage: ");
        int percentage = int.Parse(Console.ReadLine());
        
        // Initialize variables for letter grade and sign
        string letter = "";
        string sign = "";
        
        // Determine the letter grade
        if (percentage >= 90)
        {
            letter = "A";
        }
        else if (percentage >= 80)
        {
            letter = "B";
        }
        else if (percentage >= 70)
        {
            letter = "C";
        }
        else if (percentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }
        
        // Determine the sign (plus or minus)
        int lastDigit = percentage % 10;
        
        if (lastDigit >= 7)
        {
            sign = "+";
        }
        else if (lastDigit < 3)
        {
            sign = "-";
        }
        else
        {
            sign = "";
        }
        
        // Handle exceptional cases
        if (letter == "A" && sign == "+")
        {
            sign = ""; // There is no A+ grade
        }
        
        if (letter == "F")
        {
            sign = ""; // There is no F+ or F- grade
        }
        
        // Print the final grade
        Console.WriteLine($"Your grade is: {letter}{sign}");
        
        // Check if the student passed the course
        if (percentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("You didn't pass this time. Keep working hard for next time!");
        }
    }
}
