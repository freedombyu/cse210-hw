using System;

class Program
{
    static void Main(string[] args)
    {
        // For the program will continue asking
        // for the guess number and give the attempts number


        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 11);

        int guess;
        int attempts = 0;

        do
        {                 
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            if (magicNumber > guess)
            {
                Console.WriteLine("Higher");
            }
            else if (magicNumber < guess)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }

            attempts++;

        } while (guess != magicNumber);

        Console.WriteLine($"It took you {attempts} attempts to guess the magic number.");
    }
}



