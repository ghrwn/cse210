using System;

namespace MindfulnessProgram
{
    public class BreathingActivity : Activity
    {
        public BreathingActivity()
        {
            _activityName = "Breathing Activity";
            _description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
        }

        protected override void PerformActivity()
        {
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(_duration);

            while (DateTime.Now < endTime)
            {
                Console.Write("Breathe in...");
                Countdown(4);
                Console.WriteLine();

                Console.Write("Breathe out...");
                Countdown(6);
                Console.WriteLine();
            }
        }
    }
}