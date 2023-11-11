using System;

public class Entry
{
	// Define entry attributes
	public string _prompt { get; }
	public string _response { get; }
	public string _date { get; }

	// Entry structure
	public Entry(string prompt, string response, string date)
	{
		_prompt = prompt;
		_response = response;
		_date = date;
	}
}
