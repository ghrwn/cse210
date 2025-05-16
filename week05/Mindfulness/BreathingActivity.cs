using System;

class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing", "This activity will help you relax by guiding you through slow, deep breaths.", 30)
    {
    }

    public override void Run()
    {
        DisplayStartingMessage();

        int cycles = _duration / 10;
        for (int i = 0; i < cycles; i++)
        {
            Console.Write("\nBreathe in... ");
            ShowCountDown(5);
            Console.Write("Breathe out... ");
            ShowCountDown(5);
        }

        DisplayEndingMessage();
    }
}