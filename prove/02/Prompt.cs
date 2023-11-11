using System;
using System.Collections.Generic;

public class Prompt
{
	// Define list of prompts
	static List<string> prompts = new List<string>()
	{
		"Who was the most interesting person I interacted with today?",
		"What was the best part of my day?",
		"How did I see the hand of the Lord in my life today?",
		"What was the strongest emotion I felt today?",
		"If I had one thing I could do over today, what would it be?"
	};

	public string GetRandomPrompt()
	{
		// Get random prompt
		Random random = new Random();
		int promptIndex = random.Next(prompts.Count);
		string prompt = prompts[promptIndex];

		return prompt;
	}
}