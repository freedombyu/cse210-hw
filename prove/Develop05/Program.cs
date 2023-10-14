using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Goal
{
    public string Name { get; set; }
    public int Value { get; set; }
    public int TimesCompleted { get; set; }
    public int RequiredTimes { get; set; }
    public bool IsEternal { get; set; }
    public bool IsCompleted { get; set; }
}

class User
{
    public string Name { get; set; }
    public int Score { get; set; }
    public List<Goal> Goals { get; set; } = new List<Goal>();
}

class Program
{
    static List<User> users = new List<User>();
    static User currentUser;

    static void Main(string[] args)
    {
        LoadUsers();
        Console.WriteLine("Welcome to the Goal Tracking Program!");

        while (true)
        {
            Console.WriteLine("\n1. Create a User");
            Console.WriteLine("2. Load a User");
            Console.WriteLine("3. Exit");
            int choice = GetUserInput(3);

            switch (choice)
            {
                case 1:
                    CreateUser();
                    break;
                case 2:
                    LoadUser();
                    break;
                case 3:
                    SaveUsers();
                    Environment.Exit(0);
                    break;
            }
        }
    }

    static void CreateUser()
    {
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();
        currentUser = new User { Name = name };
        users.Add(currentUser);

        Console.WriteLine($"Welcome, {name}! You can now manage your goals.");
        ManageGoals();
    }

    static void LoadUser()
    {
        Console.WriteLine("Select a user to load:");
        for (int i = 0; i < users.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {users[i].Name}");
        }

        int choice = GetUserInput(users.Count);
        currentUser = users[choice - 1];
        Console.WriteLine($"Welcome back, {currentUser.Name}!");
        ManageGoals();
    }

    static void ManageGoals()
    {
        while (true)
        {
            Console.WriteLine("\n1. Create a new goal");
            Console.WriteLine("2. Record an event");
            Console.WriteLine("3. Show goal list");
            Console.WriteLine("4. Show your score");
            Console.WriteLine("5. Exit to main menu");
            int choice = GetUserInput(5);

            switch (choice)
            {
                case 1:
                    CreateGoal();
                    break;
                case 2:
                    RecordEvent();
                    break;
                case 3:
                    ShowGoalList();
                    break;
                case 4:
                    ShowScore();
                    break;
                case 5:
                    return;
            }
        }
    }

    static void CreateGoal()
    {
        Console.Write("Enter the goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter the goal type (1 - Simple, 2 - Eternal, 3 - Checklist): ");
        int type = GetUserInput(3);
        Console.Write("Enter the goal value: ");
        int value = GetUserInput(int.MaxValue);
        int requiredTimes = 0;
        if (type == 3)
        {
            Console.Write("Enter the required times to complete: ");
            requiredTimes = GetUserInput(int.MaxValue);
        }

        Goal goal = new Goal
        {
            Name = name,
            Value = value,
            RequiredTimes = requiredTimes,
            IsEternal = type == 2
        };

        currentUser.Goals.Add(goal);
        Console.WriteLine("Goal created successfully!");
    }

    static void RecordEvent()
    {
        Console.WriteLine("Select a goal to record an event for:");
        for (int i = 0; i < currentUser.Goals.Count; i++)
        {
            var goal = currentUser.Goals[i];
            string status = goal.IsCompleted ? "[X]" : "[ ]";
            string checklistStatus = goal.RequiredTimes > 0 ? $" (Completed {goal.TimesCompleted}/{goal.RequiredTimes} times)" : "";
            Console.WriteLine($"{i + 1}. {status} {goal.Name} ({goal.Value} points){checklistStatus}");
        }

        int choice = GetUserInput(currentUser.Goals.Count);
        Goal selectedGoal = currentUser.Goals[choice - 1];

        if (selectedGoal.IsEternal || (selectedGoal.RequiredTimes > 0 && selectedGoal.TimesCompleted < selectedGoal.RequiredTimes))
        {
            selectedGoal.TimesCompleted++;
            currentUser.Score += selectedGoal.Value;

            if (selectedGoal.RequiredTimes > 0 && selectedGoal.TimesCompleted == selectedGoal.RequiredTimes)
            {
                currentUser.Score += 500; // Bonus for checklist goals
                selectedGoal.IsCompleted = true;
            }

            Console.WriteLine("Event recorded successfully!");
        }
        else
        {
            Console.WriteLine("Goal is already completed or exceeded maximum allowed times.");
        }
    }

    static void ShowGoalList()
    {
        Console.WriteLine("Your Goals:");
        for (int i = 0; i < currentUser.Goals.Count; i++)
        {
            var goal = currentUser.Goals[i];
            string status = goal.IsCompleted ? "[X]" : "[ ]";
            string checklistStatus = goal.RequiredTimes > 0 ? $" (Completed {goal.TimesCompleted}/{goal.RequiredTimes} times)" : "";
            Console.WriteLine($"{i + 1}. {status} {goal.Name} ({goal.Value} points){checklistStatus}");
        }
    }

    static void ShowScore()
    {
        Console.WriteLine($"Your Score: {currentUser.Score} points");
    }

    static int GetUserInput(int maxValue)
    {
        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > maxValue)
        {
            Console.WriteLine("Invalid input. Please enter a valid choice.");
        }
        return choice;
    }

    static void LoadUsers()
    {
        if (File.Exists("users.txt"))
        {
            string[] lines = File.ReadAllLines("users.txt");
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                User user = new User { Name = parts[0], Score = int.Parse(parts[1]) };
                users.Add(user);

                string[] goalLines = parts[2].Split('|');
                foreach (string goalLine in goalLines)
                {
                    string[] goalParts = goalLine.Split(';');
                    Goal goal = new Goal
                    {
                        Name = goalParts[0],
                        Value = int.Parse(goalParts[1]),
                        TimesCompleted = int.Parse(goalParts[2]),
                        RequiredTimes = int.Parse(goalParts[3]),
                        IsEternal = bool.Parse(goalParts[4]),
                        IsCompleted = bool.Parse(goalParts[5])
                    };
                    user.Goals.Add(goal);
                }
            }
        }
    }

    static void SaveUsers()
    {
        List<string> userLines = new List<string>();
        foreach (User user in users)
        {
            string goalsData = string.Join("|", user.Goals.Select(goal =>
                $"{goal.Name};{goal.Value};{goal.TimesCompleted};{goal.RequiredTimes};{goal.IsEternal};{goal.IsCompleted}"));

            userLines.Add($"{user.Name},{user.Score},{goalsData}");
        }
        File.WriteAllLines("users.txt", userLines);
    }
}
