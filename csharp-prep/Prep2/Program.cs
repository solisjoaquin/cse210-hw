using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is Grade pertentage? ");
        int percent = int.Parse(Console.ReadLine());

        if (percent > 90)
        {
            Console.WriteLine("Your grade is: A");
        }
        else if (percent >= 80)
        {
            Console.WriteLine("Your grade is: B");
        }
        else if (percent >= 70)
        {
            Console.WriteLine("Your grade is: C");
        }
        else if (percent >= 60)
        {
            Console.WriteLine("Your grade is: D");
        }
        else
        {   
            Console.WriteLine("Your grade is: F");
        }

    }
}