/*

Week 04 Develop: Mindfulness Program

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public string Name
    {
        get { return _name; }
    }

    public string Description
    {
        get { return _description; }
    }

    public int Duration
    {
        get { return _duration; }
        set { _duration = value; }
    }

    public void Start()
    {
        Console.WriteLine("Starting " + _name + "...");
        System.Threading.Thread.Sleep(1000);
        Console.WriteLine("Preparing to begin...");
        System.Threading.Thread.Sleep(1000);
    }

    public void End()
    {
        Console.WriteLine("Good job!");
        System.Threading.Thread.Sleep(1000);
        Console.WriteLine("You have completed " + _name + " for " + _duration + " seconds.");
        System.Threading.Thread.Sleep(1000);
    }

    public void ShowSpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write("/");
            System.Threading.Thread.Sleep(100);
            Console.Write("\b");
            Console.Write("-");
            System.Threading.Thread.Sleep(100);
            Console.Write("\b");
            Console.Write("\\");
            System.Threading.Thread.Sleep(100);
            Console.Write("\b");
            Console.Write("|");
            System.Threading.Thread.Sleep(100);
            Console.Write("\b");
        }
    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            System.Threading.Thread.Sleep(1000);
            Console.Write("\b");
            Console.Write(" ");
            Console.Write("\b");
        }
    }
}

public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public void Run()
    {
        base.Start();
        Console.WriteLine("How many seconds would you like to do this activity?");
        Duration = int.Parse(Console.ReadLine());
        base.ShowCountDown(3);
        for (int i = 0; i < Duration; i++)
        {
            Console.WriteLine("Breathe in...");
            base.ShowCountDown(3);
            Console.WriteLine("Breathe out...");
            base.ShowCountDown(3);
        }
        base.End();
    }
}



public class ListingActivity: Activity
{
    private int _count;
    private List<string> _prompts;

    public ListingActivity() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _count = 0;
        _prompts = new List<string>();
        _prompts.Add("Who are people that you appreciate?");
        _prompts.Add("What are personal strengths of yours?");
        _prompts.Add("Who are people that you have helped this week?");
        _prompts.Add("When have you felt the Holy Ghost this month?");
        _prompts.Add("Who are some of your personal heroes?");
    }

    public void Run()
    {
        base.Start();
        Console.WriteLine("How many seconds would you like to do this activity?");
        Duration = int.Parse(Console.ReadLine());
        base.ShowCountDown(3);
        Console.WriteLine("Begin listing...");
        System.Threading.Thread.Sleep(1000);
        List<string> items = new List<string>();
        for (int i = 0; i < Duration; i++)
        {
            Console.WriteLine("Enter an item:");
            string item = Console.ReadLine();
            items.Add(item);
            _count++;
        }
        Console.WriteLine("You listed " + _count + " items.");
        base.End();
    }

    public string GetRandomPrompt()
    {
        Random random = new Random();
        string prompt = _prompts[random.Next(_prompts.Count)];
        return prompt;
    }
}

public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;

    public ReflectingActivity() : base("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        _prompts = new List<string>();
        _prompts.Add("Think of a time when you stood up for someone else.");
        _prompts.Add("Think of a time when you did something really difficult.");
        _prompts.Add("Think of a time when you helped someone in need.");
        _prompts.Add("Think of a time when you did something truly selfless.");
        _questions = new List<string>();
        _questions.Add("Why was this experience meaningful to you?");
        _questions.Add("Have you ever done anything like this before?");
        _questions.Add("How did you get started?");
        _questions.Add("How did you feel when it was complete?");
        _questions.Add("What made this time different than other times when you were not as successful?");
        _questions.Add("What is your favorite thing about this experience?");
        _questions.Add("What could you learn from this experience that applies to other situations?");
        _questions.Add("What did you learn about yourself through this experience?");
        _questions.Add("How can you keep this experience in mind in the future?");
    }

    public void Run()
    {
        base.Start();
        Console.WriteLine("How many seconds would you like to do this activity?");
        Duration = int.Parse(Console.ReadLine());
        base.ShowCountDown(3);
        Random random = new Random();
        string prompt = _prompts[random.Next(_prompts.Count)];
        Console.WriteLine(prompt);
        System.Threading.Thread.Sleep(1000);
        for (int i = 0; i < Duration; i++)
        {
            string question = _questions[random.Next(_questions.Count)];
            Console.WriteLine(question);
            System.Threading.Thread.Sleep(1000);
        }
        base.End();
    }

    public string GetRandomPrompt()
    {
        Random random = new Random();
        string prompt = _prompts[random.Next(_prompts.Count)];
        return prompt;
    }

    public string GetRandomQuestion()
    {
        Random random = new Random();
        string question = _questions[random.Next(_questions.Count)];
        return question;
    }
}

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Welcome to the Mindfulness Program!");
        Console.WriteLine("Please choose an activity:");
        Console.WriteLine("1. Breathing");
        Console.WriteLine("2. Reflection");
        Console.WriteLine("3. Listing");
        int choice = int.Parse(Console.ReadLine());
        if (choice == 1)
        {
            BreathingActivity breathingActivity = new BreathingActivity();
            breathingActivity.Run();
        }
        else if (choice == 2)
        {
            ReflectingActivity reflectingActivity = new ReflectingActivity();
            reflectingActivity.Run();
        }
        else if (choice == 3)
        {
            ListingActivity listingActivity = new ListingActivity();
            listingActivity.Run();
        }
    }
}

