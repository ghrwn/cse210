using System;

class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video("C# Tutorial", "Alice", 600);
        Video video2 = new Video("Cooking Pasta", "Bob", 480);
        Video video3 = new Video("Travel Vlog", "Charlie", 900);

        video1.AddComment(new Comment("David", "Very helpful, thanks!"));
        video1.AddComment(new Comment("Emma", "Can you explain LINQ more?"));
        video1.AddComment(new Comment("Frank", "Awesome tutorial!"));

        video2.AddComment(new Comment("Gina", "I love pasta!"));
        video2.AddComment(new Comment("Harry", "Great recipe!"));
        video2.AddComment(new Comment("Ivy", "Tried it and it was delicious!"));

        video3.AddComment(new Comment("Jack", "Beautiful scenery!"));
        video3.AddComment(new Comment("Karen", "Where is this place?"));
        video3.AddComment(new Comment("Liam", "Amazing video!"));

        Video[] videos = { video1, video2, video3 };

        foreach (Video video in videos)
        {
            video.Display();
        }
    }
}