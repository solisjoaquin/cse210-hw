/*

Week 04 Develop: Mindfulness Program


Solution Idea
Consider an app that provides three different kinds of mindfulness 
opportunities. It could give some guidance and structure to users in the following activities:

Breathing Activity - Help the user pace their breathing to have a session 
of deep breathing for a certain amount of time. They might find more peace 
and less stress through the exercise.
Reflection Activity - Guide the user to think deeply, by having them consider 
a certain experience when they were successful or demonstrated strength. 
Then, prompt them with questions to reflect more deeply about details of 
this experience. They might discover more depth than they previously realized.
Listing Activity - Guide the user to think broadly, by helping them list 
as many things as they can in a certain area of strength or positivity. 
They might discover more breadth than they previously realized.
The application could additional help the user keep track of the time or 
frequency they spend in these activities and give them gentle prompts and reminders.

The user interface of a program like this could be anything from a Website 
or Mobile App to one that runs on a Smart Watch and it could be done in many 
different kinds of colors, shapes, and styles. Learning to write a program 
to solve the real-world problem is the most critical part, so this assignment
 will focus on that, rather than creating a flashy interface.
Specification
Write a program that provides the three activities described above. It should 
help them work through these activities in stages using basic forms of delay 
(animation or countdown).

Functional requirements
Your program must do the following:

Have a menu system to allow the user to choose an activity.
Each activity should start with a common starting message that provides 
the name of the activity, a description, and asks for and sets the duration 
of the activity in seconds. Then, it should tell the user to prepare to begin and pause for several seconds.
Each activity should end with a common ending message that tells the user 
they have done a good job, and pause and then tell them the activity they 
have completed and the length of time and pauses for several seconds before finishing.
Whenever the application pauses it should show some kind of animation to 
the user, such as a spinner, a countdown timer, or periods being displayed to the screen.
The interface for the program should remain generally true to the one shown in the video demo.
Provide activities for reflection, breathing, and enumeration, as described below:
Breathing Activity
The activity should begin with the standard starting message and prompt 
for the duration that is used by all activities.
The description of this activity should be something like: "This activity 
will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing."
After the starting message, the user is shown a series of messages alternating between "Breathe in..." and "Breathe out..."
After each message, the program should pause for several seconds and show a countdown.
It should continue until it has reached the number of seconds the user specified for the duration.
The activity should conclude with the standard finishing message for all activities.
Reflection Activity
The activity should begin with the standard starting message and prompt for the 
duration that is used by all activities.
The description of this activity should be something like: "This activity will 
help you reflect on times in your life when you have shown strength and resilience. 
This will help you recognize the power you have and how you can use it in other aspects of your life."
After the starting message, select a random prompt to show the user such as:

Think of a time when you stood up for someone else.
Think of a time when you did something really difficult.
Think of a time when you helped someone in need.
Think of a time when you did something truly selfless.
After displaying the prompt, the program should ask the to reflect on questions 
that relate to this experience. These questions should be pulled from a list such as the following:

Why was this experience meaningful to you?
Have you ever done anything like this before?
How did you get started?
How did you feel when it was complete?
What made this time different than other times when you were not as successful?
What is your favorite thing about this experience?
What could you learn from this experience that applies to other situations?
What did you learn about yourself through this experience?
How can you keep this experience in mind in the future?
After each question the program should pause for several seconds before continuing 
to the next one. While the program is paused it should display a kind of spinner.
It should continue showing random questions until it has reached the number of 
seconds the user specified for the duration.
The activity should conclude with the standard finishing message for all activities.
Listing Activity
The activity should begin with the standard starting message and prompt for 
the duration that is used by all activities.
The description of this activity should be something like: "This activity 
will help you reflect on the good things in your life by having you list as many 
things as you can in a certain area."
After the starting message, select a random prompt to show the user such as:

Who are people that you appreciate?
What are personal strengths of yours?
Who are people that you have helped this week?
When have you felt the Holy Ghost this month?
Who are some of your personal heroes?
After displaying the prompt, the program should give them a countdown of several 
seconds to begin thinking about the prompt. Then, it should prompt them to keep listing items.
The user lists as many items as they can until they they reach the duration specified 
by the user at the beginning.
The activity them displays back the number of items that were entered.
The activity should conclude with the standard finishing message for all activities.
Design Requirements
In addition your program must:

Use inheritance by having a separate class for each kind of activity with a base class 
to s

Your program does not need to track any statistics such as how many times or how 
frequently the user has done an activity.
When getting random questions or prompts, you can just choose a random one from the list. 
You don't have to worry about if it was already chosen this session, or worry about running out of prompts.
Showing Creativity and Exceeding Requirements
Meeting the core requirements makes your program eligible to receive a 93%. 
To receive 100% on the assignment, you need to show creativity and exceed these requirements.


*/

