using System;

namespace GuessMyNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            do
            {
                int magicNumber = random.Next(1, 101);
                int guess;
                int attempts = 0;

                Console.WriteLine("Welcome to Guess My Number Game!");
                Console.WriteLine("I have selected a magic number between 1 and 100.");
                
                do
                {
                    Console.Write("What is your guess? ");
                    guess = Convert.ToInt32(Console.ReadLine());
                    attempts++;

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
                } while (guess != magicNumber);

                Console.WriteLine($"It took you {attempts} attempts to guess the magic number.");

                Console.Write("Do you want to play again? (yes/no): ");
            } while (Console.ReadLine().ToLower() == "yes");
        }
    }
}
