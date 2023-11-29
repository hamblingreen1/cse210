using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

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
		
		// Get list from user
		List<string> items = GetListFromUser();
		
		// Display number of items counted
		Console.WriteLine();
		Console.WriteLine($"You listed {items.Count} items!");

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
		Console.WriteLine("Consider the following prompt:");
		Console.WriteLine();
		Console.WriteLine($"--- {prompt} ---");
		Console.WriteLine();
		Console.WriteLine("When you have something in mind, press enter to continue.");
		Console.WriteLine();

		// Pause and wait for user to press enter
		Console.ReadLine();
		Console.Clear();
	}

	public List<string> GetListFromUser()
	{
		List<string> items = new List<string>();
		string input;

		DateTime currentTime = DateTime.Now;
		DateTime futureTime = currentTime.AddSeconds(_duration);

		while (currentTime < futureTime)
		{
			input = Console.ReadLine();

			// Update time
			currentTime = DateTime.Now;
			items.Add(input);
		}

		return items;
	}
}
