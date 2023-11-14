/****************************************
* scripture -- memorize scriptures	*
* Author: Bobby Hamblin			*
*   <hamblingreen@hotmail.com>		*
* Purpose: Demonstate an application of	*
*   encapsulation			*
* Usage: Select difficulty at prompt.	*
*   Easy corresponds to 3 words hidden,	*
*   Medium is 6, and Hard is 10. Type	*
*   "quit" to exit the program		*
* Creativity: 				*
****************************************/

using System;

class Program
{
	static void Main(string[] args)
	{
		// Scripture string
		string text = "And he said unto me: Because of thy faith in Christ, whom thou hast never before heard nor seen. And many years pass away before he shall manifest himself in the flesh; wherefore, go to, thy faith hath made thee whole";
		string book = "Enos";
		int chapter = 1;
		int verse = 8;
		int endVerse = 0;

		int wordsToHide = 0;

		// Instantiate reference
		Reference reference = new Reference(book, chapter, verse, endVerse);

		// Instantiate scripture
		Scripture scripture = new Scripture(reference, text);

		// Ask for difficulty
		while (wordsToHide == 0)
		{
			Console.WriteLine("Please select a difficulty:");
			Console.WriteLine("1: Easy");
			Console.WriteLine("2: Medium");
			Console.WriteLine("3: Hard");
			Console.WriteLine();
			Console.Write("Your selection (1, 2, 3): ");
			string input = Console.ReadLine();
			if (input == "1")
				wordsToHide = 3;
			if (input == "2")
				wordsToHide = 6;
			if (input == "3")
				wordsToHide = 10;
			Console.Clear();
		}

		Console.Clear();

		// Main loop
		while (!scripture.IsCompletelyHidden())
		{				
			// Print scripture
			Console.WriteLine(reference.GetDisplayText() + " " + scripture.GetDisplayText());

			// Check for "quit" input before continuing
			Console.WriteLine();
			Console.WriteLine("Press enter to continue or type 'quit' to finish:");
			string input = Console.ReadLine();
			if (input == "quit")
				return;
			
			// Clear console screen
			Console.Clear();

			// Hide three random words from scripture
			scripture.HideRandomWords(wordsToHide);
		}

			// Print final hidden scripture
			Console.WriteLine(reference.GetDisplayText() + " " + scripture.GetDisplayText());
			Console.WriteLine();
			Console.WriteLine($"Congratulations! You've memorized {reference.GetDisplayText()}");
	}
}
