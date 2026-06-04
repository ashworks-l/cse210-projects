using System;
using System.Collections.Generic;

public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>()
    {
        "Why was this experience meaningful to you?",
        "How did you feel when it was complete?",
        "What did you learn about yourself?",
        "What made this experience different?",
        "How can you apply this in the future?",
        "What strengths did you show?",
        "What would you do differently next time?"
    };

    private Random _random = new Random();

    public ReflectingActivity()
        : base(
            "Reflecting Activity",
            "This activity helps you reflect on moments of strength and resilience.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine();
        DisplayPrompt();

        DateTime end = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < end)
        {
            Console.WriteLine("\n" + GetRandomQuestion());
            ShowSpinner(5);
        }

        DisplayEndingMessage();
    }

    private void DisplayPrompt()
    {
        Console.WriteLine(GetRandomPrompt());
        Console.WriteLine("\nThink about this moment...");
        ShowSpinner(5);
    }

    private string GetRandomPrompt()
    {
        return _prompts[_random.Next(_prompts.Count)];
    }

    private string GetRandomQuestion()
    {
        return _questions[_random.Next(_questions.Count)];
    }
}