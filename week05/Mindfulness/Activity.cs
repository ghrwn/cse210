using System;
using System.Threading;

abstract class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description, int duration)
    {
        _name = name;
        _description = description;
        _duration = duration;
    }

    protected void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Starting {_name} Activity...");
        Console.WriteLine(_description);
        Console.WriteLine($"This activity will last for {_duration} seconds.");
        Console.WriteLine("\nGet ready...");
        ShowSpinner(3);
    }

    protected void DisplayEndingMessage()
    {
        Console.WriteLine("\nWell done!");
        ShowSpinner(3);
        Console.WriteLine($"\nYou have completed the {_name} activity for {_duration} seconds.");
    }

    protected void ShowSpinner(int seconds)
    {
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        string[] spinner = { "|", "/", "-", "\\" };
        int counter = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(spinner[counter % spinner.Length]);
            Thread.Sleep(250);
            Console.Write("\b");
            counter++;
        }
    }

    protected void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i} ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    public abstract void Run();
}