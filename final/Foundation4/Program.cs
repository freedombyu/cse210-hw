using System;
using System.ComponentModel.DataAnnotations;

class Activity
{
    private DateTime date;
    private int lengthInMinutes;

    public Activity(DateTime date, int lengthInMinutes)
    {
        this.date = date;
        this.lengthInMinutes = lengthInMinutes;
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

    public string GetSummary()
    {
        double distance = GetDistance();
        double speed = GetSpeed();
        double pace = GetPace();

        string unit = "km";
        if (this is Running)
        {
            unit = "miles";
        }

        return $"{date.ToString("dd MMM yyyy")} {GetType().Name} ({lengthInMinutes} min) - Distance: {distance} {unit}, Speed: {speed} mph, Pace: {pace} min per {unit}";
    }
}

class Running : Activity
{
    private double distance;

    public Running(DateTime date, int lengthInMinutes, double distance) : base(date, lengthInMinutes)
    {
        this.distance = distance;
    }

    public override double GetDistance()
    {
        return distance;
    }

    public override double GetPace()
    {
        return 60 / GetSpeed();
    }
}

class Cycling : Activity
{
    private double speed;

    public static int lengthInMinutes { get; private set; }

    public Cycling(DateTime date, int lengthInMinutes, double speed) : base(date, lengthInMinutes)
    {
        this.speed = speed;
    }

    public override double GetSpeed()
    {
        return speed;
    }

    public override double GetDistance()
    {
        return speed * lengthInMinutes / 60;
    }

    public override double GetPace()
    {
        return 60 / speed;
    }
}

class Swimming : Activity
{
    private int laps;

    public Swimming(DateTime date, int lengthInMinutes, int laps) : base(date, lengthInMinutes)
    {
        this.laps = laps;
    }

    public override double GetDistance()
    {
        return laps * 50.0 / 1000.0 * 0.62;
    }
    public override double GetPace()
    {
        return 60 / GetSpeed();
    }
}

class Program
{
    static void Main()
    {
        var activities = new Activity[]
        {
            new Running(new DateTime(2022, 11, 3), 30, 3.0),
            new Cycling(new DateTime(2022, 11, 3), 30, 20),
            new Swimming(new DateTime(2022, 11, 3), 30, 10)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
