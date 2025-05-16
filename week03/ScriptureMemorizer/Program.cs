using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string filePath = @"C:\Users\Mcoy\Documents\cse210\cse210\week03\ScriptureMemorizer\scriptures.txt";

        Console.WriteLine("Looking for scriptures.txt in: " + Environment.CurrentDirectory);

        if (!File.Exists(filePath))
        {
            Console.WriteLine($"File '{filePath}' not found.");
            Console.WriteLine("No scriptures found. Exiting.");
            return;
        }

        List<Scripture> scriptures = LoadScripturesFromFile(filePath);

        if (scriptures.Count == 0)
        {
            Console.WriteLine("No scriptures loaded. Exiting.");
            return;
        }

        Random random = new Random();

        Scripture scripture = scriptures[random.Next(scriptures.Count)];

        while (!scripture.AllWordsHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());

            Console.WriteLine("\nPress Enter to hide some words or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                Console.WriteLine("Exiting program. Goodbye!");
                return;
            }

            scripture.HideRandomWords(3);
        }

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\nAll words are hidden. Good job!");
    }

    static List<Scripture> LoadScripturesFromFile(string filePath)
    {
        var scriptures = new List<Scripture>();

        foreach (var line in File.ReadLines(filePath))
        {
            if (string.IsNullOrWhiteSpace(line))
                continue;

            string[] parts = line.Split('|');
            if (parts.Length != 2)
                continue;

            string referenceText = parts[0].Trim();
            string scriptureText = parts[1].Trim();

            Reference reference = new Reference(referenceText);
            Scripture scripture = new Scripture(reference, scriptureText);

            scriptures.Add(scripture);
        }

        return scriptures;
    }
}