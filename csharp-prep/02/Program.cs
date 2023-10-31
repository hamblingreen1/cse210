using System;

class Program
{
	static void Main(string[] args)
	{
		// Recieve user input
		Console.Write("What is your grade percentage? ");
		string input = Console.ReadLine();
		int gradePercentage = int.Parse(input);

		// Determine letter grade
		string letter;
		bool pass = true;
		if (gradePercentage >= 90)
		{
			letter = "A";
		}
		else if (gradePercentage >= 80)
		{
			letter = "B";
		}
		else if (gradePercentage >= 70)
		{
			letter = "C";
		}
		else if (gradePercentage >= 60)
		{
			letter = "D";
		}
		else if (gradePercentage < 60)
		{
			letter = "F";
		}
		else
		{
			Console.WriteLine("Invalid grade percentage input");
			return;
		}

		if (gradePercentage > 60)
		{
			pass = true;
		}
		else if (gradePercentage <= 60)
		{
			pass = false;
		}

			// Determine grade modifier (+/-)
			int gradeMod = gradePercentage % 10;
			string letterMod = "";

			if (letter != "F")
			{
				if (letter != "A")
				{
				if (gradeMod >= 7)
				{
					letterMod = "+";
				}
			}

			if (gradeMod < 3)
			{
				letterMod = "-";
			}
		}

		// Concatenate final grade
		letter += letterMod;

		// Print letter grade and pass/fail
		Console.WriteLine($"Your grade is: {letter}");
		if (pass == true)
		{
			Console.WriteLine("You passed!");
		}
		else if (pass == false)
		{
			Console.WriteLine("You didn't pass :(");
		}
	}
}