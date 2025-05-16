using System;
using System.Collections.Generic;

class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "List as many things as you are grateful for.",
        "List the qualities you admire in yourself.",
        "List the goals you want to achieve this year."
    };

    public ListingActivity() : base("Listing", "This activity will help you reflect by listing items that you value or appreciate.", 60)
    {
    }

    public override void Run()
    {
        DisplayStartingMessage();

        Random random = new Random();
        string prompt = _prompts[random.Next(_prompts.Count)];
        Console.WriteLine($"\nPrompt: {prompt}");
        Console.WriteLine("Start listing items. You have 60 seconds!");

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        int count = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string response = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(response))
            {
                count++;
            }
        }

        Console.WriteLine($"\nYou listed {count} items.");
        DisplayEndingMessage();
    }
}