using System;
using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            bool done = false;
            while (!done)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Mindfulness App!");
                Console.WriteLine("Please choose an activity:");
                Console.WriteLine("1. Breathing");
                Console.WriteLine("2. Reflection");
                Console.WriteLine("3. Listing");
                Console.WriteLine("4. Exit");
                string input = Console.ReadLine();
                if (input == "1")
                {
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.Start();
                }
                else if (input == "2")
                {
                    ReflectionActivity reflection = new ReflectionActivity();
                    reflection.Start();
                }
                else if (input == "3")
                {
                    ListingActivity listing = new ListingActivity();
                    listing.Start();
                }
                else if (input == "4")
                {
                    done = true;
                }
            }
        }
    }


public class Activity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Duration { get; set; }
    public Activity(string name, string description)
    {
        Name = name;
        Description = description;
    }
    public void Start()
    {
        Console.Clear();
        Console.WriteLine("Starting " + Name + " Activity");
        Console.WriteLine(Description);
        Console.WriteLine("How many seconds would you like to do this activity?");
        Duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Get ready to begin in...");
        for (int i = 3; i > 0; i--)
        {
            Console.WriteLine(i);
            System.Threading.Thread.Sleep(1000);
        }
        Console.WriteLine("Begin!");
    }
    public void End()
    {
        Console.WriteLine("Good job! You have completed the " + Name + " activity for " + Duration + " seconds.");
        Console.WriteLine("Press enter to continue.");
        Console.ReadLine();
    }
}

public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }
    public void Start()
    {
        base.Start();
        for (int i = 0; i < Duration; i++)
        {
            if (i % 2 == 0)
            {
                Console.WriteLine("Breathe in...");
            }
            else
            {
                Console.WriteLine("Breathe out...");
            }
            System.Threading.Thread.Sleep(1000);
        }
        base.End();
    }
}

public class ReflectionActivity : Activity
{
    public ReflectionActivity() : base("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
    }
    public void Start()
    {
        base.Start();
        Random random = new Random();
        List<string> prompts = new List<string>();
        prompts.Add("Think of a time when you stood up for someone else.");
        prompts.Add("Think of a time when you did something really difficult.");
        prompts.Add("Think of a time when you helped someone in need.");
        prompts.Add("Think of a time when you did something truly selfless.");
        string prompt = prompts[random.Next(prompts.Count)];
        Console.WriteLine(prompt);
        System.Threading.Thread.Sleep(1000);
        List<string> questions = new List<string>();
        questions.Add("Why was this experience meaningful to you?");
        questions.Add("Have you ever done anything like this before?");
        questions.Add("How did you get started?");
        questions.Add("How did you feel when it was complete?");
        questions.Add("What made this time different than other times when you were not as successful?");
        questions.Add("What is your favorite thing about this experience?");
        questions.Add("What could you learn from this experience that applies to other situations?");
        questions.Add("What did you learn about yourself through this experience?");
        questions.Add("How can you keep this experience in mind in the future?");
        for (int i = 0; i < Duration; i++)
        {
            string question = questions[random.Next(questions.Count)];
            Console.WriteLine(question);
            System.Threading.Thread.Sleep(1000);
        }
        base.End();
    }
}

public class ListingActivity : Activity
{
    public ListingActivity() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }
    public void Start()
    {
        base.Start();
        Random random = new Random();
        List<string> prompts = new List<string>();
        prompts.Add("Who are people that you appreciate?");
        prompts.Add("What are personal strengths of yours?");
        prompts.Add("Who are people that you have helped this week?");
        prompts.Add("When have you felt the Holy Ghost this month?");
        prompts.Add("Who are some of your personal heroes?");
        string prompt = prompts[random.Next(prompts.Count)];
        Console.WriteLine(prompt);
        System.Threading.Thread.Sleep(1000);
        Console.WriteLine("Begin listing...");
        System.Threading.Thread.Sleep(1000);
        List<string> items = new List<string>();
        for (int i = 0; i < Duration; i++)
        {
            Console.WriteLine("Enter an item:");
            string item = Console.ReadLine();
            items.Add(item);
        }
        Console.WriteLine("You entered " + items.Count + " items.");
        base.End();
    }
}

