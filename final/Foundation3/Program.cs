using System;

class Address
{
    private string street;
    private string city;
    private string state;
    private string postalCode;

    public Address(string street, string city, string state, string postalCode)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.postalCode = postalCode;
    }

    public override string ToString()
    {
        return $"{street}, {city}, {state} {postalCode}";
    }
}

class Event
{
    private string title;
    private string description;
    private DateTime date;
    private TimeSpan time;
    private Address address;

    public Event(string title, string description, DateTime date, TimeSpan time, Address address)
    {
        this.title = title;
        this.description = description;
        this.date = date;
        this.time = time;
        this.address = address;
    }

    public string GetStandardDetails()
    {
        return $"Title: {title}\nDescription: {description}\nDate: {date.ToShortDateString()}\nTime: {time}\nAddress: {address}";
    }

    public virtual string GetFullDetails()
    {
        return GetStandardDetails();
    }

    public string GetShortDescription()
    {
        return $"{GetType().Name}: {title}, Date: {date.ToShortDateString()}";
    }
}

class Lecture : Event
{
    private string speaker;
    private int capacity;

    public Lecture(string title, string description, DateTime date, TimeSpan time, Address address, string speaker, int capacity)
        : base(title, description, date, time, address)
    {
        this.speaker = speaker;
        this.capacity = capacity;
    }

    public override string GetFullDetails()
    {
        return $"{base.GetFullDetails()}\nSpeaker: {speaker}\nCapacity: {capacity} attendees";
    }
}

class Reception : Event
{
    private string rsvpEmail;

    public Reception(string title, string description, DateTime date, TimeSpan time, Address address, string rsvpEmail)
        : base(title, description, date, time, address)
    {
        this.rsvpEmail = rsvpEmail;
    }

    public override string GetFullDetails()
    {
        return $"{base.GetFullDetails()}\nRSVP Email: {rsvpEmail}";
    }
}

class OutdoorGathering : Event
{
    private string weatherForecast;

    public OutdoorGathering(string title, string description, DateTime date, TimeSpan time, Address address, string weatherForecast)
        : base(title, description, date, time, address)
    {
        this.weatherForecast = weatherForecast;
    }

    public override string GetFullDetails()
    {
        return $"{base.GetFullDetails()}\nWeather Forecast: {weatherForecast}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Address eventAddress = new Address("123 Main St", "Cityville", "State", "12345");

        Lecture lecture = new Lecture("Tech Talk", "Exciting tech discussion", new DateTime(2023, 10, 25), new TimeSpan(15, 30, 0), eventAddress, "John Doe", 50);
        Reception reception = new Reception("Networking Mixer", "Networking event with professionals", new DateTime(2023, 11, 5), new TimeSpan(18, 0, 0), eventAddress, "rsvp@example.com");
        OutdoorGathering gathering = new OutdoorGathering("Community Picnic", "Fun outdoor activities and food", new DateTime(2023, 11, 15), new TimeSpan(12, 0, 0), eventAddress, "Sunny and pleasant");

        Console.WriteLine("Standard Details:");
        Console.WriteLine(lecture.GetStandardDetails());
        Console.WriteLine("\nFull Details:");
        Console.WriteLine(lecture.GetFullDetails());
        Console.WriteLine("\nShort Description:");
        Console.WriteLine(lecture.GetShortDescription());

        Console.WriteLine("\n----------------------------------------\n");

        Console.WriteLine("Standard Details:");
        Console.WriteLine(reception.GetStandardDetails());
        Console.WriteLine("\nFull Details:");
        Console.WriteLine(reception.GetFullDetails());
        Console.WriteLine("\nShort Description:");
        Console.WriteLine(reception.GetShortDescription());

        Console.WriteLine("\n----------------------------------------\n");

        Console.WriteLine("Standard Details:");
        Console.WriteLine(gathering.GetStandardDetails());
        Console.WriteLine("\nFull Details:");
        Console.WriteLine(gathering.GetFullDetails());
        Console.WriteLine("\nShort Description:");
        Console.WriteLine(gathering.GetShortDescription());
    }
}
