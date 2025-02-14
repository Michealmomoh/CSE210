using System;
using System.Collections.Generic;
using System.IO;

// Base class
abstract class Goal
{
    public string Name { get; protected set; }
    public string Description { get; protected set; }
    public int Points { get; protected set; }
    public bool IsCompleted { get; protected set; }

    public Goal(string name, string description, int points)
    {
        Name = name;
        Description = description;
        Points = points;
        IsCompleted = false;
    }

    public abstract void RecordEvent();
    public abstract string DisplayStatus();
}

class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override void RecordEvent()
    {
        if (!IsCompleted)
        {
            IsCompleted = true;
            Console.WriteLine($"Goal completed! You earned {Points} points.");
        }
        else
        {
            Console.WriteLine("This goal is already completed.");
        }
    }

    public override string DisplayStatus()
    {
        return IsCompleted ? "[X] " + Name : "[ ] " + Name;
    }
}

class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override void RecordEvent()
    {
        Console.WriteLine($"Recorded progress! You earned {Points} points.");
    }

    public override string DisplayStatus()
    {
        return "[∞] " + Name;
    }
}
class ChecklistGoal : Goal
{
    private int targetCount;
    private int currentCount;
    private int bonusPoints;

    public ChecklistGoal(string name, string description, int points, int target, int bonus)
        : base(name, description, points)
    {
        targetCount = target;
        currentCount = 0;
        bonusPoints = bonus;
    }

    public override void RecordEvent()
    {
        if (currentCount < targetCount)
        {
            currentCount++;
            Console.WriteLine($"Progress made! {Points} points earned.");
            if (currentCount == targetCount)
            {
                IsCompleted = true;
                Console.WriteLine($"Goal completed! Bonus {bonusPoints} points earned!");
            }
        }
        else
        {
            Console.WriteLine("This goal is already completed.");
        }
    }

    public override string DisplayStatus()
    {
        return (IsCompleted ? "[X] " : "[ ] ") + $"{Name} (Completed {currentCount}/{targetCount})";
    }
}


class EternalQuestProgram
{
    private static List<Goal> goals = new List<Goal>();
    private static int userScore = 0;

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nEternal Quest Menu:");
            Console.WriteLine("1. Add a goal");
            Console.WriteLine("2. Record an event");
            Console.WriteLine("3. Display goals");
            Console.WriteLine("4. View score");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1": AddGoal(); break;
                case "2": RecordEvent(); break;
                case "3": DisplayGoals(); break;
                case "4": Console.WriteLine($"Your score: {userScore}"); break;
                case "5": return;
                default: Console.WriteLine("Invalid choice, try again."); break;
            }
        }
    }

    private static void AddGoal()
    {
        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter goal description: ");
        string description = Console.ReadLine();
        Console.Write("Enter points per completion: ");
        int points = int.Parse(Console.ReadLine());

        Console.WriteLine("Select goal type: 1) Simple 2) Eternal 3) Checklist");
        string type = Console.ReadLine();

        if (type == "1")
        {
            goals.Add(new SimpleGoal(name, description, points));
        }
        else if (type == "2")
        {
            goals.Add(new EternalGoal(name, description, points));
        }
        else if (type == "3")
        {
            Console.Write("Enter target count: ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("Enter bonus points: ");
            int bonus = int.Parse(Console.ReadLine());
            goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
    }

    private static void RecordEvent()
    {
        DisplayGoals();
        Console.Write("Select a goal number: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < goals.Count)
        {
            goals[index].RecordEvent();
            userScore += goals[index].Points;
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }
    }

    private static void DisplayGoals()
    {
        Console.WriteLine("\nYour Goals:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].DisplayStatus()}");
        }
    }
}
