using System;
using System.Collections.Generic;

namespace MindfulnessProgram
{
    public class ListingActivity : Activity
    {
        private List<string> _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        private Random _rand = new Random();

        public ListingActivity()
        {
            _activityName = "Listing Activity";
            _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        }

        protected override void PerformActivity()
        {
            Console.WriteLine();
            string prompt = _prompts[_rand.Next(_prompts.Count)];
            Console.WriteLine(prompt);
            Console.WriteLine("You have 5 seconds to think...");
            Countdown(5);
            Console.WriteLine("Start listing items. Press Enter after each item:");

            List<string> responses = new List<string>();
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(_duration);

            while (DateTime.Now < endTime)
            {
                if (Console.KeyAvailable)
                {
                    string input = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(input))
                        responses.Add(input.Trim());
                }
            }

            Console.WriteLine();
            Console.WriteLine($"You listed {responses.Count} items. Great work!");
        }
    }
}