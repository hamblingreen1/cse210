using System;

public class ReflectingActivity : Activity
{


	public ReflectingActivity()
	{
		_name = "Reflecting";
		_description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
	}

	public void Run()
	{
		// Display starting message
		DisplayStartingMessage();
		
		// Get and display prompt
		string prompt = GetRandomPrompt();
		DisplayPrompt(prompt);

		// Date and time
		DateTime currentTime = DateTime.Now;
		DateTime futureTime = currentTime.AddSeconds(_duration);

		while (currentTime < futureTime)
		{
			// Display questions
			string question = GetRandomQuestion();
			DisplayQuestion(question);

			// Update time
			currentTime = DateTime.Now;
		}

		// Display ending message
		DisplayEndingMessage();
	}

	public string GetRandomPrompt()
	{
		// Define prompts list
		List<string> _prompts = new List<string>
		{
			"Think of a time when you stood up for someone else.",
			"Think of a time when you did something really difficult.",
			"Think of a time when you helped someone in need.",
			"Think of a time when you did something truly selfless."
		};

		// Get random prompt
		Random random = new Random();
		string prompt = _prompts[random.Next(_prompts.Count)];

		return prompt;
	}

	public string GetRandomQuestion()
	{
		// Define questions list
		List<string> _questions = new List<string>
		{
			"Why was this experience meaningful to you?",
			"Have you ever done anything like this before?",
			"How did you get started?",
			"How did you feel when it was complete?",
			"What made this time different than other times when you were not as successful?",
			"What is your favorite thing about this experience?",
			"What could you learn from this experience that applies to other situations?",
			"What did you learn about yourself through this experience?",
			"How can you keep this experience in mind in the future?"
		};

		// Get random question
		Random random = new Random();
		string question = _questions[random.Next(_questions.Count)];

		return question;
	}

	public void DisplayPrompt(string prompt)
	{
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

		// Last instructions
		Console.WriteLine("Now ponder on each of the following questions as they related to this experience");
		Console.Write("You may begin in: ");
		ShowTimer(5);
	}

	public void DisplayQuestion(string question)
	{
		// Display prompt
		Console.WriteLine($"> {question}");
		ShowTimer(10);
	}
}
