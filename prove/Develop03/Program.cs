/*
Week 03 Develop: Scripture Memorizer

*/

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Scripture scripture = new Scripture("John", 3, 16, "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.");
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
                scripture.HideRandomWords();
            }
        }
    }
}


public class Scripture

{
    private Reference reference;
    private string text;
    private List<Word> words;

    public Scripture(string book, int chapter, int verse, string text)
    {
        reference = new Reference(book, chapter, verse);
        words = new List<Word>();
        string[] wordArray = text.Split(' ');
        foreach (string word in wordArray)
        {
            words.Add(new Word(word));
        }
    }

    public Scripture(string book, int chapter, int verseStart, int verseEnd, string text)
    {
        reference = new Reference(book, chapter, verseStart, verseEnd);
        words = new List<Word>();
        string[] wordArray = text.Split(' ');
        foreach (string word in wordArray)
        {
            words.Add(new Word(word));
        }
    }

    public void Display()
    {
        reference.GetDisplayText();
        foreach (Word word in words)
        {
            word.Show();
        }
    }

    public void HideRandomWords()
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
    private bool isHidden;

    public Word(string text)
    {
        this.text = text;
        isHidden = false;
    }

    public void Hide()
    {
        isHidden = true;
    }
    public void Show()
    {
        if (isHidden)
        {
            Console.Write("____ ");
        }
        else
        {
            Console.Write(text + " ");
        }
    }

    
}

public class Reference
{
    private string book;
    private int chapter;
    private int verse;
    private int endVerse;

    public Reference(string book, int chapter, int verse)
    {
        this.book = book;
        this.chapter = chapter;
        this.verse = verse;
    }

    public Reference(string book, int chapter, int verseStart, int verseEnd)
    {
        this.book = book;
        this.chapter = chapter;
        this.verse = verseStart;
        this.endVerse = verseEnd;
    }

    public void GetDisplayText()
    {
        Console.WriteLine(book + " " + chapter + ":" + verse);
    }
}

