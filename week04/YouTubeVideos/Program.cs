using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // VIDEO 1
        Video video1 = new Video("Learning C#", "Ashley", 600);

        video1.AddComment(new Comment("Juan", "Great tutorial!"));
        video1.AddComment(new Comment("Maria", "Very helpful."));
        video1.AddComment(new Comment("Carlos", "Thanks for explaining."));

        videos.Add(video1);

        // VIDEO 2
        Video video2 = new Video("Gaming Highlights", "Alex", 420);

        video2.AddComment(new Comment("Sofia", "Amazing gameplay!"));
        video2.AddComment(new Comment("Luis", "So funny."));
        video2.AddComment(new Comment("Elena", "I enjoyed this video."));

        videos.Add(video2);

        // VIDEO 3
        Video video3 = new Video("Cooking Pasta", "Chef Anna", 900);

        video3.AddComment(new Comment("Pedro", "Looks delicious."));
        video3.AddComment(new Comment("Laura", "I will try this recipe."));
        video3.AddComment(new Comment("Miguel", "Very easy to follow."));

        videos.Add(video3);

        // DISPLAY VIDEO INFORMATION
        foreach (Video video in videos)
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");

            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"{comment.GetPersonName()}: {comment.GetText()}");
            }

            Console.WriteLine();
        }
    }
}