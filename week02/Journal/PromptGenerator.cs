using System;
using System.Collections.Generic;

public class PromptGenerator
{
    private List<string> _prompts = new List<string>
    {
        "What decision did I make today that I'm proud of?",
        "What would I tell my younger self about today?",
        "Is there someone I need to reach out to or apologise to?",
        "Who inspired me today and what did they do?",
        "Am I becoming the person I want to be?",
        "What made me laugh or smile today?",
        "What progress did I make towards my goals today?",
        "What surprised me most about today?",
        "If today were a movie scene, what would it be called?",
        "Who was the most interesting person I interacted with today?"
    };

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}