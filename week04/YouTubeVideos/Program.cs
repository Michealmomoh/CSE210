using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Create a list to store videos
        List<Video> videos = new List<Video>();

        // Create videos
        Video video1 = new Video("C# Basics", "John Doe", 3600);
        video1.Comments.Add(new Comment("Alice", "Very informative!"));
        video1.Comments.Add(new Comment("Bob", "Great job explaining!"));
        video1.Comments.Add(new Comment("Charlie", "Loved the examples!"));

        Video video2 = new Video("Advanced C#", "Jane Smith", 4200);
        video2.Comments.Add(new Comment("Dave", "This was fantastic!"));
        video2.Comments.Add(new Comment("Eva", "I learned so much."));
        video2.Comments.Add(new Comment("Frank", "Great for advanced learners."));

        Video video3 = new Video("C# for Beginners", "Chris Brown", 3000);
        video3.Comments.Add(new Comment("Grace", "Clear and concise."));
        video3.Comments.Add(new Comment("Henry", "Easy to follow."));
        video3.Comments.Add(new Comment("Ivy", "Perfect for newbies."));

        // Add videos to the list
        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        // Display video information
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");
            foreach (var comment in video.Comments)
            {
                Console.WriteLine($"- {comment.CommenterName}: {comment.Text}");
            }
            Console.WriteLine(); // Blank line between videos
        }
    }
}
