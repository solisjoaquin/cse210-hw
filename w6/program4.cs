/*
Program 4: Polymorphism with Exercise Tracking

*/

using System;
using System.Collections.Generic;

public class Activity
{
    private string name;
    private DateTime date;
    private int minutes;

    public Activity(string name, DateTime date, int minutes)
    {
        this.name = name;
        this.date = date;
        this.minutes = minutes;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public DateTime Date
    {
        get { return date; }
        set { date = value; }
    }

    public int Minutes
    {
        get { return minutes; }
        set { minutes = value; }
    }

    public virtual double GetDistance()
    {
        return 0;
    }

    public virtual double GetSpeed()
    {
        return 0;
    }

    public virtual double GetPace()
    {
        return 0;
    }

    public virtual string GetSummary()
    {
        return $"{date.ToString("dd MMM yyyy")} {name} ({minutes} min)";
    }
}

public class Running : Activity
{
    private double distance;

    public Running(string name, DateTime date, int minutes, double distance) : base(name, date, minutes)
    {
        this.distance = distance;
    }

    public double Distance
    {
        get { return distance; }
        set { distance = value; }
    }

    public override double GetDistance()
    {
        return distance;
    }

    public override double GetSpeed()
    {
        return distance / Minutes * 60;
    }

    public override double GetPace()
    {
        return Minutes / distance;
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()}: Distance {distance} miles, Speed {GetSpeed()} mph, Pace: {GetPace()} min per mile";
    }
}

public class Cycling : Activity
{
    private double speed;

    public Cycling(string name, DateTime date, int minutes, double speed) : base(name, date, minutes)
    {
        this.speed = speed;
    }

    public double Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    public override double GetDistance()
    {
        return speed / 60 * Minutes;
    }

    public override double GetSpeed()
    {
        return speed;
    }

    public override double GetPace()
    {
        return 60 / speed;
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()}: Distance {GetDistance()} miles, Speed {speed} mph, Pace: {GetPace()} min per mile";
    }
}

public class Swimming : Activity
{
    private int laps;

    public Swimming(string name, DateTime date, int minutes, int laps) : base(name, date, minutes)
    {
        this.laps = laps;
    }

    public int Laps
    {
        get { return laps; }
        set { laps = value; }
    }

    public override double GetDistance()
    {   
        // I chose to use miles
        return laps * 50 / 1000 * 0.62;
    }

    public override double GetSpeed()
    {
        return GetDistance() / Minutes * 60;
    }

    public override double GetPace()
    {
        return Minutes / GetDistance();
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()}: Distance {GetDistance()} miles, Speed {GetSpeed()} mph, Pace: {GetPace()} min per mile";
    }
}

public class Program
{
    public static void Main()
    {
        List<Activity> activities = new List<Activity>();

        activities.Add(new Running("Running", new DateTime(2022, 11, 3), 30, 3.0));
        activities.Add(new Cycling("Cycling", new DateTime(2022, 11, 3), 30, 6.0));
        activities.Add(new Swimming("Swimming", new DateTime(2022, 11, 3), 30, 3));

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}

