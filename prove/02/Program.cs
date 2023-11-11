/****************************************
* journal -- manage a personal journal	*
* Author: Bobby Hamblin			*
*   <hamblingreen@hotmail.com>		*
* Purpose: Demonstate an application of	*
*   abstraction				*
* Usage: At menu, enter one of the	*
*   following options:			*
*     1 / a. Write			*
*     2 / e. Display			*
*     3 / d. Load			*
*     4 / p. Save			*
*     5 / s. Quit			*
*   Either the number or letter option	*
*   is acceptable. To write in your	*
*   journal, select option one and	*
*   respond to the prompt randomly	*
*   printed from the Prompts list. To	*
*   display the journal saved in the	*
*   program, select option two. To load	*
*   a journal from a file, select	*
*   option three. To save a journal to	*
*   a file, select option four.		*
*   Finally, to quit the program select	*
*   option five.			*
* Creativity: I added letter options	*
*   for each category, as well as error	*
*   checking for when a file or journal	*
*   are empty				*
****************************************/

using System;
using System.Collections.Generic;
using System.IO;

class Program
{
	// Create instance of the Journal class
	static Journal journal = new Journal();

	static void Main(string[] args)
	{
		// Print welcome message
		Console.WriteLine("Welcome to the journal program!");

		// Main loop
		while (true)
		{
			// Print menu
			Console.WriteLine("Please select one of the following choices:");
			Console.WriteLine("1 / w. Write");
			Console.WriteLine("2 / d. Display");
			Console.WriteLine("3 / l. Load");
			Console.WriteLine("4 / s. Save");
			Console.WriteLine("5 / q. Quit");

			// Receive user input
			Console.Write("What would you like to do? ");
			string choice = Console.ReadLine();
			choice = choice.ToLower();

			// Call option's function
			switch (choice)
			{
				case "1":
				case "w":
					Write();
					break;
				case "2":
				case "d":
					Display();
					break;
				case "3":
				case "l":
					Load();
					break;
				case "4":
				case "s":
					Save();
					break;
				case "5":
				case "q":
					return;
				default:
					Console.WriteLine("Invalid choice, Please try again");
					break;
			}

			Console.WriteLine();
		}
	}

	static void Write()
	{
		// Instantiate prompts list
		Prompt prompt = new Prompt();

		// Get random prompt
		string randomPrompt = prompt.GetRandomPrompt();

		// Receive user input from prompt
		Console.WriteLine(randomPrompt);
		Console.Write("> ");
		string response = Console.ReadLine();

		// Get date from system
		DateTime date = DateTime.Now;
		string formattedDate = date.ToString("yyyy-MM-dd");

		// Create new instance of the Entry class
		Entry entry = new Entry(randomPrompt, response, formattedDate);

		// Append that to the journal
		journal.AddEntry(entry);
	}

	static void Display()
	{
		// If journal is empty, display error
		if (journal.Entries.Count == 0)
		{
			Console.WriteLine("There are no entries in your journal.");
			return;
		}

		// Iterate through entry list, displaying each entry
		foreach (Entry entry in journal.Entries)
		{
			Console.WriteLine($"Date: {entry.Date} -- Prompt: {entry.Prompt}");
			Console.WriteLine($"Response: {entry.Response}");
			Console.WriteLine();
		}
	}

	static void Save()
	{
		// If journal is empty, don't save it
		if (journal.Entries.Count == 0)
		{
			Console.WriteLine("There are no entries in your journal.");
			return;
		}

		// Get filename from user
		Console.Write("What is the filename? ");
		string filename = Console.ReadLine();

		// Open file
		using (StreamWriter writer = new StreamWriter(filename))
		{
			// Iterate through each entry
			foreach (Entry entry in journal.Entries)
			{
				// Save entry to file
				writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
			}
		}
	}

	static void Load()
	{
		// Get filename from user
		Console.Write("What is the filename? ");
		string filename = Console.ReadLine();

		// Instantiate new entry list
		List<Entry> entries = new List<Entry>();

		// Open file
		using (StreamReader reader = new StreamReader(filename))
		{
			// Iterate through file
			string line;
			while ((line = reader.ReadLine()) != null)
			{
				// Split each line into a list of strings
				string[] parts = line.Split("|");

				string date = parts[0];
				string prompt = parts[1];
				string response = parts[2];

				// Assign each string to a part of an entry
				Entry entry = new Entry(prompt, response, date);
				entries.Add(entry);
			}
		}

		// Replace entries in the current journal with the new one
		journal.ReplaceEntries(entries);
	}
}
