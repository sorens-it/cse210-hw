using System;

namespace SimpleFunctions
{
    class Program
    {
        static void Main(string[] args)
        {
            // Call DisplayWelcome function
            DisplayWelcome();

            // Call PromptUserName function and save the returned value
            string userName = PromptUserName();

            // Call PromptUserNumber function and save the returned value
            int favoriteNumber = PromptUserNumber();

            // Call SquareNumber function and save the returned value
            int squaredNumber = SquareNumber(favoriteNumber);

            // Call DisplayResult function
            DisplayResult(userName, squaredNumber);
        }

        // Function to display welcome message
        static void DisplayWelcome()
        {
            Console.WriteLine("Welcome to the program!");
        }

        // Function to prompt user for name and return it
        static string PromptUserName()
        {
            Console.Write("Please enter your name: ");
            return Console.ReadLine();
        }

        // Function to prompt user for favorite number and return it
        static int PromptUserNumber()
        {
            Console.Write("Please enter your favorite number: ");
            return Convert.ToInt32(Console.ReadLine());
        }

        // Function to square a number
        static int SquareNumber(int number)
        {
            return number * number;
        }

        // Function to display user's name and squared number
        static void DisplayResult(string userName, int squaredNumber)
        {
            Console.WriteLine($"{userName}, the square of your number is {squaredNumber}");
        }
    }
}
