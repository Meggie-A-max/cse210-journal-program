
using System;
using System.Collections.Generic;

public class PromptGenerator
{
    public List<string> _prompts = new List<string>
    {
        "What was the best part of your day?",
        "What did you learn today?",
        "What made you smile today?",
        "What was something challenging you experienced today?",
        "What are you grateful for today?",
        "What is one thing you would like to improve tomorrow?"
    };

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}
