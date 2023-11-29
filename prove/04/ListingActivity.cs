using System;

public class ListingActivity : Activity
{

	public ListingActivity()
	{
		_name = "Listing";
		_description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
	}

	public void Run()
	{
		// Display starting message
		DisplayStartingMessage();

		// Display random prompt
		GetRandomPrompt();
		
		// Get list from user
		List<string> _responses = GetListFromUser();
		
		// Display number of _responses counted
		Console.Write($"You listed {_responses.Count} items! ");
		Console.WriteLine();

		// Display ending message
		DisplayEndingMessage();
	}

	public void GetRandomPrompt()
	{
		// Define prompts list
		List<string> _prompts = new List<string>()
		{
			"Who are people that you appreciate?",
			"What are personal strengths of yours?",
			"Who are people that you have helped this week?",
			"When have you felt the Holy Ghost this month?",
			"Who are some of your personal heroes?"
		};

		// Get random prompt
		Random random = new Random();
		string prompt = _prompts[random.Next(_prompts.Count)];

		// Display prompt
		Console.WriteLine("List as many responses as you can to the following prompt:");
		Console.WriteLine($"--- {prompt} ---");
		Console.Write("You may begin in: ");
		ShowTimer(9);
	}

	public List<string> GetListFromUser()
	{
		List<string> _responses = new List<string>();
		string input;

		DateTime currentTime = DateTime.Now;
		DateTime futureTime = currentTime.AddSeconds(_duration);

		while (currentTime < futureTime)
		{
			Console.Write("> ");
			input = Console.ReadLine();

			// Update time
			currentTime = DateTime.Now;

			// Append input to responses
			_responses.Add(input);
		}

		return _responses;
	}
}
