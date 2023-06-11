using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1, 11);

        Console.Write("What is your guess? ");
        int response = int.Parse(Console.ReadLine());

        do
        {
            if (response < number)
            {
                Console.WriteLine("Higher");
            }
            else if (response > number)
            {
                Console.WriteLine("Lower");
            }

            Console.Write("What is your guess? ");
            response = int.Parse(Console.ReadLine());

        } while (response != number);

        Console.WriteLine("You guessed it!");
    }
}