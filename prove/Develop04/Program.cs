using System;
using System.Collections.Generic;
using System.Threading;

public class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Menu Optoion:");
            Console.WriteLine("1. Start breathing Activity");
            Console.WriteLine("2. Start reflection Activity");
            Console.WriteLine("3. Start listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Enter your choice: ");
            
            if (int.TryParse(Console.ReadLine(), out int choice)) 

            switch (choice)
            {
                case 1:
                    StartBreathingActivity();
                    break;
                case 2:
                    ReflectionActivity.RunActivity();
                    break;
                case 3:
                    ListingActivity.RunActivity();
                    break;
                case 4:
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
    
    static void ShowAnimation(int seconds)
    {
        List<string> animationStrings = new List<string>();
        animationStrings.Add("|");
        animationStrings.Add("/");
        animationStrings.Add("_");
        animationStrings.Add("\\");
        animationStrings.Add("|");
        animationStrings.Add("/");
        animationStrings.Add("_");
        animationStrings.Add("\\");
        foreach (string s in animationStrings)
        {

            Console.Write(s);
            Thread.Sleep(1000);
            Console.Write("\b \b");
                    
        }
        Console.WriteLine();
    }

    static void StartBreathingActivity()
    {
        Console.Clear();
        Console.WriteLine("\nWelcome to Breathing Activity.\n");
        Console.WriteLine("This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.");
        Console.Write("Enter duration in seconds: ");
        int duration = int.Parse(Console.ReadLine());

        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowAnimation(3); // Pause for seconds before starting
        Console.Clear();

        // Perform breath activity
        Console.WriteLine("Breathe in...");
        ShowAnimation(3);
        Console.WriteLine("Breathe out...");
        ShowAnimation(3);
        duration -= 4;  
    
        }
    }

    public static class ReflectionActivity
    {
        private static readonly List<string> prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        private static readonly List<string> questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            // Add more questions as needed
        };

        public static void RunActivity()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Reflection Activity");
            Console.WriteLine("This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
            Console.Write("Enter duration in seconds: ");
            int duration = Convert.ToInt32(Console.ReadLine());

           
            Random random = new Random();

            while (duration > 0)
            {
                string prompt = prompts[random.Next(prompts.Count)];
                Console.WriteLine($"Prompt: {prompt}");
                

                foreach (var question in questions)
                {
                    Console.WriteLine(question);
                    
                }

                duration -= 8;
            }

        }
    }

    public static class ListingActivity
    {
        private static readonly List<string> prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        public static void RunActivity()
        {
            Console.WriteLine("Welcome to Listing Activity.");
            Console.WriteLine("This is listing activity will help you to listen very attentivly ");
            Console.Write("Enter duration of listing activity in seconds: ");
            int duration = int.Parse(Console.ReadLine());

           

            Random random = new Random();

            string prompt = prompts[random.Next(prompts.Count)];
            Console.WriteLine($"Prompt: {prompt}");

            Console.WriteLine("Start listing items...");

            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(duration);

            int itemCount = 0;
            while (DateTime.Now < endTime)
            {
                // Simulate user listing items (in real application, read user input)
                // For simulation purposes, we'll just count the number of items entered.
                itemCount++;
            }

            Console.WriteLine($"Number of items entered: {itemCount}");

        }
    }
