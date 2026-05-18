using System;
using System.Collections.Generic;

public class PromptGenerator
{
    public List<string> _prompts = new List<string>()
    {
    "What was the most important thing I did today?",
    "What lesson did life teach me today?",
    "What moment today do I want to remember forever?",
    "What was my biggest challenge today?",
    "What made me feel peace today?",
    "What goal did I move closer to today?",
    "How did I become a better person today?"
    };

    Random random = new Random();

    public string GetRandomPrompt()
    {
        int index = random.Next(_prompts.Count);

        return _prompts[index];
    }
}