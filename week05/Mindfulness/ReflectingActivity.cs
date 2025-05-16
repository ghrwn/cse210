using System;
using System.Collections.Generic;

class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you did something truly meaningful.",
        "Recall a moment when you felt strong and capable.",
        "Reflect on a time you overcame a significant challenge."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "How did this experience make you feel stronger?",
        "What did you learn from this experience?",
        "How can you apply this experience in your life now?"
    };

    public ReflectingActivity() : base("Reflecting", "This activity will help you reflect on times in your life when you showed strength and resilience.", 60)
    {
    }

    public override void Run()
    {
        DisplayStartingMessage();

        Random random = new Random();
        string prompt = _prompts[random.Next(_prompts.Count)];
        Console.WriteLine($"\nPrompt: {prompt}");
        ShowSpinner(5);

        foreach (string question in _questions)
        {
            Console.WriteLine($"\n{question}");
            ShowSpinner(5);
        }

        DisplayEndingMessage();
    }
}