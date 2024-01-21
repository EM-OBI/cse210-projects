using System.Collections.Generic;

public class PromptGenerator
{

    public List<string> _prompts = new List<string>  
    {
       "Who was the most interesting person I interacted with today?",
       "What did I waste time on doing today that could've been pushed forward or done quicker?",
       "Did I miss out on an opportunity to help someone in need of my help today?",
       "How many times did I get angry and why?",
       "If I had one thing I could do over today, what would it be?"
    };

    public string GetRandomPrompt()
    {
        Random randomNumber = new Random();
        int number = randomNumber.Next(0, 5);
        return _prompts[number];
    }

}