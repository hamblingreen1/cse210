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
		Thread.Sleep(3000);
		
		Console.WriteLine("Please start listing items: ");
		
		List<string> items = new List<string>();
		
		while (true)
		{
			string item = Console.ReadLine();

			if (item == "")
			{
				break;
			}
			
			items.Add(item);
		}

		Console.WriteLine();
		Console.WriteLine($"You listed {items.Count} items.");

		// Display ending message
		DisplayEndingMessage();
	}

	public void GetRandomPrompt()
	{
		// Define prompts list
		private List<string> _prompts = new List<string>
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
		Console.WriteLine($"--- {prompt} ---");
	}

	public List<string> GetListFromUser()
	{
		List<string> userList = new List<string>();
		string input;

		DateTime currentTime = DateTime.Now;
		DateTime futureTime = currentTime.AddSeconds(_duration);

		while (currentTime < futureTime)
		{
			input = Console.ReadLine

			// Update time
			currentTime = DateTime.Now;
		}
	}
}
