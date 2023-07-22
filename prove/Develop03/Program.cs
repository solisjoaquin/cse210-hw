/*
Week 03 Develop: Scripture Memorizer

one for the scripture itself, 
one for the reference (for example "John 3:16"), 
and to represent a word in the scripture.
Provide multiple constructors for the scripture reference to handle 
the case of a single verse and a verse range ("Proverbs 3:5" or "Proverbs 3:5-6").

*/

using System;
using System.Collections.Generic;


    class Program
    {
        static void Main(string[] args)
        {
            Scripture scripture = new Scripture("John 3:16", "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.");
            bool done = false;
            while (!done)
            {
                Console.Clear();
                scripture.Display();
                Console.WriteLine("");
                Console.WriteLine("Press enter to hide more words or type quit to exit.");
                string input = Console.ReadLine();
                if (input.ToLower() == "quit")
                {
                    done = true;
                }
                else
                {
                    scripture.HideWords();
                }
            }
        }
    }

public class Scripture
{
    private string reference;
    private string text;
    private List<Word> words;

    public Scripture(string reference, string text)
    {
        this.reference = reference;
        this.text = text;
        words = new List<Word>();
        string[] wordArray = text.Split(' ');
        foreach (string word in wordArray)
        {
            words.Add(new Word(word));
        }
    }

    public void Display()
    {
        Console.WriteLine(reference);
        foreach (Word word in words)
        {
            word.Display();
        }
    }

    public void HideWords()
    {
        Random random = new Random();
        int wordCount = words.Count;
        int wordsToHide = random.Next(1, wordCount);
        for (int i = 0; i < wordsToHide; i++)
        {
            int wordIndex = random.Next(0, wordCount);
            words[wordIndex].Hide();
        }
    }
}

public class Word
{
    private string text;
    private bool hidden;

    public Word(string text)
    {
        this.text = text;
        hidden = false;
    }

    public void Display()
    {
        if (hidden)
        {
            Console.Write("____ ");
        }
        else
        {
            Console.Write(text + " ");
        }
    }

    public void Hide()
    {
        hidden = true;
    }
}


