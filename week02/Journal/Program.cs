using System;

class Program
{
    static void Main(string[] args)
    {
        Journal myJournal = new Journal();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nJournal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    myJournal.AddEntry();
                    break;
                case "2":
                    myJournal.DisplayEntries();
                    break;
                case "3":
                    Console.Write("\nEnter a filename to save to: ");
                    string saveFile = Console.ReadLine();
                    myJournal.SaveJournal(saveFile);
                    break;
                case "4":
                    Console.Write("\nEnter a filename to load from: ");
                    string loadFile = Console.ReadLine();
                    myJournal.LoadJournal(loadFile);
                    break;
                case "5":
                    running = false;
                    Console.WriteLine("\nGoodbye!");
                    break;
                default:
                    Console.WriteLine("\nInvalid choice, please try again.");
                    break;
            }
        }
    }
}
