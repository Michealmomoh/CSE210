using System;
using System.Collections.Generic;
using System.Threading;

// Base class for all mindfulness activities
abstract class MindfulnessActivity
{
    protected string Name;
    protected string Description;
    
    public void StartActivity()
    {
        Console.Clear();
        Console.WriteLine($"Starting {Name}");
        Console.WriteLine(Description);
        Console.Write("Enter duration (in seconds): ");
        int duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3);
        RunActivity(duration);
        Console.WriteLine($"Good job! You completed {Name} for {duration} seconds.");
        ShowSpinner(3);
    }

    protected abstract void RunActivity(int duration);
    
    protected void ShowSpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(". ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}

// Breathing Activity
class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity()
    {
        Name = "Breathing Activity";
        Description = "This activity will help you relax by guiding your breathing in and out slowly.";
    }

    protected override void RunActivity(int duration)
    {
        for (int i = 0; i < duration; i += 4)
        {
            Console.WriteLine("Breathe in...");
            ShowSpinner(2);
            Console.WriteLine("Breathe out...");
            ShowSpinner(2);
        }
    }
}

// Reflection Activity
class ReflectionActivity : MindfulnessActivity
{
    private List<string> prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };
    
    public ReflectionActivity()
    {
        Name = "Reflection Activity";
        Description = "This activity will help you reflect on times in your life when you have shown strength and resilience.";
    }
    
    protected override void RunActivity(int duration)
    {
        Random rand = new Random();
        string prompt = prompts[rand.Next(prompts.Count)];
        Console.WriteLine(prompt);
        ShowSpinner(5);
        
        List<string> questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "How did you feel when it was complete?",
            "What did you learn from this experience?"
        };
        
        foreach (var question in questions)
        {
            if (duration <= 0) break;
            Console.WriteLine(question);
            ShowSpinner(5);
            duration -= 5;
        }
    }
}

// Listing Activity
class ListingActivity : MindfulnessActivity
{
    private List<string> prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?"
    };
    
    public ListingActivity()
    {
        Name = "Listing Activity";
        Description = "This activity will help you reflect on the good things in your life by listing them.";
    }
    
    protected override void RunActivity(int duration)
    {
        Random rand = new Random();
        string prompt = prompts[rand.Next(prompts.Count)];
        Console.WriteLine(prompt);
        ShowSpinner(3);
        
        Console.WriteLine("Start listing items:");
        List<string> items = new List<string>();
        var startTime = DateTime.Now;
        while ((DateTime.Now - startTime).TotalSeconds < duration)
        {
            Console.Write("- ");
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
                items.Add(input);
        }
        
        Console.WriteLine($"You listed {items.Count} items!");
    }
}

// Main Program
class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            Console.Write("Select an option: ");
            
            string choice = Console.ReadLine();
            MindfulnessActivity activity = null;
            
            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectionActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    Thread.Sleep(2000);
                    continue;
            }
            
            activity.StartActivity();
        }
    }
}
