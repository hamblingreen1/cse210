using System;

public class BreathingActivity : Activity
{
	// Breathing activity constructor
	public BreathingActivity()
	{
		_name = "Breathing";
		_description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
	}

	public void Run()
	{
		// Display starting message
		DisplayStartingMessage();

		DateTime currentTime = DateTime.Now;
		DateTime futureTime = currentTime.AddSeconds(_duration);

		while (currentTime < futureTime)
		{
			// Display breathing messages
			Console.WriteLine("Breathe in...");
			ShowTimer(4);
			Console.WriteLine("Now breathe out...");
			ShowTimer(6);
			Console.WriteLine();

			// Update time
			currentTime = DateTime.Now;
		}

		// Display ending message
		DisplayEndingMessage();
	}
}
