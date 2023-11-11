using System;

public class Entry
{
	// Define entry attributes
	public string Prompt { get; }
	public string Response { get; }
	public string Date { get; }

	// Entry structure
	public Entry(string prompt, string response, string date)
	{
		Prompt = prompt;
		Response = response;
		Date = date;
	}
}
