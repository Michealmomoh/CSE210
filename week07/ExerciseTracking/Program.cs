using System;
using System.Collections.Generic;

public abstract class Activity
{
    public DateTime Date { get; set; }
    public int DurationInMinutes { get; set; }

    // Abstract methods that must be overridden in derived classes
    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    // Method to generate a summary that uses the other methods
    public string GetSummary()
    {
        return $"{Date:dd MMM yyyy} {this.GetType().Name} ({DurationInMinutes} min): " +
               $"Distance {GetDistance()} miles, Speed {GetSpeed()} mph, Pace: {GetPace()} min per mile";
    }
}

public class Running : Activity
{
    public double Distance { get; set; }

    public override double GetDistance()
    {
        return Distance;
    }

    public override double GetSpeed()
    {
        // Speed = Distance / Time * 60
        return (Distance / DurationInMinutes) * 60;
    }

    public override double GetPace()
    {
        // Pace = Time / Distance
        return DurationInMinutes / Distance;
    }
}

public class Cycling : Activity
{
    public double Speed { get; set; }

    public override double GetDistance()
    {
        // Distance = Speed * Time / 60
        return (Speed * DurationInMinutes) / 60;
    }

    public override double GetSpeed()
    {
        return Speed;
    }

    public override double GetPace()
    {
        // Pace = 60 / Speed
        return 60 / Speed;
    }
}

public class Swimming : Activity
{
    public int Laps { get; set; }

    public override double GetDistance()
    {
        // Distance in miles = Laps * 50 meters / 1000 * 0.62
        return (Laps * 50 / 1000.0) * 0.62;
    }

    public override double GetSpeed()
    {
        // Speed = Distance / Time * 60
        return (GetDistance() / DurationInMinutes) * 60;
    }

    public override double GetPace()
    {
        // Pace = Time / Distance
        return DurationInMinutes / GetDistance();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Creating activity objects
        var running = new Running { Date = new DateTime(2022, 11, 3), DurationInMinutes = 30, Distance = 3.0 };
        var cycling = new Cycling { Date = new DateTime(2022, 11, 3), DurationInMinutes = 30, Speed = 12.0 };
        var swimming = new Swimming { Date = new DateTime(2022, 11, 3), DurationInMinutes = 30, Laps = 20 };

        // Creating a list to hold the activities
        List<Activity> activities = new List<Activity> { running, cycling, swimming };

        // Display summaries for each activity
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
