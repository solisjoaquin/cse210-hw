/*
Week 02 Develop: Journal Program
*/

using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        bool done = false;
        while (!done)
        {
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");
            Console.Write("Enter a number: ");
            string input = Console.ReadLine();
            Console.WriteLine();
            switch (input)
            {
                case "1":
                    journal.AddEntry();
                    break;
                case "2":
                    journal.DisplayAll();
                    break;
                case "3":
                    journal.SaveToFile();
                    break;
                case "4":
                    journal.LoadFromFile();
                    break;
                case "5":
                    done = true;
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
            Console.WriteLine();
        }
    }
}

class Journal
{
    private List<Entry> entries = new List<Entry>();

    public void AddEntry()
    {
        Entry entry = new Entry();
        PromptGenerator prompt = new PromptGenerator();
        entry.Prompt = prompt.GetRandomPrompt();
        Console.WriteLine(entry.Prompt);
        Console.Write("Enter your response: ");
        entry.Response = Console.ReadLine();
        entry.Date = DateTime.Now.ToString("MM/dd/yyyy");
        entries.Add(entry);
    }

    public void DisplayAll()
    {
        foreach (Entry entry in entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile()
    {
        Console.Write("Enter a filename: ");
        string filename = Console.ReadLine();
        StreamWriter writer = new StreamWriter(filename);
        foreach (Entry entry in entries)
        {
            writer.WriteLine(entry);
        }
        writer.Close();
    }

    public void LoadFromFile()
    {
        Console.Write("Enter a filename: ");
        string filename = Console.ReadLine();
        StreamReader reader = new StreamReader(filename);
        entries.Clear();
        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine();
            string[] parts = line.Split('|');
            Entry entry = new Entry();
            entry.Prompt = parts[0];
            entry.Response = parts[1];
            entry.Date = parts[2];
            entries.Add(entry);
        }
        reader.Close();
    }
}

class Entry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }

    public void Display()
    {
        Console.WriteLine($"{Prompt} {Response} {Date}");
    }
}

class PromptGenerator
{
    private string[] prompts = new string[]
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };
    private Random random = new Random();

    public string GetRandomPrompt()
    {
        int index = random.Next(prompts.Length);
        return prompts[index];
    }
}




