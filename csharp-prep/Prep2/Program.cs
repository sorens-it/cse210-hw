using System;

namespace GradeCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your grade percentage:");
            int gradePercentage = Convert.ToInt32(Console.ReadLine());

            // Core Requirements
            string letter = ""; // Initialize the letter grade variable

            if (gradePercentage >= 90)
            {
                letter = "A";
            }
            else if (gradePercentage >= 80)
            {
                letter = "B";
            }
            else if (gradePercentage >= 70)
            {
                letter = "C";
            }
            else if (gradePercentage >= 60)
            {
                letter = "D";
            }
            else
            {
                letter = "F";
            }

            // Determine pass or fail
            if (gradePercentage >= 70)
            {
                Console.WriteLine("Congratulations! You passed the course.");
            }
            else
            {
                Console.WriteLine("Don't worry! Keep working hard for next time.");
            }

            // Stretch Challenge
            string sign = ""; // Initialize the sign variable

            int lastDigit = gradePercentage % 10;

            if (letter == "A" && lastDigit >= 7)
            {
                sign = "-";
            }
            else if (letter == "B" && lastDigit >= 7)
            {
                sign = "+";
            }
            else if (letter == "B" && lastDigit < 3)
            {
                sign = "-";
            }
            else if (letter == "C" && lastDigit >= 7)
            {
                sign = "+";
            }
            else if (letter == "C" && lastDigit < 3)
            {
                sign = "-";
            }
            else if (letter == "D" && lastDigit >= 7)
            {
                sign = "+";
            }
            else if (letter == "D" && lastDigit < 3)
            {
                sign = "-";
            }

            // Handling exceptional cases
            if (letter == "A" && lastDigit < 3)
            {
                letter = "A-";
                sign = "";
            }
            else if (letter == "F" && (lastDigit >= 3 || lastDigit <= 7))
            {
                letter = "F";
                sign = "";
            }

            // Displaying the final grade
            Console.WriteLine("Your grade is: " + letter + sign);
        }
    }
}
