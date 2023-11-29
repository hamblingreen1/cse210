using System;

public class Activity
{
	// Define protected variables
	protected string _name;
	protected string _description;
	protected int _duration = 0;

	public void DisplayStartingMessage()
	{
		// Display instructions
		Console.Clear();
		Console.WriteLine($"Welcome to the {_name} Activity.");
		Console.WriteLine();
		Console.WriteLine(_description);

		while (_duration == 0)
		{
			Console.WriteLine();
			Console.Write($"How long, in seconds, would you like for your session? ");
			_duration = Int32.Parse(Console.ReadLine());
			if (_duration <= 0)
			{
				Console.WriteLine();
				Console.WriteLine("Your session duration must be positive and non-zero");
			}
		}

		Console.WriteLine();

		// Display message to get ready
		Console.Clear();
		Console.Write($"Get ready...");
		ShowTimer(5);
		Console.WriteLine();
	}

	public void DisplayEndingMessage()
	{
		// Display closing message
		Console.WriteLine();
		Console.Write("Well done!! ");
		ShowTimer(5);
		Console.WriteLine();
		Console.Write($"You have completed {_duration} seconds of the {_name} Activity...");
		ShowTimer(5);
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

		Console.WriteLine();
	}
}

