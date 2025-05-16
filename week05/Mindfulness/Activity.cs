using System;
using System.Collections.Generic;
using System.Threading;

namespace MindfulnessProgram
{
    public abstract class Activity
    {
        protected string _activityName;
        protected string _description;
        protected int _duration;

        private static List<string> motivationalMessages = new List<string>
        {
            "Great job! Keep up the good work!",
            "You're doing amazing, keep going!",
            "Mindfulness is a journey. Proud of you!",
            "Each step counts towards peace and calm.",
            "Keep practicing and growing every day!"
        };

        private static Dictionary<string, int> activitySessionCount = new Dictionary<string, int>();

        public void Run()
        {
            ShowStartingMessage();
            PrepareToBegin();
            PerformActivity();
            ShowFinishingMessage();
            ShowMotivationalMessage();
        }

        protected void ShowStartingMessage()
        {
            Console.Clear();
            Console.WriteLine($"--- {_activityName} ---");
            Console.WriteLine();
            Console.WriteLine(_description);
            Console.WriteLine();
            Console.Write("Enter duration in seconds for this activity: ");
            while (!int.TryParse(Console.ReadLine(), out _duration) || _duration <= 0)
            {
                Console.Write("Please enter a valid positive number for duration: ");
            }
            Console.WriteLine();
        }

        protected void PrepareToBegin()
        {
            Console.WriteLine("Get ready...");
            ShowSpinner(3);
            Console.WriteLine();
        }

        protected abstract void PerformActivity();

        protected void ShowFinishingMessage()
        {
            Console.WriteLine();
            Console.WriteLine($"Well done! You have completed the {_activityName} activity for {_duration} seconds.");
            Thread.Sleep(2000);
        }

        protected void ShowMotivationalMessage()
        {
            if (!activitySessionCount.ContainsKey(_activityName))
                activitySessionCount[_activityName] = 0;

            activitySessionCount[_activityName]++;
            int count = activitySessionCount[_activityName];
            int index = (count - 1) % motivationalMessages.Count;

            Console.WriteLine();
            Console.WriteLine($"*** {motivationalMessages[index]} ***");
            Thread.Sleep(3000);
            Console.WriteLine();
        }

        protected void ShowSpinner(int seconds)
        {
            string spinner = "|/-\\";
            DateTime endTime = DateTime.Now.AddSeconds(seconds);
            int i = 0;

            while (DateTime.Now < endTime)
            {
                Console.Write(spinner[i]);
                Thread.Sleep(250);
                Console.Write("\b");
                i = (i + 1) % spinner.Length;
            }
        }

        protected void Countdown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
        }
    }
}