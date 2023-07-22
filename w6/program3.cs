/*
Program 3: Inheritance with Event Planning

You have been hired by an event planning company. They help organize and market events throughout the world. 
They need you to write a program to track each of these events and produce the marketing material to distribute on social media. 
They typically handle a few main types of events:

* Lectures, which have a speaker and have a limited capacity.
* Receptions, which require people to RSVP, or register, beforehand.
* Outdoor gatherings, which do not have a limit on attendees, but need to track the weather forecast.

Regardless of the type, all events need to have an Event Title, Description, Date, Time, and Address.

They would like the ability to generate three different messages:

1- Standard details - Lists the title, description, date, time, and address.
2- Full details - Lists all of the above, plus type of event and information specific to that event type. 
For lectures, this includes the speaker name and capacity. For receptions this includes an email for RSVP. 
For outdoor gatherings, this includes a statement of the weather.
3- Short description - Lists the type of event, title, and the date.


Program Specification
Write a program that has a base Event class along with derived classes for each type of event. 
These classes should contain the necessary data and provide methods to return strings for each 
of the messages the company desires.

Remember that any data or methods that are common among all types of events should be in the base class.

Once you have the classes in place, write a program that creates at least one event of each
 type and sets all of their values. Then, for event event, call each of the methods to generate 
 the marketing messages and output their results to the screen.


*/

using System;
using System.Collections.Generic;

public class Address
{
    private string street;
    private string city;
    private string state;
    private string zip;

    public Address(string street, string city, string state, string zip)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.zip = zip;
    }

    public string Street
    {
        get { return street; }
        set { street = value; }
    }

    public string City
    {
        get { return city; }
        set { city = value; }
    }

    public string State
    {
        get { return state; }
        set { state = value; }
    }

    public string Zip
    {
        get { return zip; }
        set { zip = value; }
    }

    public string GetAddress()
    {
        return $"{street}\n{city}, {state} {zip}";
    }
}

public class Event
{
    private string title;
    private string description;
    private DateTime date;
    private DateTime time;
    private Address address;

    public Event(string title, string description, DateTime date, DateTime time, Address address)
    {
        this.title = title;
        this.description = description;
        this.date = date;
        this.time = time;
        this.address = address;
    }

    public string Title
    {
        get { return title; }
        set { title = value; }
    }

    public string Description
    {
        get { return description; }
        set { description = value; }
    }

    public DateTime Date
    {
        get { return date; }
        set { date = value; }
    }

    public DateTime Time
    {
        get { return time; }
        set { time = value; }
    }

    public Address Address
    {
        get { return address; }
        set { address = value; }
    }

    public string GetStandardDetails()
    {
        return $"Title: {title}\nDescription: {description}\nDate: {date.ToShortDateString()}\nTime: {time.ToShortTimeString()}\nAddress:\n{address.GetAddress()}";
    }

    public virtual string GetFullDetails()
    {
        return GetStandardDetails();
    }

    public virtual string GetShortDescription()
    {
        return $"Type: Event\nTitle: {title}\nDate: {date.ToShortDateString()}";
    }
}

public class Lecture : Event
{
    private string speaker;
    private int capacity;

    public Lecture(string title, string description, DateTime date, DateTime time, Address address, string speaker, int capacity) : base(title, description, date, time, address)
    {
        this.speaker = speaker;
        this.capacity = capacity;
    }

    public string Speaker
    {
        get { return speaker; }
        set { speaker = value; }
    }

    public int Capacity
    {
        get { return capacity; }
        set { capacity = value; }
    }

    public override string GetFullDetails()
    {
        return $"{base.GetFullDetails()}\nSpeaker: {speaker}\nCapacity: {capacity}";
    }

    public override string GetShortDescription()
    {
        return $"Type: Lecture\nTitle: {Title}\nDate: {Date.ToShortDateString()}";
    }
}

public class Reception : Event
{
    private string email;

    public Reception(string title, string description, DateTime date, DateTime time, Address address, string email) : base(title, description, date, time, address)
    {
        this.email = email;
    }

    public string Email
    {
        get { return email; }
        set { email = value; }
    }

    public override string GetFullDetails()
    {
        return $"{base.GetFullDetails()}\nEmail: {email}";
    }

    public override string GetShortDescription()
    {
        return $"Type: Reception\nTitle: {Title}\nDate: {Date.ToShortDateString()}";
    }
}

public class OutdoorGathering : Event
{
    private string weather;

    public OutdoorGathering(string title, string description, DateTime date, DateTime time, Address address, string weather) : base(title, description, date, time, address)
    {
        this.weather = weather;
    }

    public string Weather
    {
        get { return weather; }
        set { weather = value; }
    }

    public override string GetFullDetails()
    {
        return $"{base.GetFullDetails()}\nWeather: {weather}";
    }

    public override string GetShortDescription()
    {
        return $"Type: Outdoor Gathering\nTitle: {Title}\nDate: {Date.ToShortDateString()}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main St.", "Anytown", "NY", "12345");
        Address address2 = new Address("456 Main St.", "Anytown", "NY", "12345");
        Address address3 = new Address("789 Main St.", "Anytown", "NY", "12345");

        // format of DateTime is year, month, day, hour, minute, second
        Lecture lecture1 = new Lecture("Lecture 1", "Lecture 1 Description", new DateTime(2021, 1, 1), new DateTime(2021, 1, 1, 12, 0, 0), address2, "Speaker 1", 100);
        Reception reception1 = new Reception("Reception 1", "Reception 1 Description", new DateTime(2021, 1, 1), new DateTime(2021, 1, 1, 12, 0, 0), address3, "");
        OutdoorGathering outdoorGathering1 = new OutdoorGathering("Outdoor Gathering 1", "Outdoor Gathering 1 Description", new DateTime(2021, 1, 1), new DateTime(2021, 1, 1, 12, 0, 0), address1, "Sunny");

        List<Event> events = new List<Event>();
        events.Add(lecture1);
        events.Add(reception1);
        events.Add(outdoorGathering1);

        foreach (Event e in events)
        {
            Console.WriteLine(e.GetFullDetails());
            Console.WriteLine("");
        }
    }  
}