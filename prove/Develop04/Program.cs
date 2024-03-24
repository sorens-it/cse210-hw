using System;
using System.Collections.Generic;
using System.Threading;

// Base class for all mindfulness activities
abstract class MindfulnessActivity
{
    protected int durationInSeconds;

    public MindfulnessActivity(int duration)
    {
        this.durationInSeconds = duration;
    }

    public abstract void Start();

    protected void Pause(int seconds)
    {
        Console.WriteLine("Pausing...");
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i} ");
            Thread.Sleep(1000); // Pause for 1 second
        }
        Console.WriteLine();
    }
}

// Activity for deep breathing
class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity(int duration) : base(duration) { }

    public override void Start()
    {
        Console.WriteLine("Breathing Activity");
        Console.WriteLine("This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.");
        Console.WriteLine($"Duration: {durationInSeconds} seconds");

        Console.WriteLine("Prepare to begin...");
        Pause(3);

        for (int i = 0; i < durationInSeconds; i += 2)
        {
            Console.WriteLine("Breathe in...");
            Pause(1);
            Console.WriteLine("Breathe out...");
            Pause(1);
        }

        Console.WriteLine("Well done! You have completed the Breathing Activity.");
        Console.WriteLine($"Duration: {durationInSeconds} seconds");
        Pause(3);
    }
}

// Activity for reflection
class ReflectionActivity : MindfulnessActivity
{
    private List<string> prompts = new List<string>()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> questions = new List<string>()
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity(int duration) : base(duration) { }

    public override void Start()
    {
        Console.WriteLine("Reflection Activity");
        Console.WriteLine("This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
        Console.WriteLine($"Duration: {durationInSeconds} seconds");

        Console.WriteLine("Prepare to begin...");
        Pause(3);

        Random rand = new Random();
        string prompt = prompts[rand.Next(prompts.Count)];
        Console.WriteLine(prompt);

        foreach (string question in questions)
        {
            Console.WriteLine(question);
            Pause(3);
        }

        Console.WriteLine("Well done! You have completed the Reflection Activity.");
        Console.WriteLine($"Duration: {durationInSeconds} seconds");
        Pause(3);
    }
}

// Activity for listing
class ListingActivity : MindfulnessActivity
{
    private List<string> listingPrompts = new List<string>()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity(int duration) : base(duration) { }

    public override void Start()
    {
        Console.WriteLine("Listing Activity");
        Console.WriteLine("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
        Console.WriteLine($"Duration: {durationInSeconds} seconds");

        Console.WriteLine("Prepare to begin...");
        Pause(3);

        Random rand = new Random();
        string prompt = listingPrompts[rand.Next(listingPrompts.Count)];
        Console.WriteLine(prompt);

        Console.WriteLine("Start listing...");
        Pause(durationInSeconds);

        Console.WriteLine($"You listed {durationInSeconds / 2} items.");
        Console.WriteLine("Well done! You have completed the Listing Activity.");
        Console.WriteLine($"Duration: {durationInSeconds} seconds");
        Pause(3);
    }
}

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Mindfulness Activity Menu:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");

            Console.Write("Select an activity: ");
            string choice = Console.ReadLine();

            if (choice == "4")
                break;

            int duration = 0;
            Console.Write("Enter duration (in seconds): ");
            int.TryParse(Console.ReadLine(), out duration);

            MindfulnessActivity activity = null;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity(duration);
                    break;
                case "2":
                    activity = new ReflectionActivity(duration);
                    break;
                case "3":
                    activity = new ListingActivity(duration);
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    continue;
            }

            if (activity != null)
                activity.Start();
        }
    }
}
