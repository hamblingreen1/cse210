using System;

public class Activity
{
	// Define protected variables
	protected string _name;
	protected string _description;
	protected int _duration;

	public void DisplayStartingMessage()
	{
		// Display instructions
		Console.Clear();
		Console.WriteLine($"Welcome to the {_name} Activity.");
		Console.WriteLine();
		Console.WriteLine(_description);
		Console.WriteLine();
		Console.Write($"How long, in seconds, would you like for your session? ");
		_duration = Int32.Parse(Console.ReadLine());
		Console.WriteLine();

		// Display message to get ready
		Console.Clear();
		Console.WriteLine($"Get ready...");
		Console.WriteLine();
		Thread.Sleep(3000); // Pause for 3 seconds
	}

	public void DisplayEndingMessage()
	{
		// Display closing message
		Console.WriteLine();
		Console.WriteLine("Well done!!");
		Console.WriteLine();
		Console.WriteLine($"You have completed {_duration} seconds of the {_name} Activity.");
		Thread.Sleep(3000); // Pause for 3 seconds
	}

	// Countdown timer for number of seconds specified
	public void ShowTimer(int seconds)
	{
		for (int i = seconds; i > 0; i--)
		{
			Console.Write(i);
			Thread.Sleep(1000); // Pause for 1 second
			Console.Write("\b \b"); // Remove the last character
		}
	}
}

