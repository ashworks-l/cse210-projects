using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>()
    {
        "Who are people you appreciate?",
        "What are your personal strengths?",
        "Who have you helped recently?",
        "When have you felt peace this month?",
        "Who are your personal heroes?"
    };

    private Random _random = new Random();

    public ListingActivity()
        : base(
            "Listing Activity",
            "This activity helps you reflect by listing positive things in your life.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine("\n" + GetRandomPrompt());
        Console.WriteLine("You may begin in...");
        ShowCountdown(5);

        DateTime end = DateTime.Now.AddSeconds(GetDuration());
        int count = 0;

        Console.WriteLine("\nStart listing items:");

        while (DateTime.Now < end)
        {
            Console.Write("> ");
            string input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
            {
                count++;
            }
        }

        Console.WriteLine($"\nYou listed {count} items!");
        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        return _prompts[_random.Next(_prompts.Count)];
    }
}