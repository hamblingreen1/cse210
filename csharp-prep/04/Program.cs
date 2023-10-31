using System;
using System.Collections.Generic;

class Program
{
	static void Main(string[] args)
	{
		// Define list
		List<int> numbers = new List<int>();
		int number = 0;

		// Print intro text
		Console.WriteLine("Enter a list of numbers, type 0 when finished.");

		// Number entry loop
		do
		{
			Console.Write("Enter a number: ");
			string input = Console.ReadLine();
			number = int.Parse(input);
			numbers.Add(number);
		} while (number != 0);

		// Compute and print sum
		float sum = 0; // Total of numbers in list
		for (int i = 0; i < numbers.Count; i++)
		{
			sum += numbers[i];
		}
		Console.WriteLine($"The sum is: {sum}");

		// Compute and print average
		float average = sum / (numbers.Count - 1);
		Console.WriteLine($"The average is: {average}");

		// Compute and print maximum
		int maximum = number;
		for (int i = 0; i < numbers.Count; i++)
		{
			if (maximum < numbers[i])
			{
				maximum = numbers[i];
			}
		}
		Console.WriteLine($"The largest number is: {maximum}");
	}
}