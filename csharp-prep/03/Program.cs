using System;

class Program
{
	static void Main(string[] args)
	{
		// Receive magic number
		Console.Write("What is the magic number? ");
		string input = Console.ReadLine();
		int magicNumber = int.Parse(input);

		int guessCount = 0; // Number of guesses made
		int guess = 0; // Current guess
		
		while (guess != magicNumber)
		{
			// Receive guess
			Console.Write("What is the your guess? ");
			input = Console.ReadLine();
			guess = int.Parse(input);

			if (guess < magicNumber)
			{
				Console.WriteLine("Higher");
			}
			else if (guess > magicNumber)
			{
				Console.WriteLine("Lower");
			}
			else
			{
				Console.WriteLine("You guessed it!");
			}
			guessCount++;
		}
		// Print guess count
		Console.WriteLine($"You made {guessCount} guesses.");
	}
}