using System;

class Program
{
    static void Main(string[] args)
    {
        // Variable to track if the user wants to play again
        string playAgain = "yes";
        
        // Main game loop - continues as long as user wants to play
        while (playAgain.ToLower() == "yes")
        {
            // Generate a random number between 1 and 100
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101);
            
            // Optional: Uncomment for debugging
            // Console.WriteLine($"(Debug: The magic number is {magicNumber})");
            
            // Initialize guess counter
            int guessCount = 0;
            
            // Initialize user's guess to something that's definitely not the magic number
            int guess = -1;
            
            // Game loop - continues until user guesses the magic number
            while (guess != magicNumber)
            {
                // Ask user for a guess
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                
                // Increment the guess counter
                guessCount++;
                
                // Check if the guess is correct, too high, or too low
                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                }
            }
            
            // Display the number of guesses made
            Console.WriteLine($"It took you {guessCount} guesses.");
            
            // Ask if the user wants to play again
            Console.Write("Do you want to play again? (yes/no) ");
            playAgain = Console.ReadLine();
        }
        
        Console.WriteLine("Thanks for playing!");
    }
}
