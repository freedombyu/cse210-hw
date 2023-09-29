using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string scriptureReference = "John 3:16";
        string scriptureText = "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.";

        HideRandomWords(scriptureReference, scriptureText);
    }

    static void HideRandomWords(string reference, string text)
    {
        Console.Clear();
        List<string> words = text.Split(' ').ToList();
        List<int> hiddenWordIndices = new List<int>();
        Random random = new Random();

        while (hiddenWordIndices.Count < words.Count)
        {
            int indexToHide = random.Next(words.Count);

            if (!hiddenWordIndices.Contains(indexToHide))
            {
                hiddenWordIndices.Add(indexToHide);
                words[indexToHide] = new string('_', words[indexToHide].Length);
                Console.Clear();
                Console.WriteLine($"{reference}\n");
                Console.WriteLine(string.Join(" ", words));
                Console.WriteLine("\nPress Enter to continue or type 'quit' to exit.");
                string input = Console.ReadLine();

                if (input.ToLower() == "quit")
                {
                    break;
                }
            }
        }

        Console.WriteLine("\nAll words are now hidden. Press Enter to exit.");
        Console.ReadLine();
    }
}